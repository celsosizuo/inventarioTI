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
    public class TermoCelular : AbstractValidator<TermoCelular>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int LinhaId { get; set; }
        public int AparelhoId { get; set; }
        public int CarregadorId { get; set; }
        public int GestorId { get; set; }
        public int FoneOuvido { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string LinkEntrega { get; set; }
        public string LinkDevolucao { get; set; }

        public Aparelho Aparelho { get; set; }
        public Linha Linha { get; set; }
        public Carregador Carregador { get; set; }
        public Gestor Gestor { get; set; }
        public List<Usuario> Usuario { get; set; }

        public TermoCelular()
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
            // ValidarUsuario();
            ValidarAparelho();
        }

        private void ValidarLinha()
        {
            RuleFor(a => a.LinhaId).NotEmpty().WithMessage("- Campo Linha é obrigatório");
        }

        //private void ValidarUsuario()
        //{
        //    RuleFor(a => a.UsuarioId).NotEmpty().WithMessage("- Campo Usuario é obrigatório");
        //}

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

        public static explicit operator TermoCelular(TermoCelularResponse entity)
        {
            TermoCelular celular = new TermoCelular()
            {
                AparelhoId = entity.AparelhoId,
                CarregadorId = entity.CarregadorId,
                DataDevolucao = entity.DataDevolucao,
                DataEntrega = entity.DataEntrega,
                FoneOuvido = entity.FoneOuvido,
                GestorId = entity.GestorId,
                Id = entity.Id,
                LinhaId = entity.LinhaId,
                LinkDevolucao = entity.LinkDevolucao,
                LinkEntrega = entity.LinkEntrega,
            };

            return celular;
        }
    }
}
