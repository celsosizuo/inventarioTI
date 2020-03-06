using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class NotaFiscalRepository
    {
        public string Add(NotaFiscal notaFiscal)
        {
            try
            {
                if (notaFiscal.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTNOTAFISCAL",
                    };

                    command.Parameters.AddWithValue("@NumNF", notaFiscal.NumNF);
                    command.Parameters.AddWithValue("@Fornecedor", notaFiscal.Fornecedor);
                    command.Parameters.AddWithValue("@Data", notaFiscal.Data);
                    command.Parameters.AddWithValue("@Empresa", notaFiscal.Empresa);
                    command.Parameters.AddWithValue("@Link", notaFiscal.Link);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(notaFiscal.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(NotaFiscal notaFiscal)
        {
            try
            {
                if (notaFiscal.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTNOTAFISCAL",
                    };

                    command.Parameters.AddWithValue("@NumNF", notaFiscal.NumNF);
                    command.Parameters.AddWithValue("@Fornecedor", notaFiscal.Fornecedor);
                    command.Parameters.AddWithValue("@Data", notaFiscal.Data);
                    command.Parameters.AddWithValue("@Empresa", notaFiscal.Empresa);
                    command.Parameters.AddWithValue("@Link", notaFiscal.Link);
                    command.Parameters.AddWithValue("@Id", notaFiscal.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(notaFiscal.GetErros());
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
                        CommandText = "DELETENOTAFISCAL",
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

        public List<NotaFiscal> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var notasFiscais = connection.Query<NotaFiscal>("GETNOTASFISCAIS", null, commandType: CommandType.StoredProcedure).ToList();
                    return notasFiscais;
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public NotaFiscal GetById(string numNF)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var notasFiscais = connection.Query<NotaFiscal>("GETNOTASFISCAIS", null, commandType: CommandType.StoredProcedure).ToList();
                    NotaFiscal nf = notasFiscais.FirstOrDefault(n => n.NumNF == numNF);

                    return nf;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
