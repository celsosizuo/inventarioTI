using Inventario.TIC.Class;
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
    public partial class FrmNotaFiscal : Form
    {
        private List<NotaFiscal> _notasFiscais;

        public FrmNotaFiscal()
        {
            InitializeComponent();
            _notasFiscais = new List<NotaFiscal>();
        }

        private void FrmNotaFiscal_Load(object sender, EventArgs e)
        {
            NotaFiscalRepository nf = new NotaFiscalRepository();

            _notasFiscais = nf.Get();
            this.dgvNotasFiscais.DataSource = _notasFiscais;

        }
    }
}
