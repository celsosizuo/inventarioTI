using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class CelularResponse
    {
        public int Id { get; set; }
        public int LinhaId { get; set; }
        public string Numero { get; set; }
        public string Chip { get; set; }
        public string Pin { get; set; }
        public string Puk { get; set; }
        public int UsuarioId { get; set; }
        public string Chapa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int AparelhoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public decimal Valor { get; set; }

        public static explicit operator CelularResponse(Celular entity) 
        {
            CelularResponse celularResponse = new CelularResponse()
            {
                AparelhoId = entity.Aparelho.Id,
                Chapa = entity.Usuario.Chapa,
                Chip = entity.Linha.Chip,
                Cpf = entity.Usuario.Cpf,
                Id = entity.Id,
                Imei1 = entity.Aparelho.Imei1,
                Imei2 = entity.Aparelho.Imei2,
                LinhaId = entity.Linha.Id,
                Marca = entity.Aparelho.Marca,
                Modelo = entity.Aparelho.Modelo,
                Nome = entity.Usuario.Nome,
                Numero = entity.Linha.Numero,
                Pin = entity.Linha.Pin,
                Puk = entity.Linha.Puk,
                UsuarioId = entity.Usuario.Id,
                Valor = entity.Aparelho.Valor
            };
            return celularResponse;
        }

    }
}
