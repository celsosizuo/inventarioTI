using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ComputadoresRepository
    {
        public string Add(Computadores computadores)
        {
            try
            {
                if (computadores.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTCOMPUTADORES",
                    };

                    command.Parameters.AddWithValue("@ATIVOANTIGO", computadores.AtivoAntigo);
                    command.Parameters.AddWithValue("@ATIVONOVO", computadores.AtivoNovo);
                    command.Parameters.AddWithValue("@USUARIO", computadores.Usuario);
                    command.Parameters.AddWithValue("@DEPARTAMENTO", computadores.Departamento);
                    command.Parameters.AddWithValue("@STATUS", computadores.Status1);
                    command.Parameters.AddWithValue("@OBSERVACOES", computadores.Observacoes);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(computadores.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Computadores computadores)
        {
            try
            {
                if (computadores.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTCOMPUTADORES",
                    };

                    command.Parameters.AddWithValue("@ATIVOANTIGO", computadores.AtivoAntigo);
                    command.Parameters.AddWithValue("@ATIVONOVO", computadores.AtivoNovo);
                    command.Parameters.AddWithValue("@USUARIO", computadores.Usuario);
                    command.Parameters.AddWithValue("@DEPARTAMENTO", computadores.Departamento);
                    command.Parameters.AddWithValue("@STATUS", computadores.Status1);

                    if(computadores.Observacoes == null)
                        command.Parameters.AddWithValue("@OBSERVACOES", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@OBSERVACOES", computadores.Observacoes);

                    command.Parameters.AddWithValue("@ID", computadores.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(computadores.GetErros());
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
                if(id != 0)
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "DELETECOMPUTADORES",
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

        public List<Computadores> Get()
        {
            try
            {
                string strSql = @"GETCOMPUTADORES";

                List<Computadores> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(Computadores),
                            typeof(ComputadoresOCS),
                            typeof(Disco),

                        }, objects =>
                        {
                            var item = objects[0] as Computadores;
                            var subItem = objects[1] as ComputadoresOCS;
                            var subSubItem = objects[2] as Disco;

                            item.ComputadoresOCS = subItem;

                            if (subSubItem != null)
                                item.Discos.Add(subSubItem);
                            else
                                item.Discos = new List<Disco>();

                            return item;
                        }, splitOn: "ID, ID, DISCOID").AsList();
                }

                var list = new List<Computadores>();
                var numItemGuardado = 0;

                ret.ToList().ForEach(it =>
                {
                    if (it.Id != numItemGuardado)
                    {
                        if (it.Discos.FirstOrDefault() == null)
                            it.Discos.Remove(it.Discos.FirstOrDefault());

                        list.Add(it);


                    }
                    //else if (it.idDocFornecItem == it.RefacaoItens.FirstOrDefault().idDocFornecItem)
                    //    list.LastOrDefault().RefacaoItens.Add(it.RefacaoItens.FirstOrDefault());
                    else
                        list.LastOrDefault().Discos.Add(it.Discos.FirstOrDefault());

                    numItemGuardado = it.Id;
                });

                return list;
            }
                catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ComputadoresOCS> GetComputadoresOCS()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
            {
                // TODO: Inserir os discos (HD) nesta consulta;
                var computadoresOCS = connection.Query<ComputadoresOCS>("GETCOMPUTADORESOCS", null, commandType: CommandType.StoredProcedure).ToList();

                return computadoresOCS;
            }
        }

        public List<ComputadoresOCS> FindComputadoresOCS(string ativo)
        {
            var computadoresOCS = this.GetComputadoresOCS();
            var computadorOCS = computadoresOCS.Where(c => c.Name == ativo).ToList();

            return computadorOCS;
        }

        public void AssociarOCS(int ComputadorID, int? ComputadorOCSId)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PUTASSOCIARAOOCS",
                };

                command.Parameters.AddWithValue("@COMPUTADORID", ComputadorID);
                command.Parameters.AddWithValue("@COMPUTADOROCSID", ComputadorOCSId);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Computadores> Get1()
        {
            try
            {
                string strSql = @"GETCOMPUTADORES";

                List<Computadores> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(Computadores),
                            typeof(ComputadoresOCS),
                            typeof(Disco),

                        }, objects =>
                        {
                            var item = objects[0] as Computadores;
                            var subItem = objects[1] as ComputadoresOCS;
                            var subSubItem = objects[2] as Disco;

                            item.ComputadoresOCS = subItem;

                            if (subSubItem != null)
                                item.Discos.Add(subSubItem);
                            else
                                item.Discos = new List<Disco>();

                            return item;
                        }, splitOn: "ID, ID, DISCOID").AsList();
                }

                var list = new List<Computadores>();
                var numItemGuardado = 0;

                ret.ToList().ForEach(it =>
                {
                    if (it.Id != numItemGuardado)
                    {
                        if (it.Discos.FirstOrDefault() == null)
                            it.Discos.Remove(it.Discos.FirstOrDefault());

                        list.Add(it);


                    }
                    else
                        list.LastOrDefault().Discos.Add(it.Discos.FirstOrDefault());

                    numItemGuardado = it.Id;
                });

                List<HistoricoUsuariosComputadores> historicoUsuarios = new List<HistoricoUsuariosComputadores>();

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                   historicoUsuarios = connection.Query<HistoricoUsuariosComputadores>("GETHISTORICOUSUARIOCOMPUTADORES1", null, commandType: CommandType.StoredProcedure).ToList();
                }

                list.ForEach(l =>
                {
                    var hist = historicoUsuarios.Where(h => h.ComputadoresId == l.Id).OrderByDescending(i => i.DataMudanca).ToList();

                    l.HistoricoUsuarios = hist;
                });

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
