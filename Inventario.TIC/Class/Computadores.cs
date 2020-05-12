using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Computadores : AbstractValidator<Computadores>
    {
        protected ValidationResult ValidationResult { get; set; }
        public int Id { get; set; }
        public string AtivoAntigo { get; set; }
        public string AtivoNovo { get; set; }
        public string Usuario { get; set; }
        public string Departamento { get; set; }
        public string Status { get; set; }
        public string Status1 { get; set; }
        public int OCSId { get; set; }
        public string TemLigacaoComOCS { get; set; }
        public ComputadoresOCS ComputadoresOCS { get; set; }
        public List<Disco> Discos { get; set; }
        public List<HistoricoUsuariosComputadores> HistoricoUsuarios { get; set; }
        public string Observacoes { get; set; }


        public Computadores()
        {
            ComputadoresOCS = new ComputadoresOCS();
            Discos = new List<Disco>();
            HistoricoUsuarios = new List<HistoricoUsuariosComputadores>();
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
            ValidarAtivoAntigo();
            ValidarAtivoNovo();
            ValidarUsuario();
            ValidarDepartamento();
        }

        private void ValidarAtivoAntigo()
        {
            RuleFor(a => a.AtivoAntigo).NotEmpty().WithMessage("- Campo Ativo Antigo é obrigatório");
        }

        private void ValidarAtivoNovo()
        {
            RuleFor(a => a.AtivoNovo).NotEmpty().WithMessage("- Campo Ativo Novo é obrigatório");
        }

        private void ValidarUsuario()
        {
            RuleFor(a => a.Usuario).NotEmpty().WithMessage("- Campo Usuário é obrigatório");
        }

        private void ValidarDepartamento()
        {
            RuleFor(a => a.Departamento).NotEmpty().WithMessage("- Campo Departamento é obrigatório");
        }

        private void ValidarStatus()
        {
            RuleFor(a => a.Status).NotEmpty().WithMessage("- Campo Status é obrigatório");
        }


        public string GetErros()
        {
            var erros = "";
            ValidationResult.Errors.ToList().ForEach(e => erros += e.ErrorMessage + ";");
            return erros;
        }
    }
}
