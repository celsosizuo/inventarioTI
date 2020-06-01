using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Movimentos : AbstractValidator<Movimentos>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public DateTime Data { get; set; }
        public string Solicitante { get; set; }
        public string Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public Produto Produto { get; set; }

        public Movimentos()
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
            ValidarProduto();
            ValidarData();
            ValidarSolicitante();
        }

        private void ValidarProduto()
        {
            RuleFor(a => a.ProdutoId).NotEmpty().WithMessage("- Campo Produto é obrigatório");
        }

        private void ValidarData()
        {
            RuleFor(a => a.Data)
                .NotEmpty().WithMessage("- Campo Data é obrigatório")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("- Campo data tem que ser maior ou igual a data atual");
        }

        private void ValidarSolicitante()
        {
            RuleFor(a => a.Solicitante).NotEmpty().WithMessage("- Campo Solicitante é obrigatório");
        }

        private void ValidarQuantidade()
        {
            RuleFor(a => a.Quantidade).NotEmpty().WithMessage("- Campo Quantidade é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
