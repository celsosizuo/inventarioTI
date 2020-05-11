using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TipoDispositivo : AbstractValidator<TipoDispositivo>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Tipo { get; set; }

        public TipoDispositivo()
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
            ValidarTipo();
        }

        private void ValidarTipo()
        {
            RuleFor(a => a.Tipo).NotEmpty().WithMessage("- Campo Tipo é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
