using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventario.TIC
{
    public class Carregador : AbstractValidator<Carregador>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string NumSerie { get; set; }
        public decimal Valor { get; set; }

        public Carregador()
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
            ValidarMarca();
            ValidarNumSerie();
        }

        private void ValidarMarca()
        {
            RuleFor(a => a.Marca).NotEmpty().WithMessage("- Campo Marca é obrigatório");
        }

        private void ValidarNumSerie()
        {
            RuleFor(a => a.NumSerie).NotEmpty().WithMessage("- Campo NumSerie é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
