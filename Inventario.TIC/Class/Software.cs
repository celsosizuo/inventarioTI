using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Software : AbstractValidator<Software>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string Versao { get; set; }

        public Software()
        {
            ValidationResult = new ValidationResult();
        }

        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidarFabricante();
            ValidarVersao();
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("- Campo Nome é obrigatório");
        }

        private void ValidarFabricante()
        {
            RuleFor(a => a.Fabricante).NotEmpty().WithMessage("- Campo Fabricante é obrigatório");
        }

        private void ValidarVersao()
        {
            RuleFor(a => a.Versao).NotEmpty().WithMessage("- Campo Versão é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
