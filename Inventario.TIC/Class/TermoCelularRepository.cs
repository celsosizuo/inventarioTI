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
    public class TermoCelularRepository
    {
        public string Add(TermoCelular celular)
        {
            try
            {
                if (celular.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTTERMOCELULAR",
                    };

                    command.Parameters.AddWithValue("@LinhaId", celular.LinhaId);
                    command.Parameters.AddWithValue("@AparelhoId", celular.AparelhoId);
                    command.Parameters.AddWithValue("@CarregadorId", celular.CarregadorId);
                    command.Parameters.AddWithValue("@FoneOuvido", celular.FoneOuvido);
                    command.Parameters.AddWithValue("@GestorId", celular.GestorId);
                    command.Parameters.AddWithValue("@DataEntrega", celular.DataEntrega);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(celular.GetErros());
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
                        CommandText = "DELETECELULAR",
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

        public List<TermoCelular> Get()
        {
            try
            {
                string strSql = @"GETTERMOCELULAR";

                List<TermoCelular> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(TermoCelular),
                            typeof(Linha),
                            typeof(Aparelho),
                            typeof(Carregador),
                            typeof(Gestor),

                        }, objects =>
                        {
                            var celulares = objects[0] as TermoCelular;
                            var linhas = objects[1] as Linha;
                            var aparelhos = objects[2] as Aparelho;
                            var carregador = objects[3] as Carregador;
                            var gestor = objects[4] as Gestor;

                            celulares.Linha = linhas;
                            celulares.Aparelho = aparelhos;
                            celulares.Carregador = carregador;
                            celulares.Gestor = gestor;

                            return celulares;

                        }, splitOn: "ID, ID, ID, ID, ID").AsList();

                    return ret;
                }

                //var list = new List<ComputadoresLicencas>();
                //var numItemGuardado = 0;

                //ret.ToList().ForEach(it =>
                //{
                //    if (it.ComputadoresId != numItemGuardado)
                //        list.Add(it);
                //    else
                //        list.LastOrDefault().Licencas.Add(it.Licencas.FirstOrDefault());

                //    numItemGuardado = it.ComputadoresId;
                //});

                // return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
