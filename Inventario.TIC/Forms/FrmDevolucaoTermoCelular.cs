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
    public partial class FrmDevolucaoTermoCelular : Form
    {
        private TermoCelular _termoCelular;
        public FrmTermoCelular _parentForm { get; set; }

        public FrmDevolucaoTermoCelular(TermoCelular termoCelular, FrmTermoCelular parent)
        {
            InitializeComponent();
            _termoCelular = termoCelular;
            _parentForm = parent;
        }

        private void FrmDevolucaoTermoCelular_Load(object sender, EventArgs e)
        {
            this.txtTermoId.Text = _termoCelular.Id.ToString();
            // this.txtDataDevolucao.Text = _termoCelular.Usuarios[0].DataDevolucao == null ? "" : _termoCelular.Usuarios[0].DataDevolucao.ToString();
            // this.txtMotivo.Text = _termoCelular.Usuarios[0].Motivo == null ? "" : _termoCelular.Usuarios[0].Motivo.ToString();
            this.dgvUsuarios.DataSource = _termoCelular.Usuario;
            this.dgvUsuarios.Columns["CascadeMode"].Visible = false;

            if(this.txtDataDevolucao.Text != "  /  /" && this.txtMotivo.Text != "")
            {
                this.txtDataDevolucao.ReadOnly = true;
                this.txtMotivo.ReadOnly = true;
                this.btnDevolver.Enabled = false;
                this.lblAviso.Text = "Este termo já foi devolvido. Não é possível devolvê-lo novamente.";
            }
            else
                this.lblAviso.Text = "";
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtDataDevolucao.Text == "  /  /")
                {
                    MessageBox.Show("Data de devolução é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(this.txtMotivo.Text == "")
                {
                    MessageBox.Show("Motivo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Você tem certeza que deseja efetuar a devolução do termo do usuário selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    // parei aqui;
                    






                    // Metodo antigo
                    //_termoCelular.Usuario[this.dgvUsuarios.CurrentRow.Index].DataDevolucao = DateTime.Parse(this.txtDataDevolucao.Text);
                    //_termoCelular.Usuario[this.dgvUsuarios.CurrentRow.Index].Motivo = this.txtMotivo.Text;

                    //TermoCelularUsuarios termoCelularUsuarios = _termoCelular.UsuariosTermos[this.dgvUsuarios.CurrentRow.Index];
                    //TermoCelularUsuarioRepository termoCelularUsuarioRepository = new TermoCelularUsuarioRepository();

                    //termoCelularUsuarios.DataDevolucao = DateTime.Parse(this.txtDataDevolucao.Text);
                    //termoCelularUsuarios.Motivo = this.txtMotivo.Text;
                    //termoCelularUsuarioRepository.PathDataDevolucao(termoCelularUsuarios);


                    // Fechando a tela e atualizando a tela anterior
                    _parentForm.CarregarDataGridView();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}