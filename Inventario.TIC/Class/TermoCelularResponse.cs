using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TermoCelularResponse
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Usuario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NomeGestor { get; set; }
        public int LinhaId { get; set; }
        public int AparelhoId { get; set; }
        public int CarregadorId { get; set; }
        public int FoneOuvido { get; set; }
        public string FoneOuvidoDescricao { get; set; }
        public int GestorId { get; set; }
        public DateTime DataEntrega { get; set; }
        // public DateTime? DataDevolucao { get; set; }
        public string LinkEntrega { get; set; }
        public string LinkDevolucao { get; set; }
        public string Status { get; set; }

        public static explicit operator TermoCelularResponse(TermoCelular entity)
        {
            TermoCelularResponse termoCelularResponse = new TermoCelularResponse()
            {
                Id = entity.Id,
                AparelhoId = entity.AparelhoId,
                CarregadorId = entity.CarregadorId,
                // DataDevolucao = entity.Usuario[0].DataDevolucao,
                DataEntrega = entity.DataEntrega,
                FoneOuvido = entity.FoneOuvido,
                GestorId = entity.GestorId,
                LinhaId = entity.LinhaId,
                LinkDevolucao = entity.LinkDevolucao,
                LinkEntrega = entity.LinkEntrega,
                Marca = entity.Aparelho.Marca,
                Modelo = entity.Aparelho.Modelo,
                NomeGestor = entity.Gestor.Nome,
                Numero = entity.Linha.Numero,
                Usuario = entity.Usuario[0].Nome,
                FoneOuvidoDescricao = entity.FoneOuvidoDescricao,
                Status = entity.Status,
            };

            return termoCelularResponse;
        }
    }
}
