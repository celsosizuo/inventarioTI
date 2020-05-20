using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class DispositivoAlugadoLicencas : AbstractValidator<DispositivoAlugadoLicencas>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int DispositivoAlugadoId { get; set; }
        public int LicencaId { get; set; }
        public DispositivoAlugado DispositivoAlugado { get; set; }
        public List<Licenca> Licencas { get; set; }

        public DispositivoAlugadoLicencas()
        {
            Licencas = new List<Licenca>();
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
            ValidarComputador();
            ValidarLicenca();
        }

        private void ValidarComputador()
        {
            RuleFor(a => a.DispositivoAlugadoId).NotEmpty().WithMessage("- Campo Computador é obrigatório");
        }

        private void ValidarLicenca()
        {
            RuleFor(a => a.LicencaId).NotEmpty().WithMessage("- Campo Licença é obrigatório");
        }   

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
