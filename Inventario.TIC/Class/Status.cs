using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Status
    {
        public string Codigo { get; set; }
        public string Valor { get; set; }

        public Status()
        {

        }

        public List<Status> Get()
        {
            List<Status> retorno = new List<Status>();

            Status valor = new Status()
            {
                Codigo = "",
                Valor = ""
            };
            retorno.Add(valor);


            Status valor1 = new Status()
            {
                Codigo = "A",
                Valor = "Ativo"
            };
            retorno.Add(valor1);

            Status valor2 = new Status()
            {
                Codigo = "I",
                Valor = "Inativo"
            };
            retorno.Add(valor2);

            return retorno;
        }
    }
}
