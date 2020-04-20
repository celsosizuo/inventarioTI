using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Linha : AbstractValidator<Linha>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Chip { get; set; }
        public string Pin { get; set; }
        public string Puk { get; set; }

        public Linha()
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
            ValidarLinha();
            ValidarChip();
        }

        private void ValidarLinha()
        {
            RuleFor(a => a.Numero).NotEmpty().WithMessage("- Campo Número é obrigatório");
        }

        private void ValidarChip()
        {
            RuleFor(a => a.Chip).NotEmpty().WithMessage("- Campo Chip é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
