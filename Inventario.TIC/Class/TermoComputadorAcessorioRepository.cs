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
    public class TermoComputadorAcessorioRepository
    {
        public string Add(TermoComputadorAcessorio acessorio)
        {
            try
            {
                if (acessorio.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTTERMOCOMPUTADORACESSORIO",
                    };

                    command.Parameters.AddWithValue("@TermoComputadorId", acessorio.TermoComputadorId);
                    command.Parameters.AddWithValue("@NomeAcessorio", acessorio.NomeAcessorio);
                    command.Parameters.AddWithValue("@Valor", acessorio.Valor);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(acessorio.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TermoComputadorAcessorio acessorio)
        {
            try
            {
                if (acessorio.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTTERMOCOMPUTADORACESSORIO",
                    };

                    command.Parameters.AddWithValue("@TermoComputadorId", acessorio.TermoComputadorId);
                    command.Parameters.AddWithValue("@NomeAcessorio", acessorio.NomeAcessorio);
                    command.Parameters.AddWithValue("@Valor", acessorio.Valor);
                    command.Parameters.AddWithValue("@Id", acessorio.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(acessorio.GetErros());
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
                        CommandText = "DELETETERMOCOMPUTADORACESSORIO",
                    };

                    command.Parameters.AddWithValue("@Id", id);

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

        public List<TermoComputadorAcessorio> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var acessorios = connection.Query<TermoComputadorAcessorio>("GETTERMOCOMPUTADORACESSORIO", null, commandType: CommandType.StoredProcedure).ToList();
                    return acessorios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
