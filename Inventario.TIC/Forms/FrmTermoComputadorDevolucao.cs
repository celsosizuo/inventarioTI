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
    public partial class FrmTermoComputadorDevolucao : Form
    {
        private TermoComputadorResponse _termoComputadorResponse;
        private TermoComputadorRepository _termoRepository;
        private TermoComputador _termoComputador;
        public FrmTermoComputador _parentForm { get; set; }


        public FrmTermoComputadorDevolucao(TermoComputadorResponse termoComputadorResponse, TermoComputador termoComputador, FrmTermoComputador parent)
        {
            InitializeComponent();
            _termoComputadorResponse = termoComputadorResponse;
            _termoComputador = termoComputador;
            _parentForm = parent;
            _termoRepository = new TermoComputadorRepository();
        }

        private void FrmTermoComputadorDevolucao_Load(object sender, EventArgs e)
        {
            List<TermoComputadorResponse> termos = new List<TermoComputadorResponse>();

            termos.Add(_termoComputadorResponse);
            this.dgvUsuarios.DataSource = termos;

            this.txtTermoComputadorId.Text = _termoComputadorResponse.Id.ToString();
            this.txtDataDevolucao.Text = _termoComputador.DataDevolucao == null ? "" : _termoComputador.DataDevolucao.ToString();
            this.txtMotivo.Text = _termoComputador.Motivo;

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
                if (this.txtDataDevolucao.Text == "  /  /")
                {
                    MessageBox.Show("Data de devolução é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.txtMotivo.Text == "")
                {
                    MessageBox.Show("Motivo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Você tem certeza que deseja efetuar a devolução do termo selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    TermoComputador termo = _termoRepository.Get().ToList().Find(t => t.Id == _termoComputadorResponse.Id);

                    termo.DataDevolucao = DateTime.Parse(this.txtDataDevolucao.Text);
                    termo.Motivo = this.txtMotivo.Text;

                    _termoRepository.DevolverTermo(termo);

                    // Fechando a tela e atualizando a tela anterior
                    _parentForm.CarregaDataGridView();
                    
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
