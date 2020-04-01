using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TermoCelularUsuarioRepository
    {
        public string Add(TermoCelularUsuarios termoUsuario)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "POSTTERMOCELULARUSUARIO",
                };

                command.Parameters.AddWithValue("@TermoCelularId", termoUsuario.TermoCelularId);
                command.Parameters.AddWithValue("@UsuarioId", termoUsuario.UsuarioId);

                command.Connection.Open();
                string retorno = command.ExecuteScalar().ToString();

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
