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
    public class LinhaRepository
    {
        public string Add(Linha linha)
        {
            try
            {
                if (linha.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTLINHA",
                    };

                    command.Parameters.AddWithValue("@Numero", linha.Numero);
                    command.Parameters.AddWithValue("@Chip", linha.Chip);
                    command.Parameters.AddWithValue("@Pin", linha.Pin);
                    command.Parameters.AddWithValue("@Puk", linha.Puk);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(linha.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Linha linha)
        {
            try
            {
                if (linha.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTLINHA",
                    };

                    command.Parameters.AddWithValue("@Numero", linha.Numero);
                    command.Parameters.AddWithValue("@Chip", linha.Chip);
                    command.Parameters.AddWithValue("@Pin", linha.Pin);
                    command.Parameters.AddWithValue("@Puk", linha.Puk);
                    command.Parameters.AddWithValue("@Id", linha.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(linha.GetErros());
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
                        CommandText = "DELETELINHA",
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

        public List<Linha> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var softwares = connection.Query<Linha>("GETLINHA", null, commandType: CommandType.StoredProcedure).ToList();
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
