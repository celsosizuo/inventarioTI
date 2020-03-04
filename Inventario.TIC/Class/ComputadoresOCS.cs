using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ComputadoresOCS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddr { get; set; }
        public string OsName { get; set; }
        public string UserId { get; set; }
        public string WinProdId { get; set; }
        public string WinProdKey { get; set; }
        public string WorkGroup { get; set; }
        public string processorT { get; set; }
        public decimal Memory { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime LastCome { get; set; }

    }
}
