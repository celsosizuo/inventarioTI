using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class ComputadorStatus
    {
        public string CodStatus { get; set; }
        public string Status { get; set; }

        public ComputadorStatus()
        {
            this.CodStatus = "";
            this.Status = "";
        }
    }
}
