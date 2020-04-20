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
    public class DetalheFaturaEMail
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Ativo { get; set; }
        public string Plano { get; set; }
        public string Departamento { get; set; }
        public string CCusto { get; set; }
        public string Politica { get; set; }
        public string Referencia { get; set; }
        public string TipoRegistro { get; set; }
        public decimal Valor { get; set; }

        public DetalheFaturaEMail()
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

        private IList<DetalheFaturaEMail> ExtractContaExcel(OleDbConnection oledbConn, string referencia)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [EXCHANGE$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            IList<DetalheFaturaEMail> dsDetalheFatura = new List<DetalheFaturaEMail>();

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                DetalheFaturaEMail leitura = new DetalheFaturaEMail();

                // compor todos os campos da class
                // leitura.Id = 
                leitura.Tipo = s["Tipo"].ToString();
                leitura.Usuario = s["Usuario"].ToString();
                leitura.Nome = s["Nome"].ToString();
                leitura.Ativo = s["Ativo"].ToString();
                leitura.Plano = s["Plano"].ToString();
                leitura.Departamento = s["Departamento"] == null ? "" : s["Departamento"].ToString();
                leitura.CCusto = s["Cidade"] == null ? "" : s["Cidade"].ToString();
                leitura.Politica = null;
                leitura.Referencia = referencia;
                leitura.TipoRegistro = "Exchange";

                dsDetalheFatura.Add(leitura);
            });

            dtConta.Clear();
            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [MAIEX$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                DetalheFaturaEMail leitura = new DetalheFaturaEMail();

                // compor todos os campos da class
                // leitura.Id = 
                leitura.Usuario = s["Usuário"].ToString();
                leitura.Tipo = s["Tipo"].ToString();
                leitura.Nome = s["Nome"].ToString();
                leitura.Politica = s["Política"].ToString();
                leitura.Ativo = null;
                leitura.Plano = s["Perfil"].ToString();
                leitura.Departamento = s["Departamento"] == null ? "" : s["Departamento"].ToString();
                leitura.CCusto = null;
                leitura.Referencia = referencia;
                leitura.TipoRegistro = "Maiex";

                dsDetalheFatura.Add(leitura);
            });

            return dsDetalheFatura;
        }

        private DataTable ExtractDataTableContaExcel(OleDbConnection oledbConn)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [EXCHANGE$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            return dtConta;
        }

        public string ImportarDados(string path, string referencia)
        {
            IList<DetalheFaturaEMail> objFaturaDetalhada = new List<DetalheFaturaEMail>();
            try
            {
                List<string> refer = this.GetReferencia();

                if(refer != null)
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
                    using (SqlCommand cmd = new SqlCommand("POSTDETALHEFATURAEMAIL"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DETALHEFATURAEMAIL", dt);
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

        public string ExcluirContaExcel(string referencia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETEDETALHEFATURAEMAIL"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@REFERENCIA", referencia);
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

        public List<string> GetReferencia()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("GETREFERENCIADETALHEFATURAEMAIL"))
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
