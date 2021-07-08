using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Referencia : AbstractValidator<Referencia>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Ref { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Status { get; set; }

        public Referencia()
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
            ValidarRef();
            ValidarDataInicio();
            ValidarDataFinal();
            ValidarStatus();
        }

        private void ValidarRef()
        {
            RuleFor(a => a.Ref).NotEmpty().WithMessage("- Campo Referência é obrigatório");
        }

        private void ValidarDataInicio()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty().WithMessage("- Campo Data de Início é obrigatório")
                .Must(ValidaData).WithMessage("- Campo Data de Início não é uma data válida");
        }

        private void ValidarDataFinal()
        {
            RuleFor(a => a.DataFim)
                .NotEmpty().WithMessage("- Campo Data Fim é obrigatório")
                .Must(ValidaData).WithMessage("- Campo Data Fim não é uma data válida");
        }


        public bool ValidaData(DateTime data)
        {
            return !data.Equals(default);
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








    }

}
