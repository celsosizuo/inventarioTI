using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class PrecoContaEMail : AbstractValidator<PrecoContaEMail>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string TipoConta { get; set; }
        public decimal ValorUnitSemImposto { get; set; }
        public decimal CargaTributaria { get; set; }
        public decimal ValorUnitComImposto { get; set; }

        public PrecoContaEMail()
        {

        }


        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarTipoConta();
            ValidarValorUnitSemImposto();
            ValidarCargaTributaria();
            ValidarValorUnitComImposto();
        }

        private void ValidarValorUnitComImposto()
        {
            RuleFor(a => a.ValorUnitComImposto).NotEmpty().WithMessage("- Campo Valor unitário com imposto é obrigatório");
        }

        private void ValidarCargaTributaria()
        {
            RuleFor(a => a.CargaTributaria).NotEmpty().WithMessage("- Campo Carga tributária é obrigatório");
        }

        private void ValidarValorUnitSemImposto()
        {
            RuleFor(a => a.ValorUnitSemImposto).NotEmpty().WithMessage("- Campo Valor unitário sem imposto é obrigatório");
        }

        private void ValidarTipoConta()
        {
            RuleFor(a => a.TipoConta).NotEmpty().WithMessage("- Campo Tipo de Conta é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

    }
}
