using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Inventario.TIC.Class
{
    public class LancarRateioTOTVS
    {
        public LancarRateioTOTVS()
        {

        }

        private HttpRequestMessageProperty CreateBasicAuthorizationMessageProperty(string username, string password)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string credential = string.Format("{0}:{1}", username, password);

            var httpRequestProperty = new HttpRequestMessageProperty();

            httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] =
             "Basic " + Convert.ToBase64String(encoding.GetBytes(credential));

            return httpRequestProperty;
        }

        public string InserirRateioTOTVS(string userTOTVS, string password, List<RateioCentroCusto> listaRateio)
        {
            StringBuilder xml = new StringBuilder();
            string retorno = "";
            XmlWriter writer = XmlWriter.Create(xml);

            try
            {
                writer.WriteStartElement("MovMovimento"); //ABRINDO A TAG MovMovimento
                writer.WriteStartElement("TMOV"); //ABRINDO A TAG TMOV
                writer.WriteElementString("CODCOLIGADA", listaRateio[0].CodColigada.ToString());
                writer.WriteElementString("IDMOV", listaRateio[0].IdMov.ToString());
                writer.WriteEndElement(); //FECHANDO A TAG TMOV

                // Inserindo os rateios
                listaRateio.ForEach(l =>
                {
                    writer.WriteStartElement("TITMMOVRATCCU"); //ABRINDO A TAG TITMMOVRATCCU
                    writer.WriteElementString("CODCOLIGADA", l.CodColigada.ToString());
                    writer.WriteElementString("IDMOV", l.IdMov.ToString());
                    writer.WriteElementString("NSEQITMMOV", l.NSeqItMMov.ToString());
                    writer.WriteElementString("CODCCUSTO", l.CodCCusto.ToString());
                    writer.WriteElementString("VALOR", l.Valor.ToString());
                    writer.WriteElementString("IDMOVRATCCU", l.IdMovRatCcu.ToString());
                    writer.WriteEndElement(); //FECHANDO A TAG TITMMOVRATCCU
                });
                writer.WriteEndElement(); //FECHANDO A TAG MovMovimento

                //FECHANDO O ARQUIVO XML
                writer.Flush();
                writer.Close();

                string xmlString = xml.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Replace(@"\", "");

                TOTVS.DataServer.IwsDataServerClient client = Totvs.CreateClientDataServer(userTOTVS, password);
                OperationContextScope scope = new OperationContextScope(client.InnerChannel);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = CreateBasicAuthorizationMessageProperty(userTOTVS, password);
                retorno = client.SaveRecord("MovMovimentoTBCData", xmlString, "CODCOLIGADA=5");

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
