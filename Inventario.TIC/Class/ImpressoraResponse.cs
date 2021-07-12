using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ImpressoraResponse
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Setor { get; set; }
        public string NumSerie { get; set; }
        public string TipoImpressao { get; set; }
        public string Status { get; set; }
        public string Fornecedor { get; set; }
        public int FornecedorId { get; set; }
        public int TipoImpressaoId { get; set; }
        public TipoImpressao TipoImpressao1 { get; set; }
        public Fornecedor Fornecedor1 { get; set; }

        public static explicit operator ImpressoraResponse(Impressora entity)
        {
            ImpressoraResponse impressoraResponse = new ImpressoraResponse()
            {
                Fornecedor = entity.Fornecedor.Nome,
                Fornecedor1 = entity.Fornecedor,
                FornecedorId = entity.FornecedorId,
                Id = entity.Id,
                Modelo = entity.Modelo,
                NumSerie = entity.NumSerie,
                Setor = entity.Setor,
                Status = entity.Status,
                TipoImpressao = entity.TipoImpressao.Descricao,
                TipoImpressaoId = entity.TipoImpressaoId,
            };
            return impressoraResponse;
        }
    }
}
