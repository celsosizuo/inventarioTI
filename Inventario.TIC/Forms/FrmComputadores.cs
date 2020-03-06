using Inventario.TIC.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC.Forms
{
    public partial class FrmComputadores : Form
    {
        private List<Computadores> _computadores;
        private List<Computadores> _computadoresOriginal;
        private string _colunaSelecionada;

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
                this.CarregarDataGridView();
                _computadoresOriginal = _computadores;

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

        private void CarregarDataGridView()
        {
            // _computadores = _computadoresOriginal.Where(c => c.AtivoNovo == "ARTFIX-SRV01").ToList();

            // Carregando a lista de computadores
            ComputadoresRepository c = new ComputadoresRepository();
            _computadores = c.Get();
            this.dgvComputadores.DataSource = _computadores;
            this.AtualizaDataGridView();
        }
               
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void limparCampos()
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

                    this.limparCampos();

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
            if (this.txtAtivoAntigo.Text != "")
                this.Pesquisar("AtivoAntigo", this.txtAtivoAntigo.Text);
            else if (this.txtAtivoNovo.Text != "")
                this.Pesquisar("AtivoNovo", this.txtAtivoNovo.Text);
            else if (this.txtUsuario.Text != "")
                this.Pesquisar("Usuario", this.txtUsuario.Text);
            else if (this.txtDepartamento.Text != "")
                this.Pesquisar("Departamento", this.txtDepartamento.Text);
            else if (this.cboStatus.SelectedIndex > 0)
                this.Pesquisar("Status", this.cboStatus.SelectedValue.ToString());
            else
                this.Pesquisar("", "");
        }   

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "AtivoAntigo":
                    _computadores = _computadoresOriginal.Where(c => c.AtivoAntigo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "AtivoNovo":
                    _computadores = _computadoresOriginal.Where(c => c.AtivoNovo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Usuario":
                    _computadores = _computadoresOriginal.Where(c => c.Usuario.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Departamento":
                    _computadores = _computadoresOriginal.Where(c => c.Departamento.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Status":
                    _computadores = _computadoresOriginal.Where(c => c.Status1.ToUpper() == texto.ToUpper()).ToList();
                    break;
                default:
                    _computadores = _computadoresOriginal;
                    break;              
                    // this.dgvComputadores.DataSource = _computadores;
            }
            this.AtualizaDataGridView();
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            Computadores computador;
            ComputadoresRepository c = new ComputadoresRepository();

            if (this.txtId.Text != "")
            {
                computador = _computadores.Find(co => co.Id == int.Parse(this.txtId.Text));

                if (computador.TemLigacaoComOCS == "Não")
                {
                    var computadoresOCS = c.FindComputadoresOCS(this.txtAtivoNovo.Text);

                    if (computadoresOCS.Count == 0)
                    {
                        MessageBox.Show("Não foi encontrato computador no OCS com o código de ativo " + computador.AtivoNovo + ". Favor escanear o OCS e tentar fazer a associação novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (computadoresOCS.Count == 1)
                    {
                        if (MessageBox.Show("Este procedimento irá varrer a lista de computadores do OCS e verificar se o número do ativo novo existe no OCS. Se encontrar irá fazer a associação automaticamente. \n Você tem certeza que deseja efetuar a associação?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            computador.OCSId = (int)computadoresOCS.FirstOrDefault().Id;
                            c.AssociarOCS(computador.Id, computador.OCSId);
                            this.CarregarDataGridView();
                            MessageBox.Show("Associação efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                        MessageBox.Show("Existem dois ou mais computadores no OCS com o ativo " + computadoresOCS.FirstOrDefault().Name + ". Favor verificar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Este computador já está associado. Não é possível fazer a associação novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Favor selecionar um registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvComputadores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvComputadores.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "AtivoAntigo":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.AtivoAntigo).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.AtivoAntigo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "AtivoNovo":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.AtivoNovo).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.AtivoNovo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Usuario":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.Usuario).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.Usuario).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Departamento":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.Departamento).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.Departamento).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Status":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.Status).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.Status).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "TemLigacaoComOCS":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _computadores = _computadores.OrderBy(x => x.TemLigacaoComOCS).ToList();
                    }
                    else
                    {
                        _computadores = _computadores.OrderByDescending(x => x.TemLigacaoComOCS).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvComputadores_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(_computadores[e.RowIndex].Discos[0].Letter); 

            try
            {
                // carregando os controles do computador
                this.txtId.Text = _computadores[e.RowIndex].Id.ToString();
                this.txtAtivoAntigo.Text = _computadores[e.RowIndex].AtivoAntigo.ToString();
                this.txtAtivoNovo.Text = _computadores[e.RowIndex].AtivoNovo.ToString();
                this.txtUsuario.Text = _computadores[e.RowIndex].Usuario.ToString();
                this.txtDepartamento.Text = _computadores[e.RowIndex].Departamento.ToString();
                this.cboStatus.SelectedValue = _computadores[e.RowIndex].Status1.ToString();

                //carregando os controles do OCS
                if (_computadores[e.RowIndex].ComputadoresOCS == null)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarDados_Click(object sender, EventArgs e)
        {
            this.CarregarDataGridView();
        }
    }
}
