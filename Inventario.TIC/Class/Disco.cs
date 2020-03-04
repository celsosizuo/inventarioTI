using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class Disco
    {
        public int Id { get; set; }
        public int HardwareId { get; set; }
        public string Letter { get; set; }
        public string Type { get; set; }
        public string FileSystem { get; set; }
        public decimal Total { get; set; }
        public decimal Free { get; set; }
        public string Volumn { get; set; }
    }
}
