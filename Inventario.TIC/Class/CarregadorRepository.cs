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
    public class CarregadorRepository
    {
        public string Add(Carregador carregador)
        {
            try
            {
                if (carregador.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTCARREGADOR",
                    };

                    command.Parameters.AddWithValue("@Marca", carregador.Marca);
                    command.Parameters.AddWithValue("@NumSerie", carregador.NumSerie);
                    command.Parameters.AddWithValue("@Valor", carregador.Valor);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(carregador.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Carregador carregador)
        {
            try
            {
                if (carregador.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTCARREGADOR",
                    };

                    command.Parameters.AddWithValue("@Marca", carregador.Marca);
                    command.Parameters.AddWithValue("@NumSerie", carregador.NumSerie);
                    command.Parameters.AddWithValue("@Valor", carregador.Valor);
                    command.Parameters.AddWithValue("@Id", carregador.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(carregador.GetErros());
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
                        CommandText = "DELETECARREGADOR",
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

        public List<Carregador> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var carregadores = connection.Query<Carregador>("GETCARREGADOR", null, commandType: CommandType.StoredProcedure).ToList();
                    return carregadores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
