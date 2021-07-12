using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Fornecedor : AbstractValidator<Fornecedor>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataInicioContrato { get; set; }
        public DateTime DataFimContrato { get; set; }


        public Fornecedor()
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
            ValidarCNPJ();
            ValidarDataInicioContrato();
            ValidarDataFimContrato();
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("- Campo Nome é obrigatório");
        }

        private void ValidarCNPJ()
        {
            RuleFor(a => a.Cnpj).NotEmpty().WithMessage("- Campo CNPJ é obrigatório");
        }

        private void ValidarDataInicioContrato()
        {
            RuleFor(a => a.DataInicioContrato).NotEmpty().WithMessage("- Campo Data de Início do Contrato é obrigatório");
        }

        private void ValidarDataFimContrato()
        {
            RuleFor(a => a.DataFimContrato).NotEmpty().WithMessage("- Campo Data de Fim do Contrato é obrigatório");
        }


        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }



    }
}
