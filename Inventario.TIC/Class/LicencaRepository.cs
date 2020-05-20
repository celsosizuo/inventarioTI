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
    public class LicencaRepository
    {
        public string Add(Licenca licencas)
        {
            try
            {
                if (licencas.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "POSTLICENCAS",
                    };

                    command.Parameters.AddWithValue("@NotaFiscalId", licencas.NotaFiscal.Id);
                    command.Parameters.AddWithValue("@SoftwareId", licencas.Software.Id);
                    command.Parameters.AddWithValue("@Quantidade", licencas.Quantidade);
                    command.Parameters.AddWithValue("@Chave", licencas.Chave);
                    command.Parameters.AddWithValue("@Status", licencas.Status);

                    command.Connection.Open();
                    string retorno = command.ExecuteScalar().ToString();

                    return retorno;
                }
                else
                {
                    throw new Exception(licencas.GetErros());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Licenca licencas)
        {
            try
            {
                if (licencas.EhValido())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PUTLICENCAS",
                    };

                    command.Parameters.AddWithValue("@NotaFiscalId", licencas.NotaFiscal.Id);
                    command.Parameters.AddWithValue("@SoftwareId", licencas.Software.Id);
                    command.Parameters.AddWithValue("@Quantidade", licencas.Quantidade);
                    command.Parameters.AddWithValue("@Chave", licencas.Chave);
                    command.Parameters.AddWithValue("@Status", licencas.Status);
                    command.Parameters.AddWithValue("@Id", licencas.Id);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                else
                {
                    throw new Exception(licencas.GetErros());
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
                        CommandText = "DELETELICENCAS",
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

        public List<Licenca> Get()
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

                return ret;
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

        public List<LicencasResponse> GetLicencasComputadoresResponses(int computadorId)
        {
            ComputadoresLicencaRepository computadoresLicencaRepository = new ComputadoresLicencaRepository();
            List<ComputadoresLicencas> computadoresLicencas = computadoresLicencaRepository.Get().ToList();
            computadoresLicencas = computadoresLicencas.Where(cl => cl.ComputadoresId == computadorId).ToList();
            List<Licenca> licencas = new List<Licenca>();

            computadoresLicencas.ForEach(c => c.Licencas.ForEach(l =>
            {
                licencas.Add(l);
            }));

            List<LicencasResponse> ret = licencas.Select(li => (LicencasResponse)li).ToList();
            return ret;
        }

        public List<LicencasResponse> GetLicencasDispositivoAlugadoResponses(int dispositivoAlugadoId)
        {
            DispositivoAlugadoLicencaRepository dispositivoAlugadoLicencaRepository = new DispositivoAlugadoLicencaRepository();
            List<DispositivoAlugadoLicencas> dispositivoAlugadoLicencas = dispositivoAlugadoLicencaRepository.Get().ToList();
            dispositivoAlugadoLicencas = dispositivoAlugadoLicencas.Where(cl => cl.DispositivoAlugadoId == dispositivoAlugadoId).ToList();
            List<Licenca> licencas = new List<Licenca>();

            dispositivoAlugadoLicencas.ForEach(c => c.Licencas.ForEach(l =>
            {
                licencas.Add(l);
            }));

            List<LicencasResponse> ret = licencas.Select(li => (LicencasResponse)li).ToList();
            return ret;
        }
    }
}
