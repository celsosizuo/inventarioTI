using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Computadores
    {
        public int Id { get; set; }
        public string AtivoAntigo { get; set; }
        public string AtivoNovo { get; set; }
        public string Usuario { get; set; }
        public string Departamento { get; set; }
        public string Status { get; set; }
        public int OCSId { get; set; }
        public ComputadoresOCS ComputadoresOCS { get; set; }
        public List<Disco> Discos { get; set; }
    }
}
