using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Produto : AbstractValidator<Produto>
    {
        protected ValidationResult ValidationResult { get; set; }

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Movimentos> Movimentos { get; set; }

        public Produto()
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
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("- Campo Nome é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
