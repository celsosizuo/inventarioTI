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
    public class ComputadoresLicencaRepository
    {
        public string Add(ComputadoresLicencas computadoresLicencas)
        {
            try
            {
                if (computadoresLicencas.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTCOMPUTADORESLICENCAS",
                    };

                    // command.Parameters.AddWithValue("@COMPUTADORESID", computadoresLicencas.Computadores.Id);
                    // command.Parameters.AddWithValue("@LICENCAID", computadoresLicencas.Licencas.Id);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
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
                        CommandText = "DELETECOMPUTADORESLICENCAS",
                    };

                    command.Parameters.AddWithValue("@computadoresId", computadoresId);
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

        public List<ComputadoresLicencas> Get()
        {
            try
            {
                string strSql = @"GETCOMPUTADORESLICENCAS";

                List<ComputadoresLicencas> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(ComputadoresLicencas),
                            typeof(Computadores),
                            typeof(Licenca),
                            typeof(Software),
                            typeof(NotaFiscal)

                        }, objects =>
                        {
                            var computadoresLicencas = objects[0] as ComputadoresLicencas;
                            var computadores = objects[1] as Computadores;
                            var licenca = objects[2] as Licenca;
                            var software = objects[3] as Software;
                            var notaFiscal = objects[4] as NotaFiscal;

                            computadoresLicencas.Computadores = computadores;
                            licenca.Software = software;
                            licenca.NotaFiscal = notaFiscal;
                            computadoresLicencas.Licencas.Add(licenca);

                            return computadoresLicencas;

                        }, splitOn: "COMPUTADORESID, ID, ID, ID, ID").AsList();
                }

                var list = new List<ComputadoresLicencas>();
                var numItemGuardado = 0;

                ret.ToList().ForEach(it =>
                {
                    if (it.ComputadoresId != numItemGuardado)
                        list.Add(it);
                    else
                        list.LastOrDefault().Licencas.Add(it.Licencas.FirstOrDefault());

                    numItemGuardado = it.ComputadoresId;
                });

                return list;

                // return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LicencasResponse> GetLicencasResponses()
        {
            try
            {
                string strSql = @"GETLICENCAS";

                List<Licenca> ret;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.conSQL))
                {
                    ret = connection.Query(strSql,
                        new[]
                        {
                            typeof(Licenca),
                            typeof(NotaFiscal),
                            typeof(Software)

                        }, objects =>
                        {
                            var item = objects[0] as Licenca;
                            var notaFiscal = objects[1] as NotaFiscal;
                            var software = objects[2] as Software;

                            item.NotaFiscal = notaFiscal;
                            item.Software = software;

                            return item;
                        }, splitOn: "ID, ID, ID").AsList();
                }

                List<LicencasResponse> retorno = new List<LicencasResponse>();

                ret.ForEach(l =>
                {
                    LicencasResponse r = new LicencasResponse();
                    r.Id = l.Id;
                    r.NomeSoftware = l.Software.Nome;
                    r.NotaFiscal = l.NotaFiscal;
                    r.NotaFiscalId = l.NotaFiscal.Id;
                    r.NumNF = l.NotaFiscal.NumNF;
                    r.Quantidade = l.Quantidade;
                    r.Software = l.Software;
                    r.SoftwareId = l.Software.Id;
                    r.Status = l.Status;
                    r.Chave = l.Chave;

                    retorno.Add(r);
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        //public void Update(ComputadoresLicencas computadoresLicencas)
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
