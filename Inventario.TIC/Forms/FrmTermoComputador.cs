using Inventario.TIC.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC.Forms
{
    public partial class FrmTermoComputador : Form
    {
        private TermoComputadorRepository _termoRepository;
        private TermoComputadorAcessorioRepository _acessorioRepository;
        private List<Usuario> _usuarios;
        private List<Gestor> _gestores;
        private List<TermoComputadorResponse> _termoComputadorResponse;
        private List<TermoComputador> _termoComputadores;
        private List<Carregador> _carregadores;
        private List<Computadores> _computadores;
        private List<DispositivoAlugado> _dispositivoAlugado;
        private List<TermoComputador> _termoComputadorOriginal;
        private List<TermoComputadorAcessorio> _acessorios;
        
        private Usuario _usuarioSelecionado;
        private Carregador _carregadorSelecionado;
        private Computadores _computadorSelecionado;
        private DispositivoAlugado _dispositivoAlugadoSelecionado;
        private Gestor _gestorSelecionado;
        private TermoComputador _termoComputador;



        public FrmTermoComputador()
        {
            _termoRepository = new TermoComputadorRepository();
            _acessorioRepository = new TermoComputadorAcessorioRepository();
            _usuarios = new List<Usuario>();
            _gestores = new List<Gestor>();
            _termoComputadorResponse = new List<TermoComputadorResponse>();
            _termoComputadores = new List<TermoComputador>();
            _carregadores = new List<Carregador>();
            _usuarioSelecionado = new Usuario();
            _carregadorSelecionado = new Carregador();
            _computadorSelecionado = new Computadores();
            _dispositivoAlugadoSelecionado = new DispositivoAlugado();
            _computadores = new List<Computadores>();
            _dispositivoAlugado = new List<DispositivoAlugado>();
            _gestorSelecionado = new Gestor();
            _termoComputadorOriginal = new List<TermoComputador>();
            _termoComputador = new TermoComputador();
            _acessorios = new List<TermoComputadorAcessorio>();

            InitializeComponent();
        }

        public void CarregaDataGridView()
        {
            _termoComputadores = _termoRepository.Get();
            _termoComputadorResponse = _termoComputadores.Select(x => (TermoComputadorResponse)x).ToList();
            _termoComputadorOriginal = _termoComputadores;

            this.dgvTermoComputador.DataSource = _termoComputadorResponse;
            this.AtualizaDataGridView();

        }

        public void AtualizaDataGridView()
        {
            this.dgvTermoComputador.DataSource = null;
            this.dgvTermoComputador.DataSource = _termoComputadorResponse;

            // Ocultando colunas desnecessárias
            //this.dgvTermoComputador.Columns["LinhaId"].Visible = false;
            //this.dgvTermoComputador.Columns["AparelhoId"].Visible = false;
            //this.dgvTermoComputador.Columns["CarregadorId"].Visible = false;
            //this.dgvTermoComputador.Columns["GestorId"].Visible = false;
            //this.dgvTermoComputador.Columns["FoneOuvido"].Visible = false;
            //this.dgvTermoComputador.Columns["LinkEntrega"].Visible = false;
            //this.dgvTermoComputador.Columns["LinkDevolucao"].Visible = false;
            //this.dgvTermoComputador.Columns["Usuario"].Visible = false;
        }




        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FrmTermoComputador_Load(object sender, EventArgs e)
        {
            GestorRepository gestor = new GestorRepository();

            _gestores = gestor.Get();

            Gestor gest = new Gestor()
            {
                Id = 0,
                Nome = "",
                Status = 0,
                StatusDescricao = ""
            };
            _gestores.Insert(0, gest);

            this.cboGestores.DataSource = _gestores;
            this.cboGestores.ValueMember = "Id";
            this.cboGestores.DisplayMember = "Nome";

            this.CarregaDataGridView();
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

                // this.txtImei1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
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

                    _usuarioSelecionado = _usuarios[RowIndex];

                    // this.btnAddUsuario.Focus();
                    this.dgvUsuarios.Visible = false;
                }
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
            _usuarioSelecionado = null;

        }

        private void btnNovaPesquisaCarregador_Click(object sender, EventArgs e)
        {
            this.txtCarregadorIdReadOnly.Clear();
            this.txtCarregadorMarcaReadOnly.Clear();
            this.txtNumSerieReadOnly.Clear();
            this.txtCarregador.Clear();
            this.txtCarregador.Enabled = true;
            this.dgvCarregadores.Visible = false;
            this.dgvCarregadores.DataSource = null;
            _carregadorSelecionado = null;
        }

        private void txtCarregador_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Pressionou a tecla enter
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.dgvCarregadores.Visible = true;

                List<Carregador> c = new List<Carregador>();
                CarregadorRepository carregadorRepository = new CarregadorRepository();

                c = carregadorRepository.Get().Where(m => m.NumSerie.Contains(this.txtCarregador.Text)).ToList();
                _carregadores = c;

                this.dgvCarregadores.DataSource = c;
                this.dgvCarregadores.Visible = true;
                this.dgvCarregadores.Focus();
                
            }
        }

        private void dgvCarregadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtCarregadorIdReadOnly.Text = _carregadores[e.RowIndex].Id.ToString();
                this.txtCarregadorMarcaReadOnly.Text = _carregadores[e.RowIndex].Marca.ToString();
                this.txtNumSerieReadOnly.Text = _carregadores[e.RowIndex].NumSerie.ToString();
                this.txtCarregador.Enabled = false;

                this.dgvCarregadores.Visible = false;
                _carregadorSelecionado = _carregadores[e.RowIndex];
                // this.txtImei1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCarregadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
        }

        private void dgvCarregadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.dgvCarregadores.Rows.Count > 0)
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    try
                    {
                        int RowIndex = this.dgvCarregadores.CurrentRow.Index;

                        this.txtCarregadorIdReadOnly.Text = _carregadores[RowIndex].Id.ToString();
                        this.txtCarregadorMarcaReadOnly.Text = _carregadores[RowIndex].Marca.ToString();
                        this.txtNumSerieReadOnly.Text = _carregadores[RowIndex].NumSerie.ToString();
                        this.txtCarregador.Enabled = false;
                        this.txtCarregador.Text = _carregadores[RowIndex].NumSerie.ToString();

                        this.dgvCarregadores.Visible = false;
                        _carregadorSelecionado = _carregadores[RowIndex];
                        this.txtUsuario.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtAtivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    this.dgvComputadores.Visible = true;

                    if (this.rdoProprio.Checked)
                    {

                        List<Computadores> c = new List<Computadores>();
                        ComputadoresRepository computadoresRepository = new ComputadoresRepository();

                        c = computadoresRepository.Get().Where(u => u.AtivoNovo.ToUpper().Contains(this.txtAtivo.Text.ToUpper())).ToList();
                        _computadores = c;

                        this.dgvComputadores.DataSource = c;
                        this.dgvComputadores.Focus();
                        this.dgvComputadores.Columns["Status"].Visible = false;
                        this.dgvComputadores.Columns["Status1"].Visible = false;
                        this.dgvComputadores.Columns["OCSId"].Visible = false;
                        this.dgvComputadores.Columns["TemLigacaoComOCS"].Visible = false;
                        this.dgvComputadores.Columns["ComputadoresOCS"].Visible = false;
                        this.dgvComputadores.Columns["Observacoes"].Visible = false;
                        this.dgvComputadores.Columns["LinhaSelecionada"].Visible = false;
                        this.dgvComputadores.Columns["CascadeMode"].Visible = false;

                    }
                    else if (this.rdoAlugado.Checked)
                    {
                        List<DispositivoAlugado> c = new List<DispositivoAlugado>();
                        DispositivoAlugadoRepository dispositivoAlugadoRepository = new DispositivoAlugadoRepository();

                        c = dispositivoAlugadoRepository.Get().Where(u => u.Ativo.ToUpper().Contains(this.txtAtivo.Text.ToUpper())).ToList();
                        _dispositivoAlugado = c;

                        this.dgvComputadores.DataSource = c;
                        this.dgvComputadores.Focus();
                        this.dgvComputadores.Columns["TipoDispositivo"].Visible = false;
                        this.dgvComputadores.Columns["TipoDispositivoId"].Visible = false;
                        this.dgvComputadores.Columns["Usuario"].Visible = false;
                        this.dgvComputadores.Columns["UsuarioId"].Visible = false;
                        this.dgvComputadores.Columns["Valor"].Visible = false;
                        this.dgvComputadores.Columns["Avulso"].Visible = false;
                        this.dgvComputadores.Columns["OCSId"].Visible = false;
                        this.dgvComputadores.Columns["TemLigacaoComOCS"].Visible = false;
                        this.dgvComputadores.Columns["ComputadoresOCS"].Visible = false;
                        this.dgvComputadores.Columns["CascadeMode"].Visible = false;
                    }
                    else
                    {
                        throw new Exception("Favor selecionar um registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComputadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
        }

        private void dgvComputadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.rdoAlugado.Checked)
                {
                    this.txtIdReadOnly.Text = _dispositivoAlugado[e.RowIndex].Id.ToString();
                    this.txtAtivoReadOnly.Text = _dispositivoAlugado[e.RowIndex].Ativo.ToString();
                    this.txtDepartamentoReadOnly.Text = _dispositivoAlugado[e.RowIndex].Departamento;
                    this.txtAtivo.Enabled = false;

                    this.dgvComputadores.Visible = false;

                    _dispositivoAlugadoSelecionado = _dispositivoAlugado[e.RowIndex];

                    // this.txtImei1.Focus();

                }
                else if (this.rdoProprio.Checked)
                {
                    this.txtIdReadOnly.Text = _computadores[e.RowIndex].Id.ToString();
                    this.txtAtivoReadOnly.Text = _computadores[e.RowIndex].AtivoNovo.ToString();
                    this.txtDepartamentoReadOnly.Text = _computadores[e.RowIndex].Departamento;
                    this.txtAtivo.Enabled = false;

                    this.dgvComputadores.Visible = false;

                    _computadorSelecionado = _computadores[e.RowIndex];
                }
                else
                {
                    throw new Exception("Favor selecionar um registro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComputadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.dgvComputadores.Rows.Count > 0)
                {
                    if ((Keys)e.KeyChar == Keys.Enter)
                    {
                        int rowIndex = this.dgvComputadores.CurrentRow.Index;
                        
                        if (this.rdoAlugado.Checked)
                        {
                            this.txtIdReadOnly.Text = _dispositivoAlugado[rowIndex].Id.ToString();
                            this.txtAtivoReadOnly.Text = _dispositivoAlugado[rowIndex].Ativo.ToString();
                            this.txtDepartamentoReadOnly.Text = _dispositivoAlugado[rowIndex].Departamento;
                            this.txtAtivo.Enabled = false;

                            this.dgvComputadores.Visible = false;
                            
                            _dispositivoAlugadoSelecionado = _dispositivoAlugado[rowIndex];
                            

                        }
                        else if (this.rdoProprio.Checked)
                        {
                            this.txtIdReadOnly.Text = _computadores[rowIndex].Id.ToString();
                            this.txtAtivoReadOnly.Text = _computadores[rowIndex].AtivoNovo.ToString();
                            this.txtDepartamentoReadOnly.Text = _computadores[rowIndex].Departamento;
                            this.txtAtivo.Enabled = false;

                            this.dgvComputadores.Visible = false;
                            _computadorSelecionado = _computadores[rowIndex];
                        }
                        else
                        {
                            throw new Exception("Favor selecionar um registro.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovaPesquisaComputador_Click(object sender, EventArgs e)
        {
            this.txtIdReadOnly.Clear();
            this.txtUsuarioIdReadOnly.Clear();
            this.txtAtivo.Clear();
            this.txtAtivoReadOnly.Clear();
            this.txtDepartamentoReadOnly.Clear();
            this.txtAtivo.Enabled = true;
            this.dgvComputadores.Visible = false;
            this.dgvComputadores.DataSource = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TermoComputador termo;

                if (this.txtId.Text == "")
                    termo = new TermoComputador();
                else
                    termo = _termoComputadores.Find(t => t.Id == int.Parse(this.txtId.Text));

                termo.Id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                termo.Usuario = _usuarioSelecionado;
                termo.Computador = _computadorSelecionado;
                termo.DispositivoAlugado = _dispositivoAlugadoSelecionado;
                termo.Carregador = _carregadorSelecionado;
                termo.Gestor = _gestorSelecionado;
                termo.DataEntrega = DateTime.Parse(this.txtDataEntrega.Text);
                termo.ValorDispositivo = decimal.Parse(this.txtValorDispositivo.Text);
                termo.DataDevolucao = null;
                termo.Motivo = null;
                termo.LinkEntrega = null;
                termo.LinkDevolucao = null;

                if (termo.EhValido())
                {
                    if(termo.Id == 0)
                    {
                        string retorno = _termoRepository.Add(termo);
                        this.txtId.Text = retorno;
                        termo.Id = int.Parse(retorno);
                        _termoComputadores.Add(termo);

                        _acessorios.ForEach(a =>
                        {
                            a.TermoComputadorId = int.Parse(retorno);
                            _acessorioRepository.Add(a);
                        });
                        
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        _termoRepository.Update(termo);

                        _acessorios.ForEach(a =>
                        {
                            if(a.Id == 0)
                            {
                                a.TermoComputadorId = termo.Id;
                                _acessorioRepository.Add(a);
                            }
                            else
                            {
                                _acessorioRepository.Update(a);
                            }
                        });


                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.CarregaDataGridView();
                }
                else
                {
                    string[] msgs = termo.GetErros().Split(';');
                    string msg = "";
                    msgs.ToList().ForEach(m => msg += m + "\n");

                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboGestores.SelectedIndex > -1)
            {
                _gestorSelecionado = (Gestor)this.cboGestores.Items[this.cboGestores.SelectedIndex];
            }

        }

        private void dgvTermoComputador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.LimparCampos();
            int id = _termoComputadorResponse[e.RowIndex].Id;
            _termoComputador = _termoComputadorOriginal.Find(t => t.Id == id);

            // Dados gerais
            this.txtId.Text = _termoComputador.Id.ToString();
            this.txtDataEntrega.Text = _termoComputador.DataEntrega.ToString();
            this.cboGestores.SelectedValue = _termoComputador.Gestor.Id;
            this.txtValorDispositivo.Text = _termoComputador.ValorDispositivo.ToString("N2");
            this.txtLinkTermoEntrega.Text = _termoComputador.LinkEntrega;
            this.txtLinkTermoDevolucao.Text = _termoComputador.LinkDevolucao;

            // Usuário
            this.txtUsuario.Enabled = false;
            this.txtUsuarioIdReadOnly.Text = _termoComputador.Usuario.Id.ToString();
            this.txtNomeReadOnly.Text = _termoComputador.Usuario.Nome;
            this.txtCpfReadOnly.Text = _termoComputador.Usuario.Cpf;
            this.txtChapaReadOnly.Text = _termoComputador.Usuario.Chapa;
            this.txtUsuario.Text = _termoComputador.Usuario.Nome;
            _usuarioSelecionado = _termoComputador.Usuario;

            // Carregador
            this.txtCarregador.Enabled = false;
            this.txtCarregador.Text = _termoComputador.Carregador.NumSerie.ToString();
            this.txtCarregadorIdReadOnly.Text = _termoComputador.Carregador.Id.ToString();
            this.txtCarregadorMarcaReadOnly.Text = _termoComputador.Carregador.Marca.ToString();
            this.txtNumSerieReadOnly.Text = _termoComputador.Carregador.NumSerie.ToString();
            _carregadorSelecionado = _termoComputador.Carregador;

            // Computador
            this.txtAtivo.Enabled = false;
            this.txtIdReadOnly.Text = _termoComputador.Computador == null ? _termoComputador.DispositivoAlugado.Id.ToString() : _termoComputador.Computador.Id.ToString();
            this.txtAtivo.Text = _termoComputador.Computador == null ? _termoComputador.DispositivoAlugado.Ativo : _termoComputador.Computador.AtivoNovo.ToString();
            this.txtAtivoReadOnly.Text = _termoComputador.Computador == null ? _termoComputador.DispositivoAlugado.Ativo : _termoComputador.Computador.AtivoNovo.ToString();
            this.txtDepartamentoReadOnly.Text = _termoComputador.Computador == null ? _termoComputador.DispositivoAlugado.Departamento : _termoComputador.Computador.Departamento.ToString();

            _computadorSelecionado = _termoComputador.Computador;
            _dispositivoAlugadoSelecionado = _termoComputador.DispositivoAlugado;
            

            // Acessorios
            _acessorios = _termoComputador.TermoComputadorAcessorio;
            this.AtualizarDataGridViewAcessorios();


            if (_termoComputador.Computador == null)
                this.rdoAlugado.Checked = true;
            else if (_termoComputador.DispositivoAlugado == null)
                this.rdoProprio.Checked = true;
        }

        private void LimparCampos()
        {
            // Dados Gerais
            this.txtId.Clear();
            this.txtDataEntrega.Clear();
            this.cboGestores.SelectedValue = 0;
            this.txtValorDispositivo.Clear();
            this.txtLinkTermoEntrega.Clear();
            this.txtLinkTermoDevolucao.Clear();

            // Usuario
            this.txtUsuario.Clear();
            this.txtUsuario.Enabled = true;
            this.txtUsuarioIdReadOnly.Clear();
            this.txtNomeReadOnly.Clear();
            this.txtCpfReadOnly.Clear();
            this.txtChapaReadOnly.Clear();

            // Carregador
            this.txtCarregador.Clear();
            this.txtCarregador.Enabled = true;
            this.txtCarregadorIdReadOnly.Clear();
            this.txtCarregadorMarcaReadOnly.Clear();
            this.txtNumSerieReadOnly.Clear();

            // Computadores
            this.txtAtivo.Clear();
            this.txtAtivo.Enabled = true;
            this.txtIdReadOnly.Clear();
            this.txtAtivoReadOnly.Clear();
            this.txtDepartamentoReadOnly.Clear();
            this.rdoAlugado.Checked = false;
            this.rdoProprio.Checked = false;

            // Acessórios
            this.txtNomeAcessorio.Clear();
            this.txtValorAcessorio.Clear();
            this.dgvAcessorios.DataSource = null;

            _acessorios = new List<TermoComputadorAcessorio>();
            _computadorSelecionado = new Computadores();
            _carregadorSelecionado = new Carregador();
            _dispositivoAlugadoSelecionado = new DispositivoAlugado();
            _usuarioSelecionado = new Usuario();
            _gestorSelecionado = new Gestor();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void txtValorDispositivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtValorDispositivo_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtValorDispositivo.Text == "" ? 0 : decimal.Parse(this.txtValorDispositivo.Text);
            this.txtValorDispositivo.Text = valor.ToString("N2");
        }

        private void txtValorMaleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void lnkAddTermo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.opdTermoEntrega.DefaultExt = "*.pdf";
            this.opdTermoEntrega.InitialDirectory = @"\\fs\ADM\Tics\Infraestrutura\Controles\2020\Telefonia\Movel\Termos";
            this.opdTermoEntrega.ShowDialog();
        }

        private void opdTermoEntrega_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtLinkTermoEntrega.Text = this.opdTermoEntrega.FileName.ToString();
                _termoComputador.LinkEntrega = this.txtLinkTermoEntrega.Text;
                _termoRepository.UpdateLinkTermoEntrega(_termoComputador);

                MessageBox.Show("Inclusão do link do termo efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.CarregaDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkTermoDevolucao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.opdTermoDevolucao.DefaultExt = "*.pdf";
            this.opdTermoDevolucao.InitialDirectory = @"\\fs\ADM\Tics\Infraestrutura\Controles\2020\Telefonia\Movel\Termos";
            this.opdTermoDevolucao.ShowDialog();
        }

        private void opdTermoDevolucao_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtLinkTermoDevolucao.Text = this.opdTermoDevolucao.FileName.ToString();
                _termoComputador.LinkDevolucao = this.txtLinkTermoDevolucao.Text;
                _termoRepository.UpdateLinkTermoDevolucao(_termoComputador);

                MessageBox.Show("Inclusão do link do termo efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.CarregaDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDataGridViewAcessorios()
        {
            this.dgvAcessorios.DataSource = null;
            this.dgvAcessorios.DataSource = _acessorios;
            this.dgvAcessorios.Columns["CascadeMode"].Visible = false;
            this.dgvAcessorios.Columns["TermoComputadorId"].Visible = false;
            this.dgvAcessorios.Columns["Id"].Visible = false;
        }

        private void btnAddAcessorio_Click(object sender, EventArgs e)
        {
            TermoComputadorAcessorio acessorio = new TermoComputadorAcessorio()
            {
                TermoComputadorId = 0,
                NomeAcessorio = this.txtNomeAcessorio.Text,
                Valor = decimal.Parse(this.txtValorAcessorio.Text)
            };

            this.txtNomeAcessorio.Clear();
            this.txtValorAcessorio.Clear();

            _acessorios.Add(acessorio);
            this.AtualizarDataGridViewAcessorios();
        }

        private void btnDelAcessorio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAcessorios.Rows.Count > 0)
                {
                    int RowIndex = this.dgvAcessorios.CurrentRow == null ? -1 : this.dgvAcessorios.CurrentRow.Index;
                    if (RowIndex < 0)
                    {
                        MessageBox.Show("Favor selecionar um acessório na lista", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if(MessageBox.Show("Você tem certeza que deseja excluir o registro " + _acessorios[RowIndex].NomeAcessorio + "?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question ) == DialogResult.Yes)
                        {
                            int id = _acessorios[RowIndex].Id;

                            _acessorios.RemoveAt(RowIndex);

                            _acessorioRepository.Delete(id);

                            this.AtualizarDataGridViewAcessorios();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorAcessorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void txtValorAcessorio_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtValorAcessorio.Text == "" ? 0 : decimal.Parse(this.txtValorAcessorio.Text);
            this.txtValorAcessorio.Text = valor.ToString("N2");
        }

        private void lnkAbrirTermoEntrega_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.txtLinkTermoEntrega.Text != "")
            {
                string link = this.txtLinkTermoEntrega.Text;

                FrmVisualizadorAdobe frmVisualizadorAdobe = new FrmVisualizadorAdobe(link);
                // frmVisualizadorAdobe.MdiParent = MdiParent;
                frmVisualizadorAdobe.Show();
            }
        }

        private void lnkAbrirTermoDevolucao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.txtLinkTermoDevolucao.Text != "")
            {
                string link = this.txtLinkTermoDevolucao.Text;

                FrmVisualizadorAdobe frmVisualizadorAdobe = new FrmVisualizadorAdobe(link);
                // frmVisualizadorAdobe.MdiParent = MdiParent;
                frmVisualizadorAdobe.Show();
            }
        }

        private void lnkRemoverTermoEntrega_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o link do termo de entrega?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.txtLinkTermoEntrega.Text = "";
                    TermoCelularRepository termoRepository = new TermoCelularRepository();

                    _termoComputador.LinkEntrega = this.txtLinkTermoEntrega.Text;

                    _termoRepository.UpdateLinkTermoEntrega(_termoComputador);

                    MessageBox.Show("Exclusão do link do termo de entrega efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.CarregaDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRemoverTermoDevolucao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o link do termo de devolução?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.txtLinkTermoDevolucao.Text = "";
                    TermoCelularRepository termoRepository = new TermoCelularRepository();

                    _termoComputador.LinkDevolucao = this.txtLinkTermoDevolucao.Text;

                    _termoRepository.UpdateLinkTermoDevolucao(_termoComputador);

                    MessageBox.Show("Exclusão do link do termo de devolução efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.CarregaDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Usuario":
                    _termoComputadores = _termoComputadorOriginal.Where(c => c.Usuario.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Computador":
                    _termoComputadores = _termoComputadorOriginal.Where(c => c.Computador != null && c.Computador.AtivoNovo.Contains(texto)).ToList();
                    break;
                case "Alugado":
                    _termoComputadores = _termoComputadorOriginal.Where(c => c.DispositivoAlugado != null && c.DispositivoAlugado.Ativo.Contains(texto)).ToList();
                    break;
                default:
                    _termoComputadores = _termoComputadorOriginal;
                    break;
            }
            _termoComputadorResponse = _termoComputadores.Select(t => (TermoComputadorResponse)t).ToList();
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNomeReadOnly.Text != "")
                this.Pesquisar("Usuario", this.txtNomeReadOnly.Text);
            else if (this.txtAtivoReadOnly.Text != "" && this.rdoProprio.Checked)
                this.Pesquisar("Computador", this.txtAtivoReadOnly.Text);
            else if (this.txtAtivoReadOnly.Text != "" && this.rdoAlugado.Checked)
                this.Pesquisar("Alugado", this.txtAtivoReadOnly.Text);
            else
                this.Pesquisar("", "");

        }
    }
}
