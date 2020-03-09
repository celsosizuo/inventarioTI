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
    public partial class FrmVisualizadorAdobe : Form
    {
        public FrmVisualizadorAdobe(string link)
        {
            InitializeComponent();
            axAcroPDF1.LoadFile(link);
        }

        private void FrmVisualizadorAdobe_Load(object sender, EventArgs e)
        {

        }
    }
}
