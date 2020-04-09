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
    public partial class FrmImportarFatura : Form
    {
        string retorno = "";

        public FrmImportarFatura()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.txtArquivo.Text = this.openFileDialog1.FileName.ToString();
        }

        void Importar()
        {
            try
            {
                LeituraFaturaDetalhada a = new LeituraFaturaDetalhada();

                if (this.txtArquivo.Text != "")
                {
                    retorno = a.ImportarDados(this.txtArquivo.Text);                   
                }
                else
                    MessageBox.Show("Favor selecionar um arquivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (FrmWaitingForm frm = new FrmWaitingForm(Importar))
            {
                frm.ShowDialog(this);
            }
            MessageBox.Show("Importação finalizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.lblQtdeRegistros.Text = retorno;
            this.lblTempo.Text = Module1.tempoImportacao;
        }

        private void FrmImportarFatura_Load(object sender, EventArgs e)
        {
            this.lblQtdeRegistros.Text = "";
            this.lblTempo.Text = "";
        }
    }
}
