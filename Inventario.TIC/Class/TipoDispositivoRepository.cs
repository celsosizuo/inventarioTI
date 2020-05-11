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
    public class TipoDispositivoRepository
    {
        public string Add(TipoDispositivo tipoDispositivo)
        {
            try
            {
                if (tipoDispositivo.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTTIPODISPOSITIVO",
                    };

                    command.Parameters.AddWithValue("@Tipo", tipoDispositivo.Tipo);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(tipoDispositivo.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TipoDispositivo tipoDispositivo)
        {
            try
            {
                if (tipoDispositivo.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTTIPODISPOSITIVO",
                    };

                    command.Parameters.AddWithValue("@Tipo", tipoDispositivo.Tipo);
                    command.Parameters.AddWithValue("@Id", tipoDispositivo.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(tipoDispositivo.GetErros());
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
                        CommandText = "DELETETIPODISPOSITIVO",
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

        public List<TipoDispositivo> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var tipoDispositivos = connection.Query<TipoDispositivo>("GETTIPODISPOSITIVO", null, commandType: CommandType.StoredProcedure).ToList();
                    return tipoDispositivos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
