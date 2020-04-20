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
    public partial class FrmExcluirFatura : Form
    {
        public FrmExcluirFatura()
        {
            InitializeComponent();
        }

        private void CarregaCheckedListBox()
        {
            DetalheFaturaTelefoniaMovel f = new DetalheFaturaTelefoniaMovel();

            ((ListBox)this.checkedListBox1).DataSource = f.GetReferencia();
            ((ListBox)this.checkedListBox1).DisplayMember = "referencia";
            // ((ListBox)this.checkedListBox1).ValueMember = "referencia";
        }

        private void FrmExcluirFatura_Load(object sender, EventArgs e)
        {
            this.CarregaCheckedListBox();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Você tem certeza que deseja excluir as faturas selecionadas?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DetalheFaturaTelefoniaMovel f = new DetalheFaturaTelefoniaMovel();

                    foreach (var item in this.checkedListBox1.CheckedItems)
                        f.ExcluirContaExcel(item.ToString());

                    this.CarregaCheckedListBox();
                    MessageBox.Show("Registros excluídos com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
