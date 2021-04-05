using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class DetalheFaturaEmailPenso
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NomeExibicao { get; set; }
        public string Status { get; set; }
        public int PossuiConnect { get; set; }
        public string Referencia { get; set; }
        public string CCusto { get; set; }
        public decimal Valor { get; set; }

        public DetalheFaturaEmailPenso()
        {

        }

        private OleDbConnection OpenConnection(string path)
        {
            OleDbConnection oledbConn = null;
            try
            {
                if (Path.GetExtension(path) == ".xls" || Path.GetExtension(path) == ".XLS")
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties= \"Excel 8.0;HDR=Yes;IMEX=2\"");
                else if (Path.GetExtension(path) == ".xlsx" || Path.GetExtension(path) == ".XLSX")
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");

                oledbConn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oledbConn;
        }

        private IList<DetalheFaturaEmailPenso> ExtractContaExcel(OleDbConnection oledbConn, string referencia)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [EXPORT$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            IList<DetalheFaturaEmailPenso> dsDetalheFaturaPenso = new List<DetalheFaturaEmailPenso>();

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                DetalheFaturaEmailPenso leitura = new DetalheFaturaEmailPenso();

                // compor todos os campos da class
                // leitura.Id = 

                leitura.Usuario = s["USUARIO"].ToString().Trim();
                leitura.NomeExibicao = s["NOME"].ToString().Trim();
                leitura.Status = s["STATUS"].ToString().Trim();
                leitura.PossuiConnect = s["CONNECT"].ToString() == "" ? 0 : 1;
                leitura.Referencia = referencia;
                leitura.CCusto = s["CCUSTO"].ToString().Trim();
                leitura.Valor = 0;

                dsDetalheFaturaPenso.Add(leitura);
            });

            return dsDetalheFaturaPenso;
        }

        public string ImportarDados(string path, string referencia)
        {
            IList<DetalheFaturaEmailPenso> objFaturaDetalhada = new List<DetalheFaturaEmailPenso>();
            try
            {
                List<string> refer = this.GetReferencia();

                if (refer != null)
                {
                    refer.ForEach(r =>
                    {
                        if (r.ToString() == referencia)
                            throw new Exception("Já existem dados da fatura que está sendo importada. Faça a exclusão antes de importar.");
                    });
                }

                OleDbConnection oledbConn = OpenConnection(path);
                if (oledbConn.State == ConnectionState.Open)
                {
                    objFaturaDetalhada = ExtractContaExcel(oledbConn, referencia);
                    oledbConn.Close();
                }

                DataTable dt = ToDataTable(objFaturaDetalhada);
                dt.Columns.Remove("Id");

                // Gravando no banco de dados
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("POSTDETALHEFATURAEMAILPENSO"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DETALHEFATURAEMAILPENSO", dt);
                        cmd.CommandTimeout = 300;
                        con.Open();
                        string retorno = cmd.ExecuteNonQuery().ToString();
                        con.Close();

                        return retorno;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable ToDataTable<T>(IList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public List<string> GetReferencia()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("GETREFERENCIADETALHEFATURAEMAILPENSO"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        con.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        List<string> retorno = new List<string>();

                        dt.AsEnumerable().ToList().ForEach(f =>
                        {
                            retorno.Add(f["Referencia"].ToString());
                        });
                        con.Close();

                        return retorno.Count == 0 ? null : retorno;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
