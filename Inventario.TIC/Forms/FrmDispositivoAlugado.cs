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
    public partial class FrmDispositivoAlugado : Form
    {
        private List<DispositivoAlugado> _dispositivosAlugado;
        private List<DispositivoAlugado> _dispositivivosAlugadoOriginal;
        private string _colunaSelecionada;
        private List<Usuario> _usuarios;
        private List<TipoDispositivo> _tipoDispositivo;
        private Usuario _usuarioSelecionado;

        public FrmDispositivoAlugado()
        {
            InitializeComponent();
            _dispositivosAlugado = new List<DispositivoAlugado>();
            _dispositivivosAlugadoOriginal = new List<DispositivoAlugado>();
            _tipoDispositivo = new List<TipoDispositivo>();
            _usuarios = new List<Usuario>();
            _usuarioSelecionado = new Usuario();
        }

        private void AtualizaDataGridView()
        {
            this.dgvComputadores.DataSource = null;
            this.dgvComputadores.DataSource = _dispositivosAlugado;

            // Ocultando colunas desnecessárias
            this.dgvComputadores.Columns["TipoDispositivo"].Visible = false;
            this.dgvComputadores.Columns["TipoDispositivoId"].Visible = false;
            this.dgvComputadores.Columns["Usuario"].Visible = false;
            this.dgvComputadores.Columns["usuarioId"].Visible = false;
            this.dgvComputadores.Columns["OCSId"].Visible = false;
            this.dgvComputadores.Columns["CascadeMode"].Visible = false;
            this.dgvComputadores.Columns["ComputadoresOCS"].Visible = false;
            // this.dgvComputadores.Columns["Discos"].Visible = false;
        }

        private void CarregarDataGridView()
        {
            // Carregando a lista de computadores
            DispositivoAlugadoRepository c = new DispositivoAlugadoRepository();
            _dispositivosAlugado = null;
            _dispositivosAlugado = c.Get();
            _dispositivivosAlugadoOriginal = _dispositivosAlugado;
            this.dgvComputadores.DataSource = _dispositivosAlugado;
            this.AtualizaDataGridView();
        }

        private void CarregaTipoDispositivo()
        {
            TipoDispositivoRepository t = new TipoDispositivoRepository();

            _tipoDispositivo = t.Get();
            _tipoDispositivo.Insert(0, new TipoDispositivo());

            _tipoDispositivo = _tipoDispositivo.OrderBy(x => x.Tipo).ToList();

            this.cboTipoDispositivo.DataSource = _tipoDispositivo;
            this.cboTipoDispositivo.ValueMember = "Id";
            this.cboTipoDispositivo.DisplayMember = "Tipo";
        }

        private void FrmDispositivoAlugado_Load(object sender, EventArgs e)
        {
            this.CarregaTipoDispositivo();
            this.CarregarDataGridView();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.dgvUsuarios.Visible = true;

                List<Usuario> c = new List<Usuario>();
                UsuarioRepository UsuarioRepository = new UsuarioRepository();

                c = UsuarioRepository.Sincronizar().Where(u => u.Nome.ToUpper().Contains(this.txtUsuario.Text.ToUpper())).ToList();
                _usuarios = c;

                this.dgvUsuarios.DataSource = c;
                this.dgvUsuarios.Focus();
            }

        }

        private void btnNovaPesquisaUsuario_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Clear();
            this.txtUsuarioIdReadOnly.Clear();
            this.txtUsuario.Enabled = true;
            this.txtChapaReadOnly.Clear();
            this.txtCpfReadOnly.Clear();
            this.txtNomeReadOnly.Clear();
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.DataSource = null;
        }

        private void dgvUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.dgvUsuarios.Rows.Count > 0)
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    int RowIndex = this.dgvUsuarios.CurrentRow.Index;

                    //int RowIndex = this.dgvUsuarios.SelectedRows.

                    this.txtUsuarioIdReadOnly.Text = _usuarios[RowIndex].Id.ToString();
                    this.txtNomeReadOnly.Text = _usuarios[RowIndex].Nome.ToString();
                    this.txtChapaReadOnly.Text = _usuarios[RowIndex].Chapa == null ? "" : _usuarios[RowIndex].Chapa.ToString();
                    this.txtCpfReadOnly.Text = _usuarios[RowIndex].Cpf == null ? "" : _usuarios[RowIndex].Cpf.ToString();
                    this.txtUsuario.Text = _usuarios[RowIndex].Nome.ToString();
                    this.txtUsuario.Enabled = false;

                    this.dgvUsuarios.Visible = false;

                    _usuarioSelecionado = _usuarios[RowIndex];
                }
            }
        }

        private void dgvUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                this.txtUsuarioIdReadOnly.Text = _usuarios[e.RowIndex].Id.ToString();
                this.txtNomeReadOnly.Text = _usuarios[e.RowIndex].Nome.ToString();
                this.txtChapaReadOnly.Text = _usuarios[e.RowIndex].Chapa == null ? "" : _usuarios[e.RowIndex].Chapa.ToString();
                this.txtCpfReadOnly.Text = _usuarios[e.RowIndex].Cpf == null ? "" : _usuarios[e.RowIndex].Cpf.ToString();
                this.txtUsuario.Text = _usuarios[e.RowIndex].Nome.ToString();
                this.txtUsuario.Enabled = false;

                this.dgvUsuarios.Visible = false;

                _usuarioSelecionado = _usuarios[e.RowIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DispositivoAlugadoRepository dispositivoRepository = new DispositivoAlugadoRepository();
                DispositivoAlugado dispositivo;

                if (this.txtId.Text == "")
                    dispositivo = new DispositivoAlugado();
                else
                    dispositivo = _dispositivosAlugado.Find(d => d.Id == int.Parse(this.txtId.Text));

                dispositivo.Id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                dispositivo.TipoDispositivoId = int.Parse(this.cboTipoDispositivo.SelectedValue.ToString());
                dispositivo.UsuarioId = int.Parse(this.txtUsuarioIdReadOnly.Text);
                dispositivo.Ativo = this.txtAtivo.Text;
                dispositivo.Modelo = this.txtModelo.Text;
                dispositivo.Valor = decimal.Parse(this.txtValor.Text);
                dispositivo.Avulso = this.chkAvulso.Checked;
                dispositivo.Departamento = this.txtDepartamento.Text;

                if (dispositivo.EhValido())
                {
                    if(dispositivo.Id == 0)
                    {
                        string retorno = dispositivoRepository.Add(dispositivo);
                        this.txtId.Text = retorno.ToString();
                        dispositivo.Id = int.Parse(retorno);
                        dispositivo.NomeUsuario = this.txtNomeReadOnly.Text;
                        dispositivo.TipoDispositivo = _tipoDispositivo[this.cboTipoDispositivo.SelectedIndex];
                        dispositivo.NomeTipoDispositivo = _tipoDispositivo[this.cboTipoDispositivo.SelectedIndex].Tipo;
                        dispositivo.TemLigacaoComOCS = "Não";
                        dispositivo.Usuario = _usuarioSelecionado;
                        dispositivo.ComputadoresOCS = null;
                        _dispositivosAlugado.Add(dispositivo);
                        
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dispositivoRepository.Update(dispositivo);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = dispositivo.GetErros().Split(';');
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

        private void LimparCampos()
        {
            // Limpando campos do dispositivo
            this.txtId.Clear();
            this.cboTipoDispositivo.SelectedIndex = 0;
            this.txtModelo.Clear();
            this.txtAtivo.Clear();
            this.txtValor.Clear();
            this.txtDepartamento.Clear();
            this.chkAvulso.Checked = false;

            // Limpando campos do Usuario
            this.txtUsuario.Clear();
            this.txtUsuarioIdReadOnly.Clear();
            this.txtUsuario.Enabled = true;
            this.txtChapaReadOnly.Clear();
            this.txtCpfReadOnly.Clear();
            this.txtNomeReadOnly.Clear();
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.DataSource = null;

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

            // Limpando o grid de licenças
            this.dgvLicencas.DataSource = null;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DispositivoAlugadoRepository cRepository = new DispositivoAlugadoRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    cRepository.Delete(id);

                    _dispositivosAlugado.Remove(_dispositivosAlugado.Find(c => c.Id == id));
                    this.AtualizaDataGridView();

                    this.LimparCampos();

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
            if (this.txtAtivo.Text != "")
                this.Pesquisar("Ativo", this.txtAtivo.Text);
            else if (this.cboTipoDispositivo.SelectedIndex > 0)
                this.Pesquisar("TipoDispositivo", this.cboTipoDispositivo.SelectedValue.ToString());
            else if (this.txtUsuario.Text != "")
                this.Pesquisar("Usuario", this.txtUsuario.Text);
            else if (this.txtAtivo.Text != "")
                this.Pesquisar("Ativo", this.txtAtivo.Text);
            else if (this.txtModelo.Text != "")
                this.Pesquisar("Modelo", this.txtModelo.Text);
            else if (this.txtDepartamento.Text != "")
                this.Pesquisar("Departamento", this.txtDepartamento.Text);

            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "TipoDispositivo":
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal.Where(c => c.TipoDispositivo.Id == int.Parse(texto)).ToList();
                    break;
                case "Modelo":
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal.Where(c => c.Modelo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Usuario":
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal.Where(c => c.Usuario.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Ativo":
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal.Where(c => c.Ativo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Departamento":
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal.Where(c => c.Departamento.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;

                default:
                    _dispositivosAlugado = _dispositivivosAlugadoOriginal;
                    break;
                    // this.dgvComputadores.DataSource = _computadores;
            }
            this.AtualizaDataGridView();
        }

        private void dgvComputadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // carregando os controles do dispositivo
                this.txtId.Text = _dispositivosAlugado[e.RowIndex].Id.ToString();
                this.cboTipoDispositivo.SelectedValue = _dispositivosAlugado[e.RowIndex].TipoDispositivoId;
                this.txtModelo.Text = _dispositivosAlugado[e.RowIndex].Modelo;
                this.txtAtivo.Text = _dispositivosAlugado[e.RowIndex].Ativo;
                this.txtValor.Text = _dispositivosAlugado[e.RowIndex].Valor.ToString();
                this.chkAvulso.Checked = _dispositivosAlugado[e.RowIndex].Avulso;
                this.txtDepartamento.Text = _dispositivosAlugado[e.RowIndex].Departamento;

                // carregado o usuário
                this.txtUsuarioIdReadOnly.Text = _dispositivosAlugado[e.RowIndex].UsuarioId.ToString();
                this.txtNomeReadOnly.Text = _dispositivosAlugado[e.RowIndex].Usuario.Nome;
                this.txtCpfReadOnly.Text = _dispositivosAlugado[e.RowIndex].Usuario.Cpf;
                this.txtChapaReadOnly.Text = _dispositivosAlugado[e.RowIndex].Usuario.Chapa;


                //carregando os controles do OCS
                if (_dispositivosAlugado[e.RowIndex].ComputadoresOCS == null)
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
                    this.txtOCSId.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.Id == null ? "" : _dispositivosAlugado[e.RowIndex].ComputadoresOCS.Id.ToString();
                    this.txtOCSName.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.Name.ToString();
                    this.txtOCSIpAddr.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.IpAddr.ToString();
                    this.txtOCSUserId.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.UserId == null ? "" : _dispositivosAlugado[e.RowIndex].ComputadoresOCS.UserId.ToString();
                    this.txtOCSWorkGroup.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.WorkGroup.ToString();
                    this.txtOCSOsName.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.OsName.ToString();
                    this.txtOCSWinProdId.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.WinProdId.ToString();
                    this.txtOCSWinProdKey.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.WinProdKey.ToString();
                    this.txtOCSProcessorT.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.ProcessorT.ToString();
                    this.txtOCSMemory.Text = _dispositivosAlugado[e.RowIndex].ComputadoresOCS.Memory.ToString();

                }

                // carregando os dicos
                this.dgvDiscos.DataSource = _dispositivosAlugado[e.RowIndex].Discos;
                this.dgvDiscos.Columns["Id"].Visible = false;
                this.dgvDiscos.Columns["HardwareId"].Visible = false;
                this.dgvDiscos.Columns["Letter"].HeaderText = "Letra da Unidade";
                this.dgvDiscos.Columns["Type"].HeaderText = "Tipo";
                this.dgvDiscos.Columns["FileSystem"].HeaderText = "Sistema de Arquivos";
                this.dgvDiscos.Columns["Volumn"].HeaderText = "Volume";
                this.dgvDiscos.Columns["Total"].HeaderText = "Espaço Total (MB)";
                this.dgvDiscos.Columns["Free"].HeaderText = "Espaço Livre (MB)";

                //Carregando as licenças
                LicencaRepository l = new LicencaRepository();
                List<LicencasResponse> licencas = l.GetLicencasDispositivoAlugadoResponses(int.Parse(this.txtId.Text));

                this.dgvLicencas.DataSource = licencas;
                this.dgvLicencas.Columns["NotaFiscalId"].Visible = false;
                this.dgvLicencas.Columns["SoftwareId"].Visible = false;
                this.dgvLicencas.Columns["Software"].Visible = false;
                this.dgvLicencas.Columns["NotaFiscal"].Visible = false;
                this.dgvLicencas.Columns["SoftwareEChave"].Visible = false;
                this.dgvLicencas.Columns["Quantidade"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NomeTipoDispositivo":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.NomeTipoDispositivo).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.NomeTipoDispositivo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NomeUsuario":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.NomeUsuario).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.NomeUsuario).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Ativo":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Ativo).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Ativo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Modelo":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Modelo).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Modelo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Valor":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Valor).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Valor).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Avulso":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Avulso).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Avulso).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Departamento":
                    if (colunaSelecionada != _colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _dispositivosAlugado = _dispositivosAlugado.OrderBy(x => x.Departamento).ToList();
                    }
                    else
                    {
                        _dispositivosAlugado = _dispositivosAlugado.OrderByDescending(x => x.Departamento).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;

                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            DispositivoAlugado dispositivo;
            DispositivoAlugadoRepository c = new DispositivoAlugadoRepository();

            if (this.txtId.Text != "")
            {
                dispositivo = _dispositivosAlugado.Find(co => co.Id == int.Parse(this.txtId.Text));

                if (dispositivo.TemLigacaoComOCS == "Não")
                {
                    if (MessageBox.Show("Este procedimento irá varrer a lista de computadores do OCS e verificar se o número do ativo novo existe no OCS. Se encontrar irá fazer a associação automaticamente. \n Você tem certeza que deseja efetuar a associação?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var computadoresOCS = c.FindComputadoresOCS(this.txtAtivo.Text);
                        if (computadoresOCS.Count == 0)
                        {
                            MessageBox.Show("Não foi encontrato computador no OCS com o código de ativo " + dispositivo.Ativo + ". Favor escanear o OCS e tentar fazer a associação novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (computadoresOCS.Count == 1)
                        {
                            {
                                dispositivo.OCSId = (int)computadoresOCS.FirstOrDefault().Id;
                                c.AssociarOCS(dispositivo.Id, dispositivo.OCSId);
                                this.CarregarDataGridView();
                                MessageBox.Show("Associação efetuada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                            MessageBox.Show("Existem dois ou mais computadores no OCS com o ativo " + computadoresOCS.FirstOrDefault().Name + ". Favor verificar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Este computador já está associado. Não é possível fazer a associação novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Favor selecionar um registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
