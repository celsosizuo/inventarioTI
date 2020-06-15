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
    public class TermoComputador : AbstractValidator<TermoComputador>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ComputadorId { get; set; }
        public int? DispositivoAlugadoId { get; set; }
        public int CarregadorId { get; set; }
        public int GestorId { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorDispositivo { get; set; }
        public decimal ValorMaleta { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Motivo { get; set; }
        public string LinkEntrega { get; set; }
        public string LinkDevolucao { get; set; }

        public Usuario Usuario { get; set; }
        public Computadores Computador { get; set; }
        public DispositivoAlugado DispositivoAlugado { get; set; }
        public Carregador Carregador { get; set; }
        public Gestor Gestor { get; set; }

        public bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarCarregador();
            ValidarUsuario();
            ValidarGestor();
            ValidarDataEntrega();
            ValidarValorDispositivo();
            ValidarValorMaleta();
        }

        private void ValidarCarregador()
        {
            RuleFor(a => a.Carregador).NotNull().WithMessage("- Campo Carregador é obrigatório");
        }

        private void ValidarUsuario()
        {
            RuleFor(a => a.Usuario).NotNull().WithMessage("- Campo Usuario é obrigatório");
        }

        private void ValidarGestor()
        {
            RuleFor(a => a.Gestor).NotNull().WithMessage("- Campo Gestor é obrigatório");
        }
        private void ValidarDataEntrega()
        {
            RuleFor(a => a.DataEntrega).NotEmpty().WithMessage("- Campo Data de Entrega é obrigatório");
        }

        private void ValidarValorDispositivo()
        {
            RuleFor(a => a.ValorDispositivo).NotEmpty().WithMessage("- Campo Valor do Dispositivo é obrigatório");
        }

        private void ValidarValorMaleta()
        {
            RuleFor(a => a.ValorMaleta).NotEmpty().WithMessage("- Campo Valor da Maleta é obrigatório");
        }

        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
