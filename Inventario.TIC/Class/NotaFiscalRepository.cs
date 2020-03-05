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
    public class NotaFiscalRepository
    {
        public string Add(NotaFiscal notaFiscal)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return "";
        }

        public void Update(NotaFiscal notaFiscal)
        {

        }

        public void Delete(int id)
        {

        }

        public List<NotaFiscal> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var notasFiscais = connection.Query<NotaFiscal>("GETNOTASFISCAIS", null, commandType: CommandType.StoredProcedure).ToList();
                    return notasFiscais;
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
