using Dapper;
using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class AparelhoRepository
    {
        public string Add(Aparelho aparelho)
        {
            try
            {
                if (aparelho.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTAPARELHO",
                    };

                    command.Parameters.AddWithValue("@Marca", aparelho.Marca);
                    command.Parameters.AddWithValue("@Modelo", aparelho.Modelo);
                    command.Parameters.AddWithValue("@Imei1", aparelho.Imei1);
                    command.Parameters.AddWithValue("@Imei2", aparelho.Imei2);
                    command.Parameters.AddWithValue("@Valor", aparelho.Valor);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(aparelho.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Aparelho aparelho)
        {
            try
            {
                if (aparelho.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTAPARELHO",
                    };

                    command.Parameters.AddWithValue("@Marca", aparelho.Marca);
                    command.Parameters.AddWithValue("@Modelo", aparelho.Modelo);
                    command.Parameters.AddWithValue("@Imei1", aparelho.Imei1);
                    command.Parameters.AddWithValue("@Imei2", aparelho.Imei2);
                    command.Parameters.AddWithValue("@Valor", aparelho.Valor);
                    command.Parameters.AddWithValue("@Id", aparelho.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(aparelho.GetErros());
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
                        CommandText = "DELETEAPARELHO",
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

        public List<Aparelho> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var aparelhos = connection.Query<Aparelho>("GETAPARELHO", null, commandType: CommandType.StoredProcedure).ToList();
                    return aparelhos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
