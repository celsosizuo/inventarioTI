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
    public class TipoImpressaoRepository
    {
        public string Add(TipoImpressao tipoImpressao)
        {
            try
            {
                if (tipoImpressao.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTTIPOIMPRESSAO",
                    };

                    command.Parameters.AddWithValue("@TIPOIMPRESSAO", tipoImpressao.Descricao);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(tipoImpressao.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TipoImpressao tipoImpressao)
        {
            try
            {
                if (tipoImpressao.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTTIPOIMPRESSAO",
                    };

                    command.Parameters.AddWithValue("@TIPOIMPRESSAO", tipoImpressao.Descricao);
                    command.Parameters.AddWithValue("@ID", tipoImpressao.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
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
                        CommandText = "DELETETIPOIMPRESSAO",
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

        public List<TipoImpressao> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var tipoImpressao = connection.Query<TipoImpressao>("GETTIPOIMPRESSAO", null, commandType: CommandType.StoredProcedure).ToList();
                    return tipoImpressao;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
