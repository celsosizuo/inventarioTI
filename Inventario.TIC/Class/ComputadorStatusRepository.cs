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
    public class ComputadorStatusRepository
    {
        public List<ComputadorStatus> GetComputadorStatuses()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
            {
                List<ComputadorStatus> status = new List<ComputadorStatus>();
                ComputadorStatus cs = new ComputadorStatus();

                status = connection.Query<ComputadorStatus>("GETCOMPUTADORSTATUS", null, commandType: CommandType.StoredProcedure).ToList();
                status.Insert(0, cs);
                
                return status;
            }
        }
    }
}
