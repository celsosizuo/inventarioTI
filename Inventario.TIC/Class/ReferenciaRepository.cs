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
    public class ReferenciaRepository
    {
        public string Add(Referencia referencia)
        {
            try
            {
                if (referencia.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTREFERENCIA",
                    };

                    command.Parameters.AddWithValue("@REF", referencia.Ref);
                    command.Parameters.AddWithValue("@DATAINICIO", referencia.DataInicio);
                    command.Parameters.AddWithValue("@DATAFIM", referencia.DataFim);
                    command.Parameters.AddWithValue("@STATUS", referencia.Status);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(referencia.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Referencia referencia)
        {
            try
            {
                if (referencia.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTREFERENCIA",
                    };

                    command.Parameters.AddWithValue("@REF", referencia.Ref);
                    command.Parameters.AddWithValue("@DATAINICIO", referencia.DataInicio);
                    command.Parameters.AddWithValue("@DATAFIM", referencia.DataFim);
                    command.Parameters.AddWithValue("@STATUS", referencia.Status);
                    command.Parameters.AddWithValue("@ID", referencia.Id);

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
                        CommandText = "DELETEREFERENCIA",
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

        public List<Referencia> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var referencia = connection.Query<Referencia>("GETREFERENCIA", null, commandType: CommandType.StoredProcedure).ToList();
                    return referencia;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetReferenciaStatus()
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GETREFERENCIASTATUS"
                };

                command.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);

                DataRow row;
                row = dt.NewRow();

                row["CODIGO"] = 0;
                row["DESCRICAO"] = "";

                dt.Rows.InsertAt(row, 0);

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
