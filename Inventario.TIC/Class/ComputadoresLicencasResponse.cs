using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ComputadoresLicencasResponse
    {
        public string AtivoNovo { get; set; }
        public string AtivoAntigo { get; set; }
        public string Usuario { get; set; }
        public string SoftwareNome { get; set; }
        public string Chave { get; set; }
        public string NumNF { get; set; }
        public string Fornecedor { get; set; }
        public string Link { get; set; }
        public Computadores Computadores { get; set; }
        public List<Licenca> Licencas { get; set; }

        //public static explicit operator ComputadoresLicencasResponse(ComputadoresLicencas entity)
        //{
        //    ComputadoresLicencasResponse computadoresLicencasResponse = new ComputadoresLicencasResponse()
        //    {
        //        AtivoNovo = entity.Computadores.AtivoNovo,
        //        AtivoAntigo = entity.Computadores.AtivoAntigo,
        //        Chave = entity.Licencas.
        //    }

        //    return computadoresLicencasResponse;

        //}


    }
}
