using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Access : AbstractValidator<Access>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string EnderecoAcesso { get; set; }
        public string Observacao { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Access()
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
            ValidarEnderecoAcesso();
        }

        private void ValidarEnderecoAcesso()
        {
            RuleFor(a => a.EnderecoAcesso).NotEmpty().WithMessage("- Campo EnderecoAcesso é obrigatório");
        }

        private void ValidarUsuario()
        {
            RuleFor(a => a.Usuario).NotEmpty().WithMessage("- Campo Usuario é obrigatório");
        }

        private void ValidarSenha()
        {
            RuleFor(a => a.Senha).NotEmpty().WithMessage("- Campo Senha é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

    }
}
