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
    public class CelularRepository
    {
        public string Add(Celular celular)
        {
            try
            {
                if (celular.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTCELULAR",
                    };

                    command.Parameters.AddWithValue("@LinhaId", celular.LinhaId);
                    command.Parameters.AddWithValue("@UsuarioId", celular.UsuarioId);
                    command.Parameters.AddWithValue("@AparelhoId", celular.AparelhoId);

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

        public List<Celular> Get()
        {
            try
            {
                string strSql = @"GETCELULAR";

                List<Celular> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(Celular),
                            typeof(Linha),
                            typeof(Usuario),
                            typeof(Aparelho),

                        }, objects =>
                        {
                            var celulares = objects[0] as Celular;
                            var linhas = objects[1] as Linha;
                            var usuarios = objects[2] as Usuario;
                            var aparelhos = objects[3] as Aparelho;

                            celulares.Linha = linhas;
                            celulares.Usuario = usuarios;
                            celulares.Aparelho = aparelhos;

                            return celulares;

                        }, splitOn: "ID, ID, ID, ID").AsList();

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
