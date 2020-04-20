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
    public class GestorRepository
    {
        public string Add(Gestor gestor)
        {
            try
            {
                if (gestor.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTGESTOR",
                    };

                    command.Parameters.AddWithValue("@Nome", gestor.Nome);
                    command.Parameters.AddWithValue("@Status", gestor.Status);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;

                }
                else
                {
                    throw new Exception(gestor.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Gestor gestor)
        {
            try
            {
                if (gestor.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTGESTOR",
                    };

                    command.Parameters.AddWithValue("@Nome", gestor.Nome);
                    command.Parameters.AddWithValue("@Status", gestor.Status);
                    command.Parameters.AddWithValue("@Id", gestor.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(gestor.GetErros());
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
                        CommandText = "DELETEGESTOR",
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

        public List<Gestor> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var gestores = connection.Query<Gestor>("GETGESTOR", null, commandType: CommandType.StoredProcedure).ToList();
                    return gestores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
