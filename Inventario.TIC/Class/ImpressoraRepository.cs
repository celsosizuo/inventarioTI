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
    public class ImpressoraRepository
    {
        public string Add(Impressora impressora)
        {
            try
            {
                if (impressora.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTIMPRESSORAS",
                    };

                    command.Parameters.AddWithValue("@FornecedorId", impressora.FornecedorId);
                    command.Parameters.AddWithValue("@TipoImpressaoId", impressora.TipoImpressaoId);
                    command.Parameters.AddWithValue("@NumSerie", impressora.NumSerie);
                    command.Parameters.AddWithValue("@Modelo", impressora.Modelo);
                    command.Parameters.AddWithValue("@Setor", impressora.Setor);
                    command.Parameters.AddWithValue("@CCusto", impressora.CCusto);
                    command.Parameters.AddWithValue("@ValorFixo", impressora.ValorFixo);
                    command.Parameters.AddWithValue("@Observacao", impressora.Observacao);
                    command.Parameters.AddWithValue("@Status", impressora.Status);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(impressora.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Impressora impressora)
        {
            try
            {
                if (impressora.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTIMPRESSORAS",
                    };

                    command.Parameters.AddWithValue("@FornecedorId", impressora.FornecedorId);
                    command.Parameters.AddWithValue("@TipoImpressaoId", impressora.TipoImpressaoId);
                    command.Parameters.AddWithValue("@NumSerie", impressora.NumSerie);
                    command.Parameters.AddWithValue("@Modelo", impressora.Modelo);
                    command.Parameters.AddWithValue("@Setor", impressora.Setor);
                    command.Parameters.AddWithValue("@CCusto", impressora.CCusto);
                    command.Parameters.AddWithValue("@ValorFixo", impressora.ValorFixo);
                    command.Parameters.AddWithValue("@Observacao", impressora.Observacao);
                    command.Parameters.AddWithValue("@Status", impressora.Status);

                    command.Parameters.AddWithValue("@ID", impressora.Id);

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
                        CommandText = "DELETEIMPRESSORAS",
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

        public List<Impressora> Get()
        {
            string strSql = @"GETIMPRESSORAS";

            List<Impressora> ret;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
            {
                ret = connection.Query(strSql,
                    new[]
                    {
                            typeof(Impressora),
                            typeof(TipoImpressao),
                            typeof(Fornecedor)

                    }, objects =>
                    {
                        var item = objects[0] as Impressora;
                        var tipoImpressao = objects[1] as TipoImpressao;
                        var fornecedor = objects[2] as Fornecedor;

                        item.TipoImpressao = tipoImpressao;
                        item.Fornecedor = fornecedor;

                        return item;
                    }, splitOn: "ID, ID, ID").AsList();

                return ret;
            }
        }
        public DataTable GetImpressoraStatus()
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GETIMPRESSORASTATUS"
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

        public List<ImpressoraResponse> GetResponse()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    var impressoraReponse = connection.Query<ImpressoraResponse>("GETIMPRESSORASRESPONSE", null, commandType: CommandType.StoredProcedure).ToList();
                    return impressoraReponse;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
