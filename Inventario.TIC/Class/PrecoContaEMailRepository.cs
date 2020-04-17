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
    public class PrecoContaEMailRepository
    {
        public string Add(PrecoContaEMail precoContaEMail)
        {
            try
            {
                if (precoContaEMail.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTPRECOCONTAEMAIL",
                    };

                    command.Parameters.AddWithValue("@TipoConta", precoContaEMail.TipoConta);
                    command.Parameters.AddWithValue("@ValorUnitSemImposto", precoContaEMail.ValorUnitSemImposto);
                    command.Parameters.AddWithValue("@CargaTributaria", precoContaEMail.CargaTributaria);
                    command.Parameters.AddWithValue("@ValorUnitComImposto", precoContaEMail.ValorUnitComImposto);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(precoContaEMail.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(PrecoContaEMail precoContaEMail)
        {
            try
            {
                if (precoContaEMail.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTPRECOCONTAEMAIL",
                    };

                    command.Parameters.AddWithValue("@TipoConta", precoContaEMail.TipoConta);
                    command.Parameters.AddWithValue("@ValorUnitSemImposto", precoContaEMail.ValorUnitSemImposto);
                    command.Parameters.AddWithValue("@CargaTributaria", precoContaEMail.CargaTributaria);
                    command.Parameters.AddWithValue("@ValorUnitComImposto", precoContaEMail.ValorUnitComImposto);
                    command.Parameters.AddWithValue("@Id", precoContaEMail.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(precoContaEMail.GetErros());
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
                        CommandText = "DELETEPRECOCONTAEMAIL",
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

        public List<PrecoContaEMail> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var precoContaEMail = connection.Query<PrecoContaEMail>("GETPRECOCONTAEMAIL", null, commandType: CommandType.StoredProcedure).ToList();
                    return precoContaEMail;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
