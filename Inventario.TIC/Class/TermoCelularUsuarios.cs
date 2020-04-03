using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TermoCelularUsuarios
    {
        public int TermoCelularId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Motivo { get; set; }
    }
}
