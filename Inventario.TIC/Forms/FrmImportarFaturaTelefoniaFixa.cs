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
    public partial class FrmImportarFaturaTelefoniaFixa : Form
    {
        bool sucesso = false;
        string retorno = "";

        public FrmImportarFaturaTelefoniaFixa()
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
                if (this.txtArquivo.Text != "")
                {
                    if (this.txtReferencia.Text == "  /")
                    {
                        MessageBox.Show("Favor digitar uma referência válida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int ret = 0;
                        DetalheFaturaTelefoniaFixa a = new DetalheFaturaTelefoniaFixa();
                        ret = Convert.ToInt32(a.ImportarDados(this.txtArquivo.Text, this.txtReferencia.Text));
                        retorno = ret.ToString();

                        sucesso = true;
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um arquivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                sucesso = false;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.lblQtdeRegistros.Text = "";
            this.lblTempo.Text = "";

            try
            {
                using (FrmWaitingForm frm = new FrmWaitingForm(Importar))
                {
                    try
                    {
                        frm.ShowDialog(this);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                if (sucesso)
                {
                    MessageBox.Show("Importação finalizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.lblQtdeRegistros.Text = retorno;
                    this.lblTempo.Text = Module1.tempoImportacao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
