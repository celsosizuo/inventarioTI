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
    public partial class FrmAccess : Form
    {
        private List<Access> _acessos;
        private List<Access> _acessosOriginal;
        private string _colunaSelecionada;
        private AccessRepository _acessoRepos;

        public FrmAccess()
        {
            _acessoRepos = new AccessRepository();
            _acessos = new List<Access>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvAccess.DataSource = null;
            this.dgvAccess.DataSource = _acessos;

            // Ocultando colunas desnecessárias
            this.dgvAccess.Columns["CascadeMode"].Visible = false;
            this.dgvAccess.Columns["Senha"].Visible = false;
            this.dgvAccess.Columns["Observacao"].Visible = false;
        }

        private void CarregaDataGrid()
        {
            _acessos = _acessoRepos.Get();
            _acessosOriginal = _acessos;
            this.dgvAccess.DataSource = _acessos;
            this.AtualizaDataGridView();

        }

        private void FrmAccess_Load(object sender, EventArgs e)
        {
            this.CarregaDataGrid();
            this.habilitarDesabilitarCampos(false);
        }

        private void habilitarDesabilitarCampos(bool visible)
        {
            this.lblRevelarSenha.Visible = visible;
            this.txtPalavraPasse.Visible = visible;
            this.btnRevelar.Visible = visible;
            this.lblSenhaRevelada.Visible = visible;
            this.txtSenhaRevelada.Visible = visible;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Access acesso;

                if (this.txtId.Text == "")
                    acesso = new Access();
                else
                    acesso = _acessos.Find(n => n.Id == int.Parse(this.txtId.Text));

                acesso.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                acesso.Descricao = this.txtDescricao.Text;
                acesso.EnderecoAcesso = this.txtEnderecoAcesso.Text;
                acesso.Observacao = this.txtObservacao.Text;
                acesso.Usuario = this.txtUsuario.Text;
                acesso.Senha = StringCrypt.Encrypt(this.txtSenha.Text, Properties.Settings.Default.SecretPass);

                if (acesso.EhValido())
                {
                    if (acesso.Id == 0)
                    {
                        string retorno = _acessoRepos.Add(acesso);
                        this.txtId.Text = retorno.ToString();
                        acesso.Id = int.Parse(retorno);
                        _acessos.Add(acesso);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        _acessoRepos.Update(acesso);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = acesso.GetErros().Split(';');
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

        private void limparCampos()
        {
            this.txtId.Clear();
            this.txtDescricao.Clear();
            this.txtEnderecoAcesso.Clear();
            this.txtObservacao.Clear();
            this.txtUsuario.Clear();
            this.txtSenha.Clear();
            this.txtPalavraPasse.Clear();
            this.txtSenhaRevelada.Clear();
            this.habilitarDesabilitarCampos(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    _acessoRepos.Delete(id);

                    _acessos.Remove(_acessos.Find(c => c.Id == id));
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _acessos[e.RowIndex].Id.ToString();
                this.txtDescricao.Text = _acessos[e.RowIndex].Descricao.ToString();
                this.txtEnderecoAcesso.Text = _acessos[e.RowIndex].EnderecoAcesso.ToString();
                this.txtObservacao.Text = _acessos[e.RowIndex].Observacao.ToString();
                this.txtUsuario.Text = _acessos[e.RowIndex].Usuario.ToString();
                this.txtSenha.Text = _acessos[e.RowIndex].Senha.ToString();
                this.txtDescricao.Text = _acessos[e.RowIndex].Descricao.ToString();
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
                case "Descricao":
                    _acessos = _acessosOriginal.Where(c => c.Descricao.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "EnderecoAcesso":
                    _acessos = _acessosOriginal.Where(c => c.EnderecoAcesso.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _acessos = _acessosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtDescricao.Text != "")
                this.Pesquisar("Descricao", this.txtDescricao.Text);
            else if (this.txtEnderecoAcesso.Text != "")
                this.Pesquisar("EnderecoAcesso", this.txtEnderecoAcesso.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvAccess.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _acessos = _acessos.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _acessos = _acessos.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Descricao":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _acessos = _acessos.OrderBy(x => x.Descricao).ToList();
                    }
                    else
                    {
                        _acessos = _acessos.OrderByDescending(x => x.Descricao).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "EnderecoAcesso":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _acessos = _acessos.OrderBy(x => x.EnderecoAcesso).ToList();
                    }
                    else
                    {
                        _acessos = _acessos.OrderByDescending(x => x.EnderecoAcesso).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Usuario":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _acessos = _acessos.OrderBy(x => x.Usuario).ToList();
                    }
                    else
                    {
                        _acessos = _acessos.OrderByDescending(x => x.Usuario).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnAtualizarSaldos_Click(object sender, EventArgs e)
        {
            this.CarregaDataGrid();
        }

        private void lnkRevelarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.lblRevelarSenha.Visible == false)
                this.habilitarDesabilitarCampos(true);
            else
                this.habilitarDesabilitarCampos(false);
        }

        private void btnRevelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtSenhaRevelada.Text = StringCrypt.Decrypt(this.txtSenha.Text, this.txtPalavraPasse.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
