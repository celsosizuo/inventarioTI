using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class LicencasResponse
    {
        public int Id { get; set; }
        public string NumNF { get; set; }
        public string NomeSoftware { get; set; }
        public decimal Quantidade { get; set; }
        public string Chave { get; set; }
        public int NotaFiscalId { get; set; }
        public int SoftwareId { get; set; }
        public string Status { get; set; }
        public Software Software { get; set; }
        public NotaFiscal NotaFiscal { get; set; }

        public static explicit operator LicencasResponse(Licenca entity)
        {
            LicencasResponse licencasResponse = new LicencasResponse()
            {
                Chave = entity.Chave,
                Id = entity.Id,
                NomeSoftware = entity.Software.Nome,
                NotaFiscal = entity.NotaFiscal,
                NotaFiscalId = entity.NotaFiscal.Id,
                NumNF = entity.NotaFiscal.NumNF,
                Quantidade = entity.Quantidade,
                Software = entity.Software,
                SoftwareId = entity.Software.Id,
                Status = entity.Status
            };
            return licencasResponse;
        }
    }
}
