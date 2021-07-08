using FluentValidation.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TipoImpressao : AbstractValidator<TipoImpressao>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoImpressao()
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
            ValidarTipoImpressao();
        }

        private void ValidarTipoImpressao()
        {
            RuleFor(a => a.Descricao).NotEmpty().WithMessage("- Campo Descrição é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
