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
    public partial class FrmFornecedor : Form
    {
        private List<Fornecedor> _fornecedores;
        private List<Fornecedor> _fornecedoresOriginal;
        private string _colunaSelecionada;

        public FrmFornecedor()
        {
            _fornecedores = new List<Fornecedor>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvFornecedores.DataSource = null;
            this.dgvFornecedores.DataSource = _fornecedores;

            // Ocultando colunas desnecessárias
            this.dgvFornecedores.Columns["CascadeMode"].Visible = false;
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            FornecedorRepository fornecedores = new FornecedorRepository();

            _fornecedores = fornecedores.Get();
            _fornecedoresOriginal = _fornecedores;
            this.dgvFornecedores.DataSource = _fornecedores;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorRepository fornecedorRepository = new FornecedorRepository();
                Fornecedor fornecedor;

                if (this.txtId.Text == "")
                    fornecedor = new Fornecedor();
                else
                    fornecedor = _fornecedores.Find(n => n.Id == int.Parse(this.txtId.Text));

                fornecedor.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                fornecedor.Nome = this.txtNome.Text;
                fornecedor.Cnpj = this.txtCnpj.Text;
                fornecedor.DataIniContrato = DateTime.Parse(this.txtDataIniContrato.Text);
                fornecedor.DataFimContrato = DateTime.Parse(this.txtDataFimContrato.Text);

                if (fornecedor.EhValido())
                {
                    if (fornecedor.Id == 0)
                    {
                        string retorno = fornecedorRepository.Add(fornecedor);
                        this.txtId.Text = retorno.ToString();
                        fornecedor.Id = int.Parse(retorno);
                        _fornecedores.Add(fornecedor);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        fornecedorRepository.Update(fornecedor);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = fornecedor.GetErros().Split(';');
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FornecedorRepository fornecedorRepository = new FornecedorRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    fornecedorRepository.Delete(id);

                    _fornecedores.Remove(_fornecedores.Find(c => c.Id == id));
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

        private void limparCampos()
        {
            this.txtId.Clear();
            this.txtNome.Clear();
            this.txtDataIniContrato.Clear();
            this.txtDataFimContrato.Clear();
            this.txtCnpj.Clear();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvFornecedors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _fornecedores[e.RowIndex].Id.ToString();
                this.txtNome.Text = _fornecedores[e.RowIndex].Nome.ToString();
                this.txtDataIniContrato.Text = _fornecedores[e.RowIndex].DataIniContrato.ToString();
                this.txtDataFimContrato.Text = _fornecedores[e.RowIndex].DataFimContrato.ToString();
                this.txtCnpj.Text = _fornecedores[e.RowIndex].Cnpj.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text != "")
                this.Pesquisar("Nome", this.txtNome.Text);
            else if (this.txtDataIniContrato.Text != "")
                this.Pesquisar("Fabricante", this.txtDataIniContrato.Text);
            else if (this.txtDataFimContrato.Text != "")
                this.Pesquisar("Versao", this.txtDataFimContrato.Text);
            else if (this.txtCnpj.Text != "")
                this.Pesquisar("NomeTecnico", this.txtCnpj.Text);
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Nome":
                    _fornecedores = _fornecedoresOriginal.Where(c => c.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Cnpj":
                    _fornecedores = _fornecedoresOriginal.Where(c => c.Cnpj.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "DataInicioContrato":
                    _fornecedores = _fornecedoresOriginal.Where(c => c.DataIniContrato.Equals(texto.ToUpper())).ToList();
                    break;
                case "DataFimContrato":
                    _fornecedores = _fornecedoresOriginal.Where(c => c.DataFimContrato.Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _fornecedores = _fornecedoresOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvFornecedors_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvFornecedores.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _fornecedores = _fornecedores.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _fornecedores = _fornecedores.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Nome":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _fornecedores = _fornecedores.OrderBy(x => x.Nome).ToList();
                    }
                    else
                    {
                        _fornecedores = _fornecedores.OrderByDescending(x => x.Nome).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "DataInicioContrato":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _fornecedores = _fornecedores.OrderBy(x => x.DataIniContrato).ToList();
                    }
                    else
                    {
                        _fornecedores = _fornecedores.OrderByDescending(x => x.DataIniContrato).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "DataFimContrato":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _fornecedores = _fornecedores.OrderBy(x => x.DataFimContrato).ToList();
                    }
                    else
                    {
                        _fornecedores = _fornecedores.OrderByDescending(x => x.DataFimContrato).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Cnpj":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _fornecedores = _fornecedores.OrderBy(x => x.Cnpj).ToList();
                    }
                    else
                    {
                        _fornecedores = _fornecedores.OrderByDescending(x => x.Cnpj).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }
    }
}
