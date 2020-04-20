using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventario.TIC.Forms
{
    public class Aparelho : AbstractValidator<Aparelho>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public decimal Valor { get; set; }

        public Aparelho()
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

        }

        private void ValidarMarca()
        {
            RuleFor(a => a.Marca).NotEmpty().WithMessage("- Campo Marca é obrigatório");
        }

        private void ValidarModelo()
        {
            RuleFor(a => a.Modelo).NotEmpty().WithMessage("- Campo Modelo é obrigatório");
        }

        private void ValidarImei1()
        {
            RuleFor(a => a.Imei1).NotEmpty().WithMessage("- Campo Imei1 é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
