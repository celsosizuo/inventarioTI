using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Licenca : AbstractValidator<Licenca>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
//      public int NotaFiscalId { get; set; }
//      public int SoftwareId { get; set; }
        public decimal Quantidade { get; set; }
        public string Chave { get; set; }
        public string Status { get; set; }
        public Software Software { get; set; }
        public NotaFiscal NotaFiscal { get; set; }

        public Licenca()
        {
            Software = new Software();
            NotaFiscal = new NotaFiscal();
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
            ValidarQuantidade();
            ValidarChave();
            ValidarStatus();
            ValidarSoftware();
            ValidarNotaFiscal();
        }

        private void ValidarQuantidade()
        {
            RuleFor(a => a.Quantidade).NotEmpty().WithMessage("- Campo Quantidade é obrigatório");
        }

        private void ValidarChave()
        {
            RuleFor(a => a.Chave).NotEmpty().WithMessage("- Campo Chave é obrigatório");
        }

        private void ValidarStatus()
        {
            RuleFor(a => a.Status).NotEmpty().WithMessage("- Campo Status é obrigatório");
        }

        private void ValidarSoftware()
        {
            RuleFor(a => a.Software.Id).NotEmpty().WithMessage("- Campo Software é obrigatório");
        }

        private void ValidarNotaFiscal()
        {
            RuleFor(a => a.NotaFiscal.Id).NotEmpty().WithMessage("- Campo Nota Fiscal é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

        public static explicit operator Licenca(LicencasResponse entity)
        {
            Licenca licenca = new Licenca()
            {
                Chave = entity.Chave,
                Id = entity.Id,
                NotaFiscal = entity.NotaFiscal,
                Quantidade = entity.Quantidade,
                Software = entity.Software,
                Status = entity.Status
            };
            return licenca;
        }
    }
}
