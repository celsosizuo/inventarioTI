using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Impressora : AbstractValidator<Impressora>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public int TipoImpressaoId { get; set; }
        public virtual TipoImpressao TipoImpressao { get; set; }
        public string NumSerie { get; set; }
        public string Modelo { get; set; }
        public string Setor { get; set; }
        public string CCusto { get; set; }
        public decimal ValorFixo { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }

        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNumSerie();
            ValidarModelo();
            ValidarSetor();
            ValidarCCusto();
            ValidarValorFixo();
            ValidarStatus();


        }

        private void ValidarNumSerie()
        {
            RuleFor(a => a.NumSerie).NotEmpty().WithMessage("- Campo Número de Série é obrigatório");
        }

        private void ValidarModelo()
        {
            RuleFor(a => a.Modelo).NotEmpty().WithMessage("- Campo Modelo é obrigatório");
        }

        private void ValidarSetor()
        {
            RuleFor(a => a.Setor).NotEmpty().WithMessage("- Campo Setor é obrigatório");
        }

        private void ValidarCCusto()
        {
            RuleFor(a => a.CCusto).NotEmpty().WithMessage("- Campo Centro de Custo é obrigatório");
        }

        private void ValidarValorFixo()
        {
            RuleFor(a => a.ValorFixo).NotEmpty().WithMessage("- Campo Valor Fixo é obrigatório");
        }

        private void ValidarStatus()
        {
            RuleFor(a => a.Status).NotEmpty().WithMessage("- Campo Status é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

        public static explicit operator Impressora(ImpressoraResponse entity)
        {
            Impressora impressora = new Impressora()
            {
                FornecedorId = entity.FornecedorId,
                Id = entity.Id,
                Modelo = entity.Modelo,
                NumSerie = entity.NumSerie,
                Setor = entity.Setor,
                Status = entity.Status,
                TipoImpressaoId = entity.TipoImpressaoId,
                Fornecedor = entity.Fornecedor1,
                TipoImpressao= entity.TipoImpressao1,
            };
            return impressora;
        }
    }
}
