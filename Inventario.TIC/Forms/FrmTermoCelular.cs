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
    public partial class FrmTermoCelular : Form
    {
        private List<Linha> _linhas;
        private List<Usuario> _usuarios;
        private List<Aparelho> _aparelhos;
        private List<Carregador> _carregadores;
        private List<TermoCelular> _termoCelulares;
        private List<TermoCelular> _termoCelularesOriginal;
        private List<Gestor> _gestores;
        private List<Usuario> _usuariosAdicionados;
        private List<TermoCelularResponse> _termoCelularesResponse;
        private TermoCelular _termoCelular;

        public FrmTermoCelular()
        {
            _linhas = new List<Linha>();
            _usuarios = new List<Usuario>();
            _aparelhos = new List<Aparelho>();
            _carregadores = new List<Carregador>();
            _termoCelulares = new List<TermoCelular>();
            _termoCelularesOriginal = new List<TermoCelular>();
            _gestores = new List<Gestor>();
            _usuariosAdicionados = new List<Usuario>();
            _termoCelularesResponse = new List<TermoCelularResponse>();
            _termoCelular = new TermoCelular();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvTermoCelulares.DataSource = null;
            this.dgvTermoCelulares.DataSource = _termoCelularesResponse;

            // Ocultando colunas desnecessárias
            this.dgvTermoCelulares.Columns["LinhaId"].Visible = false;
            this.dgvTermoCelulares.Columns["AparelhoId"].Visible = false;
            this.dgvTermoCelulares.Columns["CarregadorId"].Visible = false;
            this.dgvTermoCelulares.Columns["GestorId"].Visible = false;
            this.dgvTermoCelulares.Columns["FoneOuvido"].Visible = false;
            this.dgvTermoCelulares.Columns["LinkEntrega"].Visible = false;
            this.dgvTermoCelulares.Columns["LinkDevolucao"].Visible = false;
        }

        private void AtualizarDataGridViewUsuariosAdicionados()
        {
            this.dgvUsuariosAdicionados.DataSource = null;
            this.dgvUsuariosAdicionados.DataSource = _usuariosAdicionados;
            this.dgvUsuariosAdicionados.Columns["CascadeMode"].Visible = false;
        }

        public void CarregarDataGridView()
        {
            // Carregando a lista de computadores
            TermoCelularRepository c = new TermoCelularRepository();
            _termoCelulares = c.Get();

            _termoCelularesResponse = _termoCelulares.Select(x => (TermoCelularResponse)x).ToList();
            _termoCelularesOriginal = _termoCelulares;

            this.dgvTermoCelulares.DataSource = _termoCelularesResponse;
            this.AtualizaDataGridView();
        }

        private void FrmCelulares_Load(object sender, EventArgs e)
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

            this.CarregarDataGridView();

            // this.toolTip1.SetToolTip(txtLinha, "Selecione a linha");


            //CelularRepository celulares = new CelularRepository();

            //_celulares = celulares.Get();
            //_celularesOriginal = _celulares;
            //this.dgvCelulares.DataSource = _celulares;
            //this.AtualizaDataGridView();


        }

        #region Pesquisa Controles

        private void btnNovaPesquisaLinha_Click(object sender, EventArgs e)
        {
            this.txtLinha.Clear();
            this.txtLinhaIdReadOnly.Clear();
            this.txtNumeroReadOnly.Clear();
            this.txtChipReadOnly.Clear();
            this.txtLinha.Enabled = true;
            this.dgvLinhas.Visible = false;
            this.dgvLinhas.DataSource = null;
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

        private void btnNovaPesquisaAparelho_Click(object sender, EventArgs e)
        {
            this.dgvAparelhos.Visible = false;
            this.txtAparelhoIdReadOnly.Clear();
            this.txtImei1.Clear();
            this.txtMarcaReadOnly.Clear();
            this.txtModeloReadOnly.Clear();
            this.txtImei1ReadOnly.Clear();
            this.txtImei1.Enabled = true;
            this.dgvAparelhos.DataSource = null;
            this.dgvAparelhos.Visible = false;
        }

        private void txtImei1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Pressionou a tecla enter
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.dgvAparelhos.Visible = true;

                List<Aparelho> c = new List<Aparelho>();
                AparelhoRepository AparelhoRepository = new AparelhoRepository();

                c = AparelhoRepository.Get().Where(m => m.Imei1.Contains(this.txtImei1.Text)).ToList();
                _aparelhos = c;

                this.dgvAparelhos.DataSource = c;
                this.dgvAparelhos.Visible = true;
                this.dgvAparelhos.Focus();
            }
        }

        private void dgvAparelhos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtAparelhoIdReadOnly.Text = _aparelhos[e.RowIndex].Id.ToString();
                this.txtMarcaReadOnly.Text = _aparelhos[e.RowIndex].Marca.ToString();
                this.txtModeloReadOnly.Text = _aparelhos[e.RowIndex].Modelo == null ? "" : _aparelhos[e.RowIndex].Modelo.ToString();
                this.txtImei1ReadOnly.Text = _aparelhos[e.RowIndex].Imei1 == null ? "" : _aparelhos[e.RowIndex].Imei1.ToString();
                this.txtImei1.Text = _aparelhos[e.RowIndex].Imei1 == null ? "" : _aparelhos[e.RowIndex].Imei1.ToString();
                this.txtImei1.Enabled = false;

                this.dgvAparelhos.Visible = false;

                this.txtLinha.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAparelhos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.dgvAparelhos.Rows.Count > 0)
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    int RowIndex = this.dgvAparelhos.CurrentRow.Index;

                    //int RowIndex = this.dgvAparelhos.SelectedRows.

                    this.txtAparelhoIdReadOnly.Text = _aparelhos[RowIndex].Id.ToString();
                    this.txtMarcaReadOnly.Text = _aparelhos[RowIndex].Marca.ToString();
                    this.txtModeloReadOnly.Text = _aparelhos[RowIndex].Modelo == null ? "" : _aparelhos[RowIndex].Modelo.ToString();
                    this.txtImei1ReadOnly.Text = _aparelhos[RowIndex].Imei1 == null ? "" : _aparelhos[RowIndex].Imei1.ToString();
                    this.txtImei1.Text = _aparelhos[RowIndex].Imei1 == null ? "" : _aparelhos[RowIndex].Imei1.ToString();
                    this.txtImei1.Enabled = false;

                    this.dgvAparelhos.Visible = false;
                    this.txtDataEntrega.Focus();
                }
            }
        }

        private void dgvAparelhos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
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

                    this.btnAddUsuario.Focus();
                    this.dgvUsuarios.Visible = false;
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
                this.txtImei1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLinha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.dgvLinhas.Visible = true;

                List<Linha> c = new List<Linha>();
                LinhaRepository LinhaRepository = new LinhaRepository();

                c = LinhaRepository.Get().Where(u => u.Numero.ToUpper().Contains(this.txtLinha.Text.ToUpper())).ToList();
                _linhas = c;

                this.dgvLinhas.DataSource = c;
                this.dgvLinhas.Focus();
            }
        }

        private void dgvLinhas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtLinhaIdReadOnly.Text = _linhas[e.RowIndex].Id.ToString();
                this.txtNumeroReadOnly.Text = _linhas[e.RowIndex].Numero.ToString();
                this.txtChipReadOnly.Text = _linhas[e.RowIndex].Chip == null ? "" : _linhas[e.RowIndex].Chip.ToString();
                this.txtLinha.Text = _linhas[e.RowIndex].Numero.ToString();
                this.txtLinha.Enabled = false;

                this.dgvLinhas.Visible = false;
                this.txtImei1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLinhas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                e.Handled = true;
        }

        private void dgvLinhas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {

                if (this.dgvLinhas.Rows.Count > 0)
                {
                    int RowIndex = this.dgvLinhas.CurrentRow.Index;

                    //int RowIndex = this.dgvLinhas.SelectedRows.

                    this.txtLinhaIdReadOnly.Text = _linhas[RowIndex].Id.ToString();
                    this.txtNumeroReadOnly.Text = _linhas[RowIndex].Numero.ToString();
                    this.txtChipReadOnly.Text = _linhas[RowIndex].Chip == null ? "" : _linhas[RowIndex].Chip.ToString();
                    this.txtLinha.Text = _linhas[RowIndex].Numero.ToString();
                    this.txtLinha.Enabled = false;

                    this.dgvLinhas.Visible = false;

                    this.txtCarregador.Focus();
                }
            }
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
                        this.txtImei1.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
        }

        private void btnAddUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUsuarioIdReadOnly.Text != "")
                {
                    Usuario usuario = new Usuario()
                    {
                        Id = int.Parse(this.txtUsuarioIdReadOnly.Text),
                        Chapa = this.txtChapaReadOnly.Text,
                        Nome = this.txtNomeReadOnly.Text,
                        Cpf = this.txtCpfReadOnly.Text
                    };

                    _usuariosAdicionados.Add(usuario);
                    this.AtualizarDataGridViewUsuariosAdicionados();

                    this.txtUsuario.Clear();
                    this.txtUsuarioIdReadOnly.Clear();
                    this.txtUsuario.Enabled = true;
                    this.txtChapaReadOnly.Clear();
                    this.txtCpfReadOnly.Clear();
                    this.txtNomeReadOnly.Clear();
                    this.dgvUsuarios.Visible = false;
                    this.dgvUsuarios.DataSource = null;

                    this.txtUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Favor selecionar um usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuariosAdicionados.Rows.Count > 0)
            {
                int RowIndex = this.dgvUsuariosAdicionados.CurrentRow.Index;
                if (RowIndex < 0)
                {
                    MessageBox.Show("Favor selecionar um usuário na lista", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _usuariosAdicionados.RemoveAt(RowIndex);
                    AtualizarDataGridViewUsuariosAdicionados();
                }
            }
        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TermoCelularRepository celularRepository = new TermoCelularRepository();
                TermoCelular celular;

                if (this.txtId.Text == "")
                    celular = new TermoCelular();
                else
                    celular = _termoCelulares.Find(n => n.Id == int.Parse(this.txtId.Text));

                celular.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                celular.LinhaId = int.Parse(this.txtLinhaIdReadOnly.Text);
                celular.AparelhoId = int.Parse(this.txtAparelhoIdReadOnly.Text);
                celular.CarregadorId = int.Parse(this.txtCarregadorIdReadOnly.Text);
                celular.GestorId = int.Parse(this.cboGestores.SelectedValue.ToString());
                celular.FoneOuvido = int.Parse(this.chkFoneOuvido.Checked == true ? "0" : "1");
                celular.DataEntrega = DateTime.Parse(this.txtDataEntrega.Text);

                //if (this.txtDataDevolucao.Text == "  /  /")
                //    celular.DataDevolucao = null;
                //else
                //    celular.DataDevolucao = DateTime.Parse(this.txtDataDevolucao.Text);

                if(_usuariosAdicionados.Count > 0)
                    celular.Usuario = _usuariosAdicionados;
                else
                {
                    MessageBox.Show("Usuário não informado. Favor adicionar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (celular.EhValido())
                {
                    if (celular.Id == 0)
                    {
                        string retorno = celularRepository.Add(celular);
                        this.txtId.Text = retorno.ToString();
                        celular.Id = int.Parse(retorno);
                        _termoCelulares.Add(celular);

                        _usuariosAdicionados.ForEach(x =>
                        {
                            TermoCelularUsuarios termoUsuario = new TermoCelularUsuarios()
                            {
                                TermoCelularId = int.Parse(retorno),
                                UsuarioId = x.Id,
                            };
                            TermoCelularUsuarioRepository termoCelularUsuarioRepository = new TermoCelularUsuarioRepository();
                            termoCelularUsuarioRepository.Add(termoUsuario);
                        });

                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        celularRepository.Update(celular);

                        TermoCelularUsuarioRepository termoCelularUsuarioRepository = new TermoCelularUsuarioRepository();
                        termoCelularUsuarioRepository.Delete(celular.Id);

                        _usuariosAdicionados.ForEach(x =>
                        {
                            TermoCelularUsuarios termoUsuario = new TermoCelularUsuarios()
                            {
                                TermoCelularId = celular.Id,
                                UsuarioId = x.Id,
                            };

                            termoCelularUsuarioRepository.Add(termoUsuario);
                        });

                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.CarregarDataGridView();
                }
                else
                {
                    string[] msgs = celular.GetErros().Split(';');
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

        private void dgvTermoCelulares_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _termoCelular = _termoCelularesOriginal[e.RowIndex];

            // Dados Gerais
            this.txtId.Text = _termoCelularesOriginal[e.RowIndex].Id.ToString();
            this.txtDataEntrega.Text = _termoCelularesOriginal[e.RowIndex].DataEntrega.ToString();
            // this.txtDataDevolucao.Text = _termoCelularesOriginal[e.RowIndex].DataDevolucao == null ? "" : _termoCelularesOriginal[e.RowIndex].DataDevolucao.ToString();
            this.cboGestores.SelectedValue = _termoCelularesOriginal[e.RowIndex].Gestor.Id;
            this.chkFoneOuvido.Checked = _termoCelularesOriginal[e.RowIndex].FoneOuvido == 0 ? true : false;
            this.txtLinkTermoEntrega.Text = _termoCelularesOriginal[e.RowIndex].LinkEntrega == null ? "" : _termoCelularesOriginal[e.RowIndex].LinkEntrega.ToString();
            this.txtLinkTermoDevolucao.Text = _termoCelularesOriginal[e.RowIndex].LinkDevolucao == null ? "" : _termoCelularesOriginal[e.RowIndex].LinkDevolucao.ToString();

            // Linha
            this.txtLinha.Enabled = false;
            this.txtLinha.Text = _termoCelularesOriginal[e.RowIndex].Linha.Numero.ToString();
            this.txtNumeroReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Linha.Numero.ToString();
            this.txtLinhaIdReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Linha.Id.ToString();
            this.txtChipReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Linha.Chip == null ? "" : _termoCelularesOriginal[e.RowIndex].Linha.Chip.ToString();

            // Carregador
            this.txtCarregador.Enabled = false;
            this.txtCarregador.Text = _termoCelularesOriginal[e.RowIndex].Carregador.NumSerie.ToString();
            this.txtCarregadorIdReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Carregador.Id.ToString();
            this.txtCarregadorMarcaReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Carregador.Marca.ToString();
            this.txtNumSerieReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Carregador.NumSerie.ToString();

            // Aparelho
            this.txtImei1.Enabled = false;
            this.txtImei1.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Imei1.ToString();
            this.txtAparelhoIdReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Id.ToString();
            this.txtImei1ReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Id.ToString();
            this.txtMarcaReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Marca.ToString();
            this.txtModeloReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Modelo.ToString();
            this.txtImei1ReadOnly.Text = _termoCelularesOriginal[e.RowIndex].Aparelho.Imei1.ToString();

            // Usuários
            _usuariosAdicionados = _termoCelularesOriginal[e.RowIndex].Usuario;
            this.dgvUsuariosAdicionados.DataSource = _termoCelularesOriginal[e.RowIndex].Usuario;
            this.dgvUsuariosAdicionados.Columns["CascadeMode"].Visible = false;
        }

        private void lnkAddTermo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.opdTermoEntrega.ShowDialog();

        }

        private void opdTermoEntrega_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtLinkTermoEntrega.Text = this.opdTermoEntrega.FileName.ToString();
                TermoCelularRepository termoRepository = new TermoCelularRepository();

                _termoCelular.LinkEntrega = this.txtLinkTermoEntrega.Text;

                termoRepository.UpdateLinkTermoEntrega(_termoCelular);

                MessageBox.Show("Inclusão do link do termo efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.CarregarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkAbrirTermoEntrega_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this.txtLinkTermoEntrega.Text != "")
            {
                string link = this.txtLinkTermoEntrega.Text;

                FrmVisualizadorAdobe frmVisualizadorAdobe = new FrmVisualizadorAdobe(link);
                // frmVisualizadorAdobe.MdiParent = MdiParent;
                frmVisualizadorAdobe.Show();
            }
        }

        private void lnkTermoDevolucao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.opdTermoDevolucao.ShowDialog();
        }

        private void opdTermoDevolucao_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtLinkTermoDevolucao.Text = this.opdTermoDevolucao.FileName.ToString();
                TermoCelularRepository termoRepository = new TermoCelularRepository();

                _termoCelular.LinkDevolucao = this.txtLinkTermoDevolucao.Text;

                termoRepository.UpdateLinkTermoDevolucao(_termoCelular);

                MessageBox.Show("Inclusão do link do termo de devolução efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.CarregarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(MessageBox.Show("Você tem certeza que deseja excluir o link do termo de entrega?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.txtLinkTermoEntrega.Text = "";
                    TermoCelularRepository termoRepository = new TermoCelularRepository();

                    _termoCelular.LinkEntrega = this.txtLinkTermoEntrega.Text;

                    termoRepository.UpdateLinkTermoEntrega(_termoCelular);

                    MessageBox.Show("Exclusão do link do termo de entrega efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.CarregarDataGridView();
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

                    _termoCelular.LinkDevolucao = this.txtLinkTermoDevolucao.Text;

                    termoRepository.UpdateLinkTermoDevolucao(_termoCelular);

                    MessageBox.Show("Exclusão do link do termo de devolução efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.CarregarDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            // Dados Gerais
            this.txtId.Clear();
            this.txtDataEntrega.Clear();
            // this.txtDataDevolucao.Clear();
            this.cboGestores.SelectedValue = 0;
            this.chkFoneOuvido.Checked = false;
            this.txtLinkTermoEntrega.Clear();
            this.txtLinkTermoDevolucao.Clear();

            // Linha
            this.txtLinha.Clear();
            this.txtLinha.Enabled = true;
            this.txtNumeroReadOnly.Clear();
            this.txtLinhaIdReadOnly.Clear();
            this.txtChipReadOnly.Clear();

            // Carregador
            this.txtCarregador.Clear();
            this.txtCarregador.Enabled = true;
            this.txtCarregadorIdReadOnly.Clear();
            this.txtCarregadorMarcaReadOnly.Clear();
            this.txtNumSerieReadOnly.Clear();

            // Aparelho
            this.txtImei1.Clear();
            this.txtImei1.Enabled = true;
            this.txtAparelhoIdReadOnly.Clear();
            this.txtImei1ReadOnly.Clear();
            this.txtMarcaReadOnly.Clear();
            this.txtModeloReadOnly.Clear();
            this.txtImei1ReadOnly.Clear();

            // Usuários
            this.txtUsuario.Clear();
            this.txtUsuario.Enabled = true;
            this.txtUsuarioIdReadOnly.Clear();
            this.txtNomeReadOnly.Clear();
            this.txtCpfReadOnly.Clear();
            this.txtChapaReadOnly.Clear();
            _usuariosAdicionados = new List<Usuario>();
            this.dgvUsuariosAdicionados.DataSource = null;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Linha":
                    _termoCelulares = _termoCelularesOriginal.Where(c => c.Linha.Numero.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Carregador":
                    _termoCelulares = _termoCelularesOriginal.Where(c => c.Carregador.NumSerie.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Usuario":
                    _termoCelulares = _termoCelularesOriginal.Where(t => t.Usuario.Any(u => u.Nome.Contains(texto))).ToList();
                    break;
                //case "NomeTecnico":
                //    _termoCelulares = _termoCelularesOriginal.Where(c => c.NomeTecnico.ToUpper().Contains(texto.ToUpper())).ToList();
                //    break;
                default:                    _termoCelulares = _termoCelularesOriginal;
                    break;
            }
            _termoCelularesResponse = _termoCelulares.Select(t => (TermoCelularResponse)t).ToList();
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtLinha.Text != "")
                this.Pesquisar("Linha", this.txtLinha.Text);
            else if (this.txtCarregador.Text != "")
                this.Pesquisar("Carregador", this.txtCarregador.Text);
            else if (this.txtNomeReadOnly.Text != "")
                this.Pesquisar("Usuario", this.txtNomeReadOnly.Text);
            else
                this.Pesquisar("", "");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            parametros.Add(new ParametrosRelatorio
            {
                Parametro = "LINHANUMERO",
                Valor = this.txtNumeroReadOnly.Text,
            });
            
            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Termo.Entrega.Celular", parametros);
            newMDIChild.Show();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            FrmDevolucaoTermoCelular newMDIChild = new FrmDevolucaoTermoCelular(_termoCelular, this);
            newMDIChild.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            parametros.Add(new ParametrosRelatorio
            {
                Parametro = "LINHANUMERO",
                Valor = this.txtNumeroReadOnly.Text,
            });

            parametros.Add(new ParametrosRelatorio
            {
                Parametro = "USUARIOID",
                Valor = _termoCelular.Usuario[0].Id.ToString(),
            });

            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Termo.Devolucao.Celular", parametros);
            newMDIChild.Show();
        }
    }
}
