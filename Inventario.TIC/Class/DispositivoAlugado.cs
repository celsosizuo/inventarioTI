using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventario.TIC.Class
{
    public class DispositivoAlugado : AbstractValidator<DispositivoAlugado>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public TipoDispositivo TipoDispositivo { get; set; }
        public int TipoDispositivoId { get; set; }
        public string NomeTipoDispositivo { get; set; }
        public Usuario Usuario { get; set; }
        public string NomeUsuario { get; set; }
        public int UsuarioId { get; set; }
        public string Ativo { get; set; }
        public string Modelo { get; set; }
        public decimal Valor { get; set; }
        public bool Avulso { get; set; }

        public DispositivoAlugado()
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
            ValidarTipoDispositivo();
            ValidarUsuario();
            ValidarAtivo();
            ValidarModelo();
            ValidarValor();
            ValidarAvulso();
        }

        private void ValidarTipoDispositivo()
        {
            RuleFor(a => a.TipoDispositivoId).NotEmpty().WithMessage("- Campo TipoDispositivo é obrigatório");
        }

        private void ValidarUsuario()
        {
            RuleFor(a => a.UsuarioId).NotEmpty().WithMessage("- Campo Usuario é obrigatório");
        }

        private void ValidarAtivo()
        {
            RuleFor(a => a.Ativo).NotEmpty().WithMessage("- Campo Ativo é obrigatório");
        }

        private void ValidarModelo()
        {
            RuleFor(a => a.Modelo).NotEmpty().WithMessage("- Campo Modelo é obrigatório");
        }

        private void ValidarValor()
        {
            RuleFor(a => a.Valor).NotEmpty().WithMessage("- Campo Valor é obrigatório");
        }

        private void ValidarAvulso()
        {
            RuleFor(a => a.Avulso).NotEmpty().WithMessage("- Campo Avulso é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
