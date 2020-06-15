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
    public partial class FrmTermoComputador : Form
    {
        private TermoComputadorRepository _termoRepository;
        private List<Usuario> _usuarios;
        private List<Gestor> _gestores;
        private List<TermoComputadorResponse> _termoComputadorResponse;
        private List<TermoComputador> _termoComputador;
        private List<Carregador> _carregadores;
        private Usuario _usuarioSelecionado;
        private Carregador _carregadorSelecionado;
        private Computadores _computadorSelecionado;
        private DispositivoAlugado _dispositivoAlugadoSelecionado;




        public FrmTermoComputador()
        {
            _termoRepository = new TermoComputadorRepository();
            _usuarios = new List<Usuario>();
            _gestores = new List<Gestor>();
            _termoComputadorResponse = new List<TermoComputadorResponse>();
            _termoComputador = new List<TermoComputador>();
            _carregadores = new List<Carregador>();
            _usuarioSelecionado = new Usuario();
            _carregadorSelecionado = new Carregador();
            _computadorSelecionado = new Computadores();
            _dispositivoAlugadoSelecionado = new DispositivoAlugado();

            InitializeComponent();
        }

        public void CarregaDataGridView()
        {
            _termoComputador = _termoRepository.Get();
            _termoComputadorResponse = _termoComputador.Select(x => (TermoComputadorResponse)x).ToList();

            this.dgvTermoComputador.DataSource = _termoComputadorResponse;

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
    }
}
