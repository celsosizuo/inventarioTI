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
    public class SoftwareRepository
    {
        public string Add(Software software)
        {
            try
            {
                if (software.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTSOFTWARE",
                    };

                    command.Parameters.AddWithValue("@Nome", software.Nome);
                    command.Parameters.AddWithValue("@Fabricante", software.Fabricante);
                    command.Parameters.AddWithValue("@Versao", software.Versao);
                    command.Parameters.AddWithValue("@NomeTecnico", software.NomeTecnico);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(software.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Software software)
        {
            try
            {
                if (software.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTSOFTWARE",
                    };

                    command.Parameters.AddWithValue("@Nome", software.Nome);
                    command.Parameters.AddWithValue("@Fabricante", software.Fabricante);
                    command.Parameters.AddWithValue("@Versao", software.Versao);
                    command.Parameters.AddWithValue("@NomeTecnico", software.NomeTecnico);
                    command.Parameters.AddWithValue("@Id", software.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(software.GetErros());
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
                        CommandText = "DELETESOFTWARE",
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

        public List<Software> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var softwares = connection.Query<Software>("GETSOFTWARES", null, commandType: CommandType.StoredProcedure).ToList();
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
