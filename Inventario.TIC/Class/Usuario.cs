using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Usuario : AbstractValidator<Usuario>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string Chapa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string StatusTermo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int Terceiro { get; set; }
        public string TerceiroDescricao { get; set; }
        public string Motivo { get; set; }
        public string LinkEntrega { get; set; }
        public string LinkDevolucao { get; set; }
        public string CodCCusto { get; set; }
        public string CentroCusto { get; set; }

        public Usuario()
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
            ValidarChapa();
            ValidarCPF();
            ValidarTerceiro();
        }

        private void ValidarTerceiro()
        {
            RuleFor(a => a.Terceiro).NotNull().WithMessage("- Campo Terceiro é obrigatório");
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage("- Campo Nome é obrigatório");
        }

        private void ValidarChapa()
        {
            RuleFor(a => a.Chapa)
                .NotEmpty().WithMessage("- Campo Chapa é obrigatório");
                // .NotEqual(teste == null ? "" : teste.Chapa).WithMessage("- A chapa informada já está cadastrada");
        }

        private void ValidarCPF()
        {
            UsuarioRepository usuario = new UsuarioRepository();
            List<Usuario> usuariosCadastrados = usuario.Get();

            var teste = usuariosCadastrados.Find(x => x.Cpf == this.Cpf);

            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("- Campo CPF é obrigatório");
                // .NotEqual(teste == null ? "" : teste.Cpf).WithMessage("- O CPF informadao já está cadastrado");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
