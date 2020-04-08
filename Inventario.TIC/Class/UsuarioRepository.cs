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
    public class UsuarioRepository
    {
        public List<Usuario> Sincronizar()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var usuarios = connection.Query<Usuario>("POSTUSUARIOS", null, commandType: CommandType.StoredProcedure).ToList();
                    return usuarios;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Add(Usuario usuario)
        {
            try
            {
                if (usuario.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTUSUARIO",
                    };

                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Chapa", usuario.Chapa);
                    command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                    command.Parameters.AddWithValue("@Terceiro", usuario.Terceiro);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(usuario.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                if (usuario.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTUSUARIO",
                    };

                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Chapa", usuario.Chapa);
                    command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                    command.Parameters.AddWithValue("@Terceiro", usuario.Terceiro);
                    command.Parameters.AddWithValue("@Id", usuario.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(usuario.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PathDataDevolucao(TermoCelular termoCelular)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PATHTERMOCELULARUSUARIO",
                };

                command.Parameters.AddWithValue("@TermoCelularId", termoCelular.Id);
                command.Parameters.AddWithValue("@UsuarioId", termoCelular.Usuario[0].Id);
                command.Parameters.AddWithValue("@DataDevolucao", termoCelular.Usuario[0].DataDevolucao);
                command.Parameters.AddWithValue("@Motivo", termoCelular.Usuario[0].Motivo);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
