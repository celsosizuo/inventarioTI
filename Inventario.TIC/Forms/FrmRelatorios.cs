using Inventario.TIC.Class;
using Microsoft.Reporting.WinForms;
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
        public FrmRelatorios(string relatorio, List<ParametrosRelatorio> parametro)
        {
            InitializeComponent();
            this.reportViewer1.ServerReport.ReportPath = "/TI/" + relatorio;

            List<ReportParameter> parametro1 = new List<ReportParameter>();

            parametro.ForEach(p =>
            {
                parametro1.Add(new ReportParameter(p.Parametro, p.Valor, true));
            });

            this.reportViewer1.ServerReport.SetParameters(parametro1);
            this.reportViewer1.RefreshReport();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
