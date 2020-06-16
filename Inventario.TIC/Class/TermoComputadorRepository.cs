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
    public class TermoComputadorRepository
    {
        public string Add(TermoComputador termoComputador)
        {
            try
            {
                if (termoComputador.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTTERMOCOMPUTADOR",
                    };

                    command.Parameters.AddWithValue("@UsuarioId", termoComputador.Usuario.Id);

                    if (termoComputador.Computador.Id == 0)
                        command.Parameters.AddWithValue("@ComputadorId", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ComputadorId", termoComputador.Computador.Id);

                    if (termoComputador.DispositivoAlugado.Id == 0)
                        command.Parameters.AddWithValue("@DispositivoAlugadoId", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@DispositivoAlugadoId", termoComputador.DispositivoAlugado.Id);

                    command.Parameters.AddWithValue("@CarregadorId", termoComputador.Carregador.Id);
                    command.Parameters.AddWithValue("@GestorId", termoComputador.Gestor.Id);
                    command.Parameters.AddWithValue("@DataEntrega", termoComputador.DataEntrega);
                    command.Parameters.AddWithValue("@ValorDispositivo", termoComputador.ValorDispositivo);
                    command.Parameters.AddWithValue("@ValorMaleta", termoComputador.ValorMaleta);

                    if (termoComputador.DataDevolucao == null)
                        command.Parameters.AddWithValue("@DataDevolucao", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@DataDevolucao", termoComputador.DataDevolucao);

                    if (termoComputador.Motivo == null)
                        command.Parameters.AddWithValue("@Motivo", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Motivo", termoComputador.Motivo);

                    if (termoComputador.LinkEntrega == null)
                        command.Parameters.AddWithValue("@LinkEntrega", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@LinkEntrega", termoComputador.LinkEntrega);

                    if (termoComputador.LinkDevolucao == null)
                        command.Parameters.AddWithValue("@LinkDevolucao", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@LinkDevolucao", termoComputador.LinkDevolucao);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(termoComputador.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TermoComputador termoComputador)
        {
            try
            {
                if (termoComputador.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTTERMOCOMPUTADOR",
                    };

                    command.Parameters.AddWithValue("@UsuarioId", termoComputador.Usuario.Id);

                    if (termoComputador.Computador == null)
                        command.Parameters.AddWithValue("@ComputadorId", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ComputadorId", termoComputador.Computador.Id);

                    if (termoComputador.DispositivoAlugado == null)
                        command.Parameters.AddWithValue("@DispositivoAlugadoId", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@DispositivoAlugadoId", termoComputador.DispositivoAlugado.Id);

                    command.Parameters.AddWithValue("@CarregadorId", termoComputador.Carregador.Id);
                    command.Parameters.AddWithValue("@GestorId", termoComputador.Gestor.Id);
                    command.Parameters.AddWithValue("@DataEntrega", termoComputador.DataEntrega);
                    command.Parameters.AddWithValue("@ValorDispositivo", termoComputador.ValorDispositivo);
                    command.Parameters.AddWithValue("@ValorMaleta", termoComputador.ValorMaleta);

                    if (termoComputador.DataDevolucao == null)
                        command.Parameters.AddWithValue("@DataDevolucao", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@DataDevolucao", termoComputador.DataDevolucao);

                    command.Parameters.AddWithValue("@Motivo", termoComputador.Motivo);
                    command.Parameters.AddWithValue("@DataEntrega", termoComputador.DataEntrega);
                    command.Parameters.AddWithValue("@Id", termoComputador.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(termoComputador.GetErros());
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
                        CommandText = "DELETETERMOCOMPUTADOR",
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

        public List<TermoComputador> Get()
        {
            try
            {
                string strSql = @"GETTERMOCOMPUTADOR";

                List<TermoComputador> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(TermoComputador),
                            typeof(Usuario),
                            typeof(Computadores),
                            typeof(DispositivoAlugado),
                            typeof(Carregador),
                            typeof(Gestor),

                        }, objects =>
                        {
                            var termoComputador = objects[0] as TermoComputador;
                            var usuarios = objects[1] as Usuario;
                            var computadores = objects[2] as Computadores;
                            var dispositivoAlugado = objects[3] as DispositivoAlugado;
                            var carregador = objects[4] as Carregador;
                            var gestor = objects[5] as Gestor;

                            termoComputador.Usuario = usuarios;
                            termoComputador.Computador = computadores;
                            termoComputador.DispositivoAlugado = dispositivoAlugado;
                            termoComputador.Carregador = carregador;
                            termoComputador.Gestor = gestor;

                            return termoComputador;

                        }, splitOn: "ID, ID, ID, ID, ID, ID").AsList(); //, TERMOCELULARID").AsList();

                    // return ret;
                }

                //var list = new List<TermoComputador>();
                //var numItemGuardado = 0;

                //ret.ToList().ForEach(it =>
                //{
                //    if (it.Id != numItemGuardado)
                //        list.Add(it);
                //    else
                //        list.LastOrDefault().Usuario.Add(it.Usuario.FirstOrDefault());

                //    numItemGuardado = it.Id;
                //});

                //return list;

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateLinkTermoEntrega(TermoComputador termoComputador)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PATHTERMOCOMPUTADORENTREGA",
                };

                command.Parameters.AddWithValue("@TERMOCOMPUTADORID", termoComputador.Id);
                command.Parameters.AddWithValue("@LinkEntrega", termoComputador.LinkEntrega);

                command.Connection.Open();
                command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateLinkTermoDevolucao(TermoComputador termoComputador)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PATHTERMOCOMPUTADORDEVOLUCAO",
                };

                command.Parameters.AddWithValue("@TERMOCOMPUTADORID", termoComputador.Id);
                command.Parameters.AddWithValue("@LinkDevolucao", termoComputador.LinkDevolucao);

                command.Connection.Open();
                command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
