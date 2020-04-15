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
    public class ServicosFatura
    {
        public int Id { get; set; }
        public string LinhaNumero { get; set; }
        public string TipoServico { get; set; }
        public string DescricaoServico { get; set; }
        public string Referencia { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal Valor { get; set; }

        public ServicosFatura()
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

        private IList<ServicosFatura> ExtractServicoExcel(OleDbConnection oledbConn)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Demonstrativo dos Serviços$]";
            oleda = new OleDbDataAdapter(cmd);
            // oleda.Fill(dsConta, "LeituraFaturaDetalhada");
            oleda.Fill(dtConta);

            IList<ServicosFatura> dsServicosFatura = new List<ServicosFatura>();

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                ServicosFatura leitura = new ServicosFatura();
                leitura.LinhaNumero = s["Celular"] != DBNull.Value ? s["Celular"].ToString() : null;
                leitura.TipoServico = s["Tipo do Serviço"] != DBNull.Value ? s["Tipo do Serviço"].ToString() : null;
                leitura.DescricaoServico = s["Descrição do Serviço"] != DBNull.Value ? s["Descrição do Serviço"].ToString() : null;
                leitura.Referencia = s["Mês/Ano de Referência"] != DBNull.Value ? s["Mês/Ano de Referência"].ToString() : null;

                if (s["Data Inicial"] != DBNull.Value)
                    leitura.DataInicio = Convert.ToDateTime(s["Data Inicial"].ToString());
                else
                    leitura.DataInicio = null;

                if (s["Data Final"] != DBNull.Value)
                    leitura.DataFim = Convert.ToDateTime(s["Data Final"].ToString());
                else
                    leitura.DataFim = null;

                leitura.Valor = Convert.ToDecimal(s["Valor em reais"] != DBNull.Value ? s["Valor em reais"].ToString() : null);

                dsServicosFatura.Add(leitura);
            });

            return dsServicosFatura;
        }

        public string ImportarDados(string path)
        {
            IList<ServicosFatura> objServicosFatura = new List<ServicosFatura>();
            try
            {
                OleDbConnection oledbConn = OpenConnection(path);
                if (oledbConn.State == ConnectionState.Open)
                {
                    objServicosFatura = ExtractServicoExcel(oledbConn);
                    oledbConn.Close();
                }

                List<string> referencia = this.GetReferencia();

                referencia.ForEach(r =>
                {
                    if (r.ToString() == objServicosFatura[0].Referencia)
                        throw new Exception("Já existem dados da fatura que está sendo importada. Faça a exclusão antes de importar.");
                });


                DataTable dt = ToDataTable(objServicosFatura);
                dt.Columns.Remove("Id");

                // Gravando no banco de dados
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("POSTSERVICOSFATURA"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@SERVICOSFATURA", dt);
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
                    using (SqlCommand cmd = new SqlCommand("GETREFERENCIASERVICOSFATURA"))
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

        public string ExcluirServicosExcel(string referencia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETEDETALHEFATURA"))
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
    }
}
