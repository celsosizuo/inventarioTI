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
    public class AccessRepository
    {
        public string Add(Access acesso)
        {
            try
            {
                if (acesso.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTACCESS",
                    };

                    command.Parameters.AddWithValue("@Descricao", acesso.Descricao);
                    command.Parameters.AddWithValue("@EnderecoAcesso", acesso.EnderecoAcesso);
                    command.Parameters.AddWithValue("@Observacao", acesso.Observacao);
                    command.Parameters.AddWithValue("@Usuario", acesso.Usuario);
                    command.Parameters.AddWithValue("@Senha", acesso.Senha);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(acesso.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Access acesso)
        {
            try
            {
                if (acesso.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTACCESS",
                    };

                    command.Parameters.AddWithValue("@Descricao", acesso.Descricao);
                    command.Parameters.AddWithValue("@EnderecoAcesso", acesso.EnderecoAcesso);
                    command.Parameters.AddWithValue("@Observacao", acesso.Observacao);
                    command.Parameters.AddWithValue("@Usuario", acesso.Usuario);
                    command.Parameters.AddWithValue("@Senha", acesso.Senha);
                    command.Parameters.AddWithValue("@Id", acesso.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(acesso.GetErros());
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
                        CommandText = "DELETEACCESS",
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

        public List<Access> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var softwares = connection.Query<Access>("GETACCESS", null, commandType: CommandType.StoredProcedure).ToList();
                    return softwares;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
