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
    public class DispositivoAlugadoRepository
    {
        public string Add(DispositivoAlugado dispositivoAlugado)
        {
            try
            {
                if (dispositivoAlugado.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTDISPOSITIVOALUGADO",
                    };

                    command.Parameters.AddWithValue("@TipoDispositivoId", dispositivoAlugado.TipoDispositivoId);
                    command.Parameters.AddWithValue("@UsuarioId", dispositivoAlugado.UsuarioId);
                    command.Parameters.AddWithValue("@Ativo", dispositivoAlugado.Ativo);
                    command.Parameters.AddWithValue("@Modelo", dispositivoAlugado.Modelo);
                    command.Parameters.AddWithValue("@Valor", dispositivoAlugado.Valor);
                    command.Parameters.AddWithValue("@Avulso", dispositivoAlugado.Avulso);
                    command.Parameters.AddWithValue("@Departamento", dispositivoAlugado.Departamento);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(dispositivoAlugado.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(DispositivoAlugado dispositivoAlugado)
        {
            try
            {
                if (dispositivoAlugado.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTDISPOSITIVOALUGADO",
                    };

                    command.Parameters.AddWithValue("@TipoDispositivoId", dispositivoAlugado.TipoDispositivoId);
                    command.Parameters.AddWithValue("@UsuarioId", dispositivoAlugado.UsuarioId);
                    command.Parameters.AddWithValue("@Ativo", dispositivoAlugado.Ativo);
                    command.Parameters.AddWithValue("@Modelo", dispositivoAlugado.Modelo);
                    command.Parameters.AddWithValue("@Valor", dispositivoAlugado.Valor);
                    command.Parameters.AddWithValue("@Avulso", dispositivoAlugado.Avulso);
                    command.Parameters.AddWithValue("@Departamento", dispositivoAlugado.Departamento);
                    command.Parameters.AddWithValue("@Id", dispositivoAlugado.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(dispositivoAlugado.GetErros());
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
                        CommandText = "DELETEDISPOSITIVOALUGADO",
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

        public List<DispositivoAlugado> Get()
        {
            try
            {
                string strSql = @"GETDISPOSITIVOALUGADO";

                List<DispositivoAlugado> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(DispositivoAlugado),
                            typeof(TipoDispositivo),
                            typeof(Usuario),
                            typeof(ComputadoresOCS),
                            typeof(Disco)


                        }, objects =>
                        {
                            var dispositivoAlugado = objects[0] as DispositivoAlugado;
                            var tipoDispositivo = objects[1] as TipoDispositivo;
                            var usuario = objects[2] as Usuario;
                            var subItem = objects[3] as ComputadoresOCS;
                            var subSubItem = objects[4] as Disco;


                            dispositivoAlugado.TipoDispositivo = tipoDispositivo;
                            dispositivoAlugado.Usuario = usuario;
                            dispositivoAlugado.NomeTipoDispositivo = dispositivoAlugado.TipoDispositivo.Tipo;
                            dispositivoAlugado.NomeUsuario = dispositivoAlugado.Usuario.Nome;

                            dispositivoAlugado.ComputadoresOCS = subItem;

                            if (subSubItem != null)
                                dispositivoAlugado.Discos.Add(subSubItem);
                            else
                                dispositivoAlugado.Discos = new List<Disco>();

                            return dispositivoAlugado;

                        }, splitOn: "ID, ID, ID, ID, DISCOID").AsList();
                    return ret;
                }
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

        public void AssociarOCS(int DispositivoId, int? ComputadorOCSId)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PUTASSOCIARDISPOSITIVOAOOCS",
                };

                command.Parameters.AddWithValue("@DISPOSITIVOID", DispositivoId);
                command.Parameters.AddWithValue("@COMPUTADOROCSID", ComputadorOCSId);

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
