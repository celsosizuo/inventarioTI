using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ComputadoresLicencas : AbstractValidator<ComputadoresLicencas>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int ComputadoresId { get; set; }
        public int LicencaId { get; set; }
        public Computadores Computadores { get; set; }
        public List<Licenca> Licencas { get; set; }

        public ComputadoresLicencas()
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
            RuleFor(a => a.ComputadoresId).NotEmpty().WithMessage("- Campo Computador é obrigatório");
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
