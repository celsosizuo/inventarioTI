using FluentValidation;
using FluentValidation.Results;
using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Celular : AbstractValidator<Celular>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int LinhaId { get; set; }
        public int UsuarioId { get; set; }
        public int AparelhoId { get; set; }
        public Aparelho Aparelho { get; set; }
        public Linha Linha { get; set; }
        public Usuario Usuario { get; set; }

        public Celular()
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
            ValidarLinha();
            ValidarUsuario();
            ValidarAparelho();
        }

        private void ValidarLinha()
        {
            RuleFor(a => a.LinhaId).NotEmpty().WithMessage("- Campo Linha é obrigatório");
        }

        private void ValidarUsuario()
        {
            RuleFor(a => a.UsuarioId).NotEmpty().WithMessage("- Campo Usuario é obrigatório");
        }

        private void ValidarAparelho()
        {
            RuleFor(a => a.AparelhoId).NotEmpty().WithMessage("- Campo Aparelho é obrigatório");
        }


        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }

        public static explicit operator Celular(CelularResponse entity)
        {
            Celular celular = new Celular()
            {
                Id = entity.Id,
                AparelhoId = entity.AparelhoId,
                LinhaId = entity.LinhaId,
                UsuarioId = entity.UsuarioId
            };

            return celular;
        }
    }
}
