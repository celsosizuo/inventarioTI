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
    public class DispositivoAlugadoLicencaRepository
    {
        public void Add(DispositivoAlugadoLicencas computadoresLicencas)
        {
            try
            {
                if (computadoresLicencas.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTDISPOSITIVOALUGADOLICENCAS",
                    };

                    command.Parameters.AddWithValue("@DISPOSITIVOALUGADOID", computadoresLicencas.DispositivoAlugadoId);
                    command.Parameters.AddWithValue("@LICENCAID", computadoresLicencas.LicencaId);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(computadoresLicencas.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int computadoresId, int licencaId)
        {
            try
            {
                if (computadoresId != 0 && licencaId != 0)
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "DELETEDISPOSITIVOALUGADOLICENCAS",
                    };

                    command.Parameters.AddWithValue("@DISPOSITIVOALUGADOID", computadoresId);
                    command.Parameters.AddWithValue("@licencaId", licencaId);

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

        public List<DispositivoAlugadoLicencas> Get()
        {
            try
            {
                string strSql = @"GETDISPOSITIVOALUGADOLICENCAS";

                List<DispositivoAlugadoLicencas> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(DispositivoAlugadoLicencas),
                            typeof(DispositivoAlugado),
                            typeof(Licenca),
                            typeof(NotaFiscal),
                            typeof(Software),
                            typeof(Usuario)

                        }, objects =>
                        {
                            var computadoresLicencas = objects[0] as DispositivoAlugadoLicencas;
                            var computadores = objects[1] as DispositivoAlugado;
                            var licenca = objects[2] as Licenca;
                            var notaFiscal = objects[3] as NotaFiscal;
                            var software = objects[4] as Software;
                            var usuario = objects[5] as Usuario;

                            computadoresLicencas.DispositivoAlugado = computadores;
                            licenca.NotaFiscal = notaFiscal;
                            licenca.Software = software;
                            computadores.Usuario = usuario;
                            computadoresLicencas.Licencas.Add(licenca);

                            return computadoresLicencas;

                        }, splitOn: "COMPUTADORESID, ID, ID, ID, ID, ID").AsList();
                }

                var list = new List<DispositivoAlugadoLicencas>();
                var numItemGuardado = 0;

                ret.ToList().ForEach(it =>
                {
                    if (it.DispositivoAlugadoId != numItemGuardado)
                        list.Add(it);
                    else
                        list.LastOrDefault().Licencas.Add(it.Licencas.FirstOrDefault());

                    numItemGuardado = it.DispositivoAlugadoId;
                });

                return list;

                // return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        




        //public void Update(DispositivoAlugadoLicencas computadoresLicencas)
        //{
        //    try
        //    {
        //        if (licencas.EhValido())
        //        {
        //            SqlCommand command = new SqlCommand()
        //            {
        //                Connection = new SqlConnection(Properties.Settings.Default.conSQL),
        //                CommandType = CommandType.StoredProcedure,
        //                CommandText = "PUTLICENCAS",
        //            };

        //            command.Parameters.AddWithValue("@NotaFiscalId", licencas.NotaFiscal.Id);
        //            command.Parameters.AddWithValue("@SoftwareId", licencas.Software.Id);
        //            command.Parameters.AddWithValue("@Quantidade", licencas.Quantidade);
        //            command.Parameters.AddWithValue("@Chave", licencas.Chave);
        //            command.Parameters.AddWithValue("@Status", licencas.Status);
        //            command.Parameters.AddWithValue("@Id", licencas.Id);

        //            command.Connection.Open();
        //            command.ExecuteScalar();
        //        }
        //        else
        //        {
        //            throw new Exception(licencas.GetErros());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
