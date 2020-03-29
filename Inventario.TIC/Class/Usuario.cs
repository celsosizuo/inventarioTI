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

        public Usuario()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
