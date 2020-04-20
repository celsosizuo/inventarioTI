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
    public class DetalheFaturaImpressoras
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public string Ativo { get; set; }
        public string Ip { get; set; }
        public string Impressora { get; set; }
        public string Tipo { get; set; }
        public string CCusto { get; set; }
        public int TotalPessoasPorImpressora { get; set; }
        public int TotalPessoasPorSetor { get; set; }
        public decimal PorcentagemCentroDeCusto { get; set; }
        public decimal ValorPorCentroDeCusto { get; set; }
        public decimal QtdePagImpressaPorCentroDeCusto { get; set; }

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

        private IList<DetalheFaturaImpressoras> ExtractContaExcel(OleDbConnection oledbConn)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [RATEIO$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            IList<DetalheFaturaImpressoras> dsDetalheFatura = new List<DetalheFaturaImpressoras>();

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                DetalheFaturaImpressoras leitura = new DetalheFaturaImpressoras();

                // compor todos os campos da class
                // leitura.Id = 
                leitura.Ativo = s["ATIVO"].ToString();
                leitura.Ip = s["Ip"].ToString();
                leitura.Impressora = s["Impressora"].ToString();
                leitura.Tipo = s["Tipo"].ToString();
                leitura.CCusto = s["CENTRO_DE_CUSTO"].ToString();
                leitura.TotalPessoasPorImpressora = int.Parse(s["TOTAL_PESSOAS_POR_IMPRESSORA"].ToString());
                leitura.TotalPessoasPorSetor = int.Parse(s["TOTAL_PESSOAS_POR_SETOR"].ToString());
                leitura.PorcentagemCentroDeCusto = decimal.Parse(s["%_POR_CENTRO_CUSTO"].ToString());
                leitura.ValorPorCentroDeCusto = decimal.Parse(s["VLT_POR_CENTRO_CUSTO"].ToString());
                leitura.QtdePagImpressaPorCentroDeCusto = decimal.Parse(s["QTD_PAG_IMPRESSA_POR_CC"].ToString());
                leitura.Referencia = s["MÊS_REFERÊNCIA"].ToString();

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
            cmd.CommandText = "SELECT * FROM [RATEIO$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            return dtConta;
        }

        public string ImportarDados(string path)
        {
            IList<DetalheFaturaImpressoras> objFaturaDetalhada = new List<DetalheFaturaImpressoras>();
            try
            {
                List<string> refer = this.GetReferencia();

                if (refer != null)
                {
                    refer.ForEach(r =>
                    {
                    if (r.ToString() == objFaturaDetalhada[0].Referencia)
                            throw new Exception("Já existem dados da fatura que está sendo importada. Faça a exclusão antes de importar.");
                    });
                }

                OleDbConnection oledbConn = OpenConnection(path);
                if (oledbConn.State == ConnectionState.Open)
                {
                    objFaturaDetalhada = ExtractContaExcel(oledbConn);
                    oledbConn.Close();
                }

                DataTable dt = ToDataTable(objFaturaDetalhada);
                dt.Columns.Remove("Id");

                // Gravando no banco de dados
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("POSTDETALHEFATURAIMPRESSORAS"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DETALHEFATURAIMPRESSORAS", dt);
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
                    using (SqlCommand cmd = new SqlCommand("DELETEDETALHEFATURAIMPRESSORAS"))
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
                    using (SqlCommand cmd = new SqlCommand("GETREFERENCIADETALHEFATURAIMPRESSORAS"))
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
