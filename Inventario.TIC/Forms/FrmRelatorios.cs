using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC.Forms
{
    public partial class FrmRelatorios : Form
    {
        public FrmRelatorios(string relatorio)
        {
            InitializeComponent();
            this.reportViewer1.ServerReport.ReportPath = "/TI/" + relatorio;
            this.reportViewer1.RefreshReport();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {

        }
    }
}
