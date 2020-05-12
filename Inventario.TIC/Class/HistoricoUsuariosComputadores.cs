using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class HistoricoUsuariosComputadores
    {
        public int Id { get; set; }
        public int ComputadoresId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataMudanca { get; set; }

    }
}
