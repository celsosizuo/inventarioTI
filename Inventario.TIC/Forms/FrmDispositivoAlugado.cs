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

        public FrmDispositivoAlugado()
        {
            InitializeComponent();
            _dispositivosAlugado = new List<DispositivoAlugado>();
            _usuarios = new List<Usuario>();
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
            this.dgvComputadores.Columns["CascadeMode"].Visible = false;
        }

        private void CarregarDataGridView()
        {
            // Carregando a lista de computadores
            DispositivoAlugadoRepository c = new DispositivoAlugadoRepository();
            _dispositivosAlugado = null;
            _dispositivosAlugado = c.Get();
            this.dgvComputadores.DataSource = _dispositivosAlugado;
            this.AtualizaDataGridView();
        }

        private void CarregaTipoDispositivo()
        {
            TipoDispositivoRepository t = new TipoDispositivoRepository();
            List<TipoDispositivo> tipoDispositivo = t.Get();

            tipoDispositivo.Insert(0, new TipoDispositivo());

            tipoDispositivo = tipoDispositivo.OrderBy(x => x.Tipo).ToList();

            this.cboTipoDispositivo.DataSource = tipoDispositivo;
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

                if (dispositivo.EhValido())
                {
                    if(dispositivo.Id == 0)
                    {
                        string retorno = dispositivoRepository.Add(dispositivo);
                        this.txtId.Text = retorno.ToString();
                        dispositivo.Id = int.Parse(retorno);
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
                throw new Exception(ex.Message);
            }
        }


    }
}
