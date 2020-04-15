using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Inventario.TIC.Class
{
    public class DetalheFatura : AbstractValidator<DetalheFatura>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string LinhaNumero { get; set; }
        public string SecaoChamada { get; set; }
        public string Referencia { get; set; }
        public string DescricaoChamada { get; set; }
        public DateTime? DataHoraChamada { get; set; }
        public string TipoChamada { get; set; }
        public string CidadeOrigem { get; set; }
        public string UfOrigem { get; set; }
        public string CidadeDestino { get; set; }
        public string UfDestino { get; set; }
        public string NumeroChamado { get; set; }
        public string Tarifa { get; set; }
        public string Duracao { get; set; }
        public decimal? Quantidade { get; set; }
        public string Contratados { get; set; }
        public string Utilizados { get; set; }
        public string Excedentes { get; set; }
        public string Unidade { get; set; }
        public decimal Valor { get; set; }

        public DetalheFatura()
        {
            ValidationResult = new ValidationResult();
        }

        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarLinha();
        }

        private void ValidarLinha()
        {
            RuleFor(a => a.LinhaNumero).NotEmpty().WithMessage("- Campo Número da linha é obrigatório");
        }

        private void ValidarReferencia()
        {
            RuleFor(a => a.Referencia).NotEmpty().WithMessage("- Campo referência é obrigatório");
        }

        private void ValidarDescricaoChamada()
        {
            RuleFor(a => a.DescricaoChamada).NotEmpty().WithMessage("- Campo Descrição é obrigatório");
        }

        private void ValidarValor()
        {
            RuleFor(a => a.Valor).NotEmpty().WithMessage("- Campo valor é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

        private OleDbConnection OpenConnection(string path)
        {
            OleDbConnection  oledbConn = null;
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

        private IList<DetalheFatura> ExtractContaExcel(OleDbConnection oledbConn)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet dsConta = new DataSet();
            DataTable dtConta = new DataTable();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Demonstrativo da Fatura 1$]";
            oleda = new OleDbDataAdapter(cmd);
            // oleda.Fill(dsConta, "LeituraFaturaDetalhada");
            oleda.Fill(dtConta);

            IList<DetalheFatura> dsDetalheFatura = new List<DetalheFatura>();

            dtConta.AsEnumerable().ToList().ForEach(s =>
            {
                DetalheFatura leitura = new DetalheFatura();
                leitura.LinhaNumero = s["Celular"] != DBNull.Value ? s["Celular"].ToString() : null;
                leitura.SecaoChamada = s["Seção da Chamada"] != DBNull.Value ? s["Seção da Chamada"].ToString() : null;
                leitura.Referencia = s["Mês/Ano de Referência"] != DBNull.Value ? s["Mês/Ano de Referência"].ToString() : null;
                leitura.DescricaoChamada = s["Descrição da Chamada"] != DBNull.Value ? s["Descrição da Chamada"].ToString() : null;

                if (s["Data da Chamada"] != DBNull.Value && s["Hora da Chamada"] != DBNull.Value)
                {
                    DateTime dataHoraChamada = Convert.ToDateTime(s["Data da Chamada"].ToString() + " " + s["Hora da Chamada"].ToString());
                    leitura.DataHoraChamada = dataHoraChamada;
                }
                else
                    leitura.DataHoraChamada = null;

                leitura.TipoChamada = s["Tipo da Chamada"] != DBNull.Value ? s["Tipo da Chamada"].ToString() : null;
                leitura.CidadeOrigem = s["Cidade de Origem"] != DBNull.Value ? s["Cidade de Origem"].ToString() : null;
                leitura.UfOrigem = s["UF de Origem"] != DBNull.Value ? s["UF de Origem"].ToString() : null;
                leitura.CidadeDestino = s["Cidade de Destino"] != DBNull.Value ? s["Cidade de Destino"].ToString() : null;
                leitura.UfDestino = s["UF de Destino"] != DBNull.Value ? s["UF de Destino"].ToString() : null;
                leitura.NumeroChamado = s["Nº Chamado"] != DBNull.Value ? s["Nº Chamado"].ToString() : null;
                leitura.Tarifa = s["Tarifa"] != DBNull.Value ? s["Tarifa"].ToString() : null;
                leitura.Duracao = s["Duração"] != DBNull.Value ? s["Duração"].ToString().Replace("h", "").Replace("m", "").Replace("s", "").ToString() : null;

                if (s["Quantidade"] != DBNull.Value)
                    leitura.Quantidade = Convert.ToDecimal(s["Quantidade"].ToString().Replace(".", ","));
                else
                    leitura.Quantidade = null;

                leitura.Contratados = s["Contratados"] != DBNull.Value ? s["Contratados"].ToString() : null;
                leitura.Utilizados = s["Utilizados"] != DBNull.Value ? s["Utilizados"].ToString() : null;
                leitura.Excedentes = s["Excedentes"] != DBNull.Value ? s["Excedentes"].ToString() : null;
                leitura.Unidade = s["Unidade"] != DBNull.Value ? s["Unidade"].ToString() : null;
                leitura.Valor = Convert.ToDecimal(s["Valor"] != DBNull.Value ? s["Valor"].ToString() : null);

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
            cmd.CommandText = "SELECT * FROM [Demonstrativo da Fatura 1$]";
            oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(dtConta);

            return dtConta;
        }

        public string ImportarDados(string path)
        {
            IList<DetalheFatura> objFaturaDetalhada = new List<DetalheFatura>();
            try
            {
                OleDbConnection oledbConn = OpenConnection(path);
                if (oledbConn.State == ConnectionState.Open)
                {
                    objFaturaDetalhada = ExtractContaExcel(oledbConn);
                    oledbConn.Close();
                }

                List<string> referencia = this.GetReferencia();

                referencia.ForEach(r =>
                {
                    if (r.ToString() == objFaturaDetalhada[0].Referencia)
                        throw new Exception("Já existem dados da fatura que está sendo importada. Faça a exclusão antes de importar.");
                });


                DataTable dt = ToDataTable(objFaturaDetalhada);
                dt.Columns.Remove("Id");

                // Gravando no banco de dados
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("POSTDETALHEFATURA"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DETALHEFATURA", dt);
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

        public List<string> GetReferencia()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("GETREFERENCIADETALHEFATURA"))
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

        public string Add(DetalheFatura detalheFatura)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "POSTDETALHEFATURAUNICO",
                };

                command.Parameters.AddWithValue("@LinhaNumero", detalheFatura.LinhaNumero);
                command.Parameters.AddWithValue("@SecaoChamada", detalheFatura.SecaoChamada);
                command.Parameters.AddWithValue("@Referencia", detalheFatura.Referencia);
                command.Parameters.AddWithValue("@DescricaoChamada", detalheFatura.DescricaoChamada);
                command.Parameters.AddWithValue("@Unidade", detalheFatura.Unidade);
                command.Parameters.AddWithValue("@Valor", detalheFatura.Valor);

                command.Connection.Open();
                string retorno = command.ExecuteScalar().ToString();

                return retorno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(DetalheFatura detalheFatura)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PUTDETALHEFATURAUNICO",
                };

                command.Parameters.AddWithValue("@LinhaNumero", detalheFatura.LinhaNumero);
                command.Parameters.AddWithValue("@SecaoChamada", detalheFatura.SecaoChamada);
                command.Parameters.AddWithValue("@Referencia", detalheFatura.Referencia);
                command.Parameters.AddWithValue("@DescricaoChamada", detalheFatura.DescricaoChamada);
                command.Parameters.AddWithValue("@Unidade", detalheFatura.Unidade);
                command.Parameters.AddWithValue("@Valor", detalheFatura.Valor);
                command.Parameters.AddWithValue("@Id", detalheFatura.Id);

                command.Connection.Open();
                command.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DetalheFatura> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var gestores = connection.Query<DetalheFatura>("GETDETALHEFATURAUNICO", null, commandType: CommandType.StoredProcedure).ToList();
                    return gestores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "DELETEDETALHEFATURAUNICO",
                    };

                    command.Parameters.AddWithValue("@ID", id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception("Favor selecionar um registro para exclusão");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

