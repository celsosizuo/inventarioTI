using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class NotaFiscal : AbstractValidator<NotaFiscal>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string NumNF { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Data { get; set; }
        public string Empresa { get; set; }
        public string Link { get; set; }

        public NotaFiscal()
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
            ValidarNumNF();
            ValidarFornecedor();
            ValidarData();
            ValidarEmpresa();
            ValidarLink();
        }

        private void ValidarNumNF()
        {
            RuleFor(a => a.NumNF)
                .NotEmpty().WithMessage("- Campo Número da NF é obrigatório")
                .Length(9).WithMessage("- O número da NF deve conter 9 caracteres");
        }

        private void ValidarFornecedor()
        {
            RuleFor(a => a.Fornecedor).NotEmpty().WithMessage("- Campo Fornecedor é obrigatório");
        }

        private void ValidarData()
        {
            RuleFor(a => a.Data)
                .NotEmpty().WithMessage("- Campo Data é obrigatório")
                .LessThan(DateTime.Now).WithMessage("- A data não pode ser maior que a data atual");
        }

        private void ValidarEmpresa()
        {
            RuleFor(a => a.Empresa).NotEmpty().WithMessage("- Campo Empresa é obrigatório");
        }

        private void ValidarLink()
        {
            RuleFor(a => a.Link).NotEmpty().WithMessage("- Campo Link é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
