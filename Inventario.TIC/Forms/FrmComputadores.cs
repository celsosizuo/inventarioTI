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
    public partial class FrmComputadores : Form
    {
        private List<Computadores> _computadores;

        public FrmComputadores()
        {
            InitializeComponent();
            _computadores = new List<Computadores>();
        }

        private void AtualizaDataGridView()
        {
            this.dgvComputadores.DataSource = null;
            this.dgvComputadores.DataSource = _computadores;

            // Ocultando colunas desnecessárias
            this.dgvComputadores.Columns["ComputadoresOCS"].Visible = false;
            this.dgvComputadores.Columns["OCSId"].Visible = false;
            this.dgvComputadores.Columns["Status1"].Visible = false;
            this.dgvComputadores.Columns["CascadeMode"].Visible = false;
        }

        private void FrmComputadores_Load(object sender, EventArgs e)
        {
            try
            {
                // Carregando a lista de computadores
                ComputadoresRepository c = new ComputadoresRepository();
                _computadores = c.Get();
                this.dgvComputadores.DataSource = _computadores;
                this.AtualizaDataGridView();

                // Carregando lista dos status do computador
                ComputadorStatusRepository csr = new ComputadorStatusRepository();
                List<ComputadorStatus> cs = csr.GetComputadorStatuses();
                this.cboStatus.DataSource = cs;
                this.cboStatus.DisplayMember = "Status";
                this.cboStatus.ValueMember = "CodStatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void dgvComputadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(_computadores[e.RowIndex].Discos[0].Letter);

            // carregando os controles do computador
            this.txtId.Text = _computadores[e.RowIndex].Id.ToString();
            this.txtAtivoAntigo.Text = _computadores[e.RowIndex].AtivoAntigo.ToString();
            this.txtAtivoNovo.Text = _computadores[e.RowIndex].AtivoNovo.ToString();
            this.txtUsuario.Text = _computadores[e.RowIndex].Usuario.ToString();
            this.txtDepartamento.Text = _computadores[e.RowIndex].Departamento.ToString();
            this.cboStatus.SelectedValue = _computadores[e.RowIndex].Status1.ToString();

            //carregando os controles do OCS
            if(_computadores[e.RowIndex].ComputadoresOCS == null)
            {
                this.txtOCSId.Text = "";
                this.txtOCSName.Text = "";
                this.txtOCSIpAddr.Text = "";
                this.txtOCSUserId.Text = "";
                this.txtOCSWorkGroup.Text = "";
                this.txtOCSOsName.Text = "";
                this.txtOCSWinProdId.Text = "";
                this.txtOCSWinProdKey.Text = "";
                this.txtOCSProcessorT.Text = "";
                this.txtOCSMemory.Text = "";
            }
            else
            {
                this.txtOCSId.Text = _computadores[e.RowIndex].ComputadoresOCS.Id == null ? "" : _computadores[e.RowIndex].ComputadoresOCS.Id.ToString();
                this.txtOCSName.Text = _computadores[e.RowIndex].ComputadoresOCS.Name.ToString();
                this.txtOCSIpAddr.Text = _computadores[e.RowIndex].ComputadoresOCS.IpAddr.ToString();
                this.txtOCSUserId.Text = _computadores[e.RowIndex].ComputadoresOCS.UserId == null ? "" : _computadores[e.RowIndex].ComputadoresOCS.UserId.ToString();
                this.txtOCSWorkGroup.Text = _computadores[e.RowIndex].ComputadoresOCS.WorkGroup.ToString();
                this.txtOCSOsName.Text = _computadores[e.RowIndex].ComputadoresOCS.OsName.ToString();
                this.txtOCSWinProdId.Text = _computadores[e.RowIndex].ComputadoresOCS.WinProdId.ToString();
                this.txtOCSWinProdKey.Text = _computadores[e.RowIndex].ComputadoresOCS.WinProdKey.ToString();
                this.txtOCSProcessorT.Text = _computadores[e.RowIndex].ComputadoresOCS.ProcessorT.ToString();
                this.txtOCSMemory.Text = _computadores[e.RowIndex].ComputadoresOCS.Memory.ToString();

            }

            // carregando os dicos
            this.dgvDiscos.DataSource = _computadores[e.RowIndex].Discos;
            this.dgvDiscos.Columns["Id"].Visible = false;
            this.dgvDiscos.Columns["HardwareId"].Visible = false;
            this.dgvDiscos.Columns["Letter"].HeaderText = "Letra da Unidade";
            this.dgvDiscos.Columns["Type"].HeaderText = "Tipo";
            this.dgvDiscos.Columns["FileSystem"].HeaderText = "Sistema de Arquivos";
            this.dgvDiscos.Columns["Volumn"].HeaderText = "Volume";
            this.dgvDiscos.Columns["Total"].HeaderText = "Espaço Total (MB)";
            this.dgvDiscos.Columns["Free"].HeaderText = "Espaço Livre (MB)";

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            // Limpando os dados do computador
            this.txtId.Text = "";
            this.txtAtivoAntigo.Text = "";
            this.txtAtivoNovo.Text = "";
            this.txtUsuario.Text = "";
            this.txtDepartamento.Text = "";
            this.cboStatus.SelectedValue = "";

            // Limpando os dados do OCS
            this.txtOCSId.Text = "";
            this.txtOCSName.Text = "";
            this.txtOCSIpAddr.Text = "";
            this.txtOCSUserId.Text = "";
            this.txtOCSWorkGroup.Text = "";
            this.txtOCSOsName.Text = "";
            this.txtOCSWinProdId.Text = "";
            this.txtOCSWinProdKey.Text = "";
            this.txtOCSProcessorT.Text = "";
            this.txtOCSMemory.Text = "";

            // Limpando grid dos discos
            this.dgvDiscos.DataSource = null;

            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ComputadoresRepository cRepository = new ComputadoresRepository();
                Computadores c;

                if(this.txtId.Text == "")
                    c = new Computadores();
                else
                    c = _computadores.Find(co => co.Id ==  int.Parse(this.txtId.Text));

                c.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                c.AtivoAntigo = this.txtAtivoAntigo.Text;
                c.AtivoNovo = this.txtAtivoNovo.Text;
                c.Usuario = this.txtUsuario.Text;
                c.Departamento = this.txtDepartamento.Text;
                c.Status1 = this.cboStatus.SelectedValue.ToString();
                c.Status = this.cboStatus.Text;

                if (c.EhValido())
                {
                    if(c.Id == 0)
                    {
                        string retorno = cRepository.Add(c);
                        this.txtId.Text = retorno.ToString();
                        c.Id = int.Parse(retorno);
                        c.TemLigacaoComOCS = "Não";
                        _computadores.Add(c);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        cRepository.Update(c);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = c.GetErros().Split(';');
                    string msg = "Todos os campos com (*) são obrigatórios. \n";
                    msgs.ToList().ForEach(m => msg += m + "\n");
                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ComputadoresRepository cRepository = new ComputadoresRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    cRepository.Delete(id);

                    _computadores.Remove(_computadores.Find(c => c.Id == id));
                    this.AtualizaDataGridView();

                    MessageBox.Show("Registro excluído com sucesso", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var computadoresOriginal = _computadores;
            var c = _computadores.Find(co => co.AtivoNovo == this.txtAtivoNovo.Text);

            // computadores = c;

            this.AtualizaDataGridView();
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            Computadores computador;
            ComputadoresRepository c = new ComputadoresRepository();

            if (this.txtId.Text != "")
            {
                computador = _computadores.Find(co => co.Id == int.Parse(this.txtId.Text));
                var computadoresOCS = c.FindComputadoresOCS(this.txtAtivoNovo.Text);

                if (computadoresOCS.Count > 1)
                {

                }
                else
                {
                    if (MessageBox.Show("Você tem certeza que deseja efetuar a associação?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        computador.OCSId = (int)computadoresOCS.FirstOrDefault().Id;
                        c.AssociarOCS(computador.Id, computador.OCSId);

                        computador.TemLigacaoComOCS = "Sim";
                        computador.ComputadoresOCS = computadoresOCS.FirstOrDefault();


                        this.AtualizaDataGridView();


                    }
                }
            }
            else
                MessageBox.Show("Favor selecionar um registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
