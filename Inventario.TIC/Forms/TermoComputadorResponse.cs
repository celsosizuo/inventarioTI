using Inventario.TIC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Forms
{
    public class TermoComputadorResponse
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string AtivoAntigo { get; set; }
        public string AtivoNovo { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorDispositivo { get; set; }
        public string Status { get; set; }

        public static explicit operator TermoComputadorResponse(TermoComputador entity)
        {
            TermoComputadorResponse termoComputadorResponse = new TermoComputadorResponse()
            {
                Id = entity.Id,
                Usuario = entity.Usuario.Nome,
                AtivoAntigo = entity.Computador == null ? entity.DispositivoAlugado.Ativo : entity.Computador.AtivoAntigo,
                AtivoNovo = entity.Computador == null ? entity.DispositivoAlugado.Ativo : entity.Computador.AtivoNovo,
                DataEntrega = entity.DataEntrega,
                ValorDispositivo = entity.ValorDispositivo,
                Status = entity.Status,
            };

            return termoComputadorResponse;
        }
    }
}
