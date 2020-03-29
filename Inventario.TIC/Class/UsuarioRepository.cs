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
    }
}
