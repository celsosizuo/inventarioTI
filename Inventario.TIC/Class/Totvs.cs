using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public static class Totvs
    {
        public static TOTVS.DataServer.IwsDataServerClient CreateClientDataServer(string userName, string password)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.SendTimeout = new TimeSpan(0, 10, 0);

            string url = "";

            if (Properties.Settings.Default.tipoBase == "producao")
                url = string.Format("{0}/wsDataServer/IwsDataServer", "http://svap01:8051");
            else
                url = string.Format("{0}/wsDataServer/IwsDataServer", "http://192.168.20.230:8051");

            TOTVS.DataServer.IwsDataServerClient client = new TOTVS.DataServer.IwsDataServerClient(binding, new System.ServiceModel.EndpointAddress(url));
            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }
    }
}
