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
    public class HistoricoUsuariosComputadoresRepository
    {
        public void Add(HistoricoUsuariosComputadores historico)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "POSTHISTORICOUSUARIOCOMPUTADORES",
                };

                command.Parameters.AddWithValue("@ComputadoresId", historico.ComputadoresId);
                command.Parameters.AddWithValue("@Usuario", historico.Usuario);
                command.Parameters.AddWithValue("@DataMudanca", historico.DataMudanca);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistoricoUsuariosComputadores> Get(int computadoresId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@COMPUTADORESID", computadoresId);

                    var softwares = connection.Query<HistoricoUsuariosComputadores>("GETHISTORICOUSUARIOCOMPUTADORES", parametros, commandType: CommandType.StoredProcedure).ToList();

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
