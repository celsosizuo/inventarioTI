using FluentValidation;
using FluentValidation.Results;
using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TermoComputadorAcessorio : AbstractValidator<TermoComputadorAcessorio>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int TermoComputadorId { get; set; }
        public string NomeAcessorio { get; set; }
        public decimal Valor { get; set; }
        public int LinhaSelecionada { get; set; }

        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarAcessorio();
            ValidarValor();
            ValidarTermoComputador();
        }

        private void ValidarTermoComputador()
        {
            RuleFor(a => a.TermoComputadorId).NotNull().WithMessage("- Favor selecionar um termo");
        }

        private void ValidarAcessorio()
        {
            RuleFor(a => a.NomeAcessorio).NotEmpty().WithMessage("- Campo Nome do Acessorio é obrigatório");
        }

        private void ValidarValor()
        {
            RuleFor(a => a.Valor).NotEmpty().WithMessage("- Campo Valor é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
