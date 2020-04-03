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
    public partial class FrmUsuarios : Form
    {
        private List<Usuario> _usuarios;
        private List<Usuario> _usuariosOriginal;
        private string _colunaSelecionada;

        public FrmUsuarios()
        {
            _usuarios = new List<Usuario>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvUsuarios.DataSource = null;
            this.dgvUsuarios.DataSource = _usuarios;

            // Ocultando colunas desnecessárias
            this.dgvUsuarios.Columns["CascadeMode"].Visible = false;
            this.dgvUsuarios.Columns["Terceiro"].Visible = false;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            UsuarioRepository usuarios = new UsuarioRepository();

            _usuarios = usuarios.Sincronizar();
            _usuariosOriginal = _usuarios;
            this.dgvUsuarios.DataSource = _usuarios;
            this.AtualizaDataGridView();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioRepository usuarios = new UsuarioRepository();

                _usuarios = usuarios.Sincronizar();
                _usuariosOriginal = _usuarios;
                this.dgvUsuarios.DataSource = _usuarios;
                this.AtualizaDataGridView();

                MessageBox.Show("Sincronização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvUsuarios.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _usuarios = _usuarios.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _usuarios = _usuarios.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Chapa":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _usuarios = _usuarios.OrderBy(x => x.Chapa).ToList();
                    }
                    else
                    {
                        _usuarios = _usuarios.OrderByDescending(x => x.Chapa).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Nome":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _usuarios = _usuarios.OrderBy(x => x.Nome).ToList();
                    }
                    else
                    {
                        _usuarios = _usuarios.OrderByDescending(x => x.Nome).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Cpf":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _usuarios = _usuarios.OrderBy(x => x.Cpf).ToList();
                    }
                    else
                    {
                        _usuarios = _usuarios.OrderByDescending(x => x.Cpf).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Chapa":
                    _usuarios = _usuariosOriginal.Where(c => c.Chapa.Contains(texto.ToUpper())).ToList();
                    break;
                case "Nome":
                    _usuarios = _usuariosOriginal.Where(c => c.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Cpf":
                    _usuarios = _usuariosOriginal.Where(c => c.Cpf.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _usuarios = _usuariosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtChapa.Text != "")
                this.Pesquisar("Chapa", this.txtChapa.Text);
            else if (this.txtNome.Text != "")
                this.Pesquisar("Nome", this.txtNome.Text);
            else if (this.txtCpf.Text != "")
                this.Pesquisar("Cpf", this.txtCpf.Text);
            else
                this.Pesquisar("", "");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.txtChapa.Clear();
            this.txtNome.Clear();
            this.txtCpf.Clear();
            this.txtId.Clear();
            this.chkTerceiro.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                Usuario usuario;

                if (this.txtId.Text == "")
                    usuario = new Usuario();
                else
                    usuario = _usuarios.Find(n => n.Id == int.Parse(this.txtId.Text));

                usuario.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                usuario.Chapa = this.txtChapa.Text;
                usuario.Nome = this.txtNome.Text;
                usuario.Cpf = this.txtCpf.Text;
                usuario.Terceiro = this.chkTerceiro.Checked ? 0 : 1;

                if (usuario.EhValido())
                {
                    if (usuario.Id == 0)
                    {
                        string retorno = usuarioRepository.Add(usuario);
                        this.txtId.Text = retorno.ToString();
                        usuario.Id = int.Parse(retorno);
                        _usuarios.Add(usuario);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        usuarioRepository.Update(usuario);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = usuario.GetErros().Split(';');
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

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _usuarios[e.RowIndex].Id.ToString();
                this.txtChapa.Text = _usuarios[e.RowIndex].Chapa.ToString();
                this.txtNome.Text = _usuarios[e.RowIndex].Nome.ToString();
                this.txtCpf.Text = _usuarios[e.RowIndex].Cpf.ToString();
                this.chkTerceiro.Checked = _usuarios[e.RowIndex].Terceiro == 1 ? false : true;

                if(_usuarios[e.RowIndex].Terceiro == 1)
                {
                    this.txtId.ReadOnly = true;
                    this.txtChapa.ReadOnly = true;
                    this.txtNome.ReadOnly = true;
                    this.txtCpf.ReadOnly = true;
                    this.chkTerceiro.Enabled = false;
                }
                else
                {
                    this.txtId.ReadOnly = false;
                    this.txtChapa.ReadOnly = false;
                    this.txtNome.ReadOnly = false;
                    this.txtCpf.ReadOnly = false;
                    this.chkTerceiro.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
