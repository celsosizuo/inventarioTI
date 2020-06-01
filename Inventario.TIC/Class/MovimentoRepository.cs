using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class MovimentoRepository
    {
        public string Add(Movimentos movimento)
        {
            try
            {
                if (movimento.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTMOVIMENTOSESTOQUE",
                    };

                    command.Parameters.AddWithValue("@ProdutoId", movimento.Produto.Id);
                    command.Parameters.AddWithValue("@Data", movimento.Data);
                    command.Parameters.AddWithValue("@Solicitante", movimento.Solicitante);
                    command.Parameters.AddWithValue("@Tipo", movimento.Tipo);
                    command.Parameters.AddWithValue("@Quantidade", movimento.Quantidade);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(movimento.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Movimentos movimento)
        {
            try
            {
                if (movimento.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTMOVIMENTOSESTOQUE",
                    };

                    command.Parameters.AddWithValue("@ProdutoId", movimento.Produto.Id);
                    command.Parameters.AddWithValue("@Data", movimento.Data);
                    command.Parameters.AddWithValue("@Solicitante", movimento.Solicitante);
                    command.Parameters.AddWithValue("@Tipo", movimento.Tipo);
                    command.Parameters.AddWithValue("@Quantidade", movimento.Quantidade);
                    command.Parameters.AddWithValue("@Id", movimento.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(movimento.GetErros());
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
                        CommandText = "DELETEMOVIMENTOSESTOQUE",
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

        public List<Produto> Get()
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
