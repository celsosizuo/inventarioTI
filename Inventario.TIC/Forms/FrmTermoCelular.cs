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

        public FrmTermoCelular()
        {
            _linhas = new List<Linha>();
            _usuarios = new List<Usuario>();
            _aparelhos = new List<Aparelho>();
            _termoCelulares = new List<TermoCelular>();
            _carregadores = new List<Carregador>();
            _termoCelularesOriginal = new List<TermoCelular>();
            _gestores = new List<Gestor>();
            _usuariosAdicionados = new List<Usuario>();
            _termoCelularesResponse = new List<TermoCelularResponse>();
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
        }

        private void AtualizarDataGridViewUsuariosAdicionados()
        {
            this.dgvUsuariosAdicionados.DataSource = null;
            this.dgvUsuariosAdicionados.DataSource = _usuariosAdicionados;
            this.dgvUsuariosAdicionados.Columns["CascadeMode"].Visible = false;
        }

        private void CarregarDataGridView()
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

            //CelularRepository celulares = new CelularRepository();

            //_celulares = celulares.Get();
            //_celularesOriginal = _celulares;
            //this.dgvCelulares.DataSource = _celulares;
            //this.AtualizaDataGridView();


        }

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
                    this.txtLinha.Focus();
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

                    this.btnSalvar.Focus();
                }
            }
        }

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
                celular.DataDevolucao = null;

                if(_usuariosAdicionados.Count > 0)
                    celular.Usuario = _usuariosAdicionados[0];
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
                    //else
                    //{
                    //    celularRepository.Update(celular);
                    //    MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //}
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

        private void txtCarregador_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Pressionou a tecla enter
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.dgvCarregadores.Visible = true;

                List<Carregador> c = new List<Carregador>();
                CarregadorRepository carregadorRepository = new CarregadorRepository();

                c = carregadorRepository.Get().Where(m => m.NumSerie.Contains(this.txtNumSerieReadOnly.Text)).ToList();
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
                        // this.txtImei1.Focus();
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

    }
}
