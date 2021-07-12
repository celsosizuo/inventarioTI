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
    public class FornecedorRepository
    {
        public string Add(Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTFORNECEDOR",
                    };

                    command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                    command.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
                    command.Parameters.AddWithValue("@DataInicioContrato", fornecedor.DataInicioContrato);
                    command.Parameters.AddWithValue("@DataFimContrato", fornecedor.DataFimContrato);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(fornecedor.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTFORNECEDOR",
                    };

                    command.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                    command.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
                    command.Parameters.AddWithValue("@DataInicioContrato", fornecedor.DataInicioContrato);
                    command.Parameters.AddWithValue("@DataFimContrato", fornecedor.DataFimContrato);
                    command.Parameters.AddWithValue("@ID", fornecedor.Id);

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
                        CommandText = "DELETEFORNECEDOR",
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

        public List<Fornecedor> Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var fornecedor = connection.Query<Fornecedor>("GETFORNECEDOR", null, commandType: CommandType.StoredProcedure).ToList();
                    return fornecedor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
