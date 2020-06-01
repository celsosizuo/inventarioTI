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
    public partial class FrmProdutos : Form
    {
        private List<Produto> _produtos;
        private List<Produto> _produtosOriginal;
        private string _colunaSelecionada;

        public FrmProdutos()
        {
            _produtos = new List<Produto>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvProdutos.DataSource = null;
            this.dgvProdutos.DataSource = _produtos;

            // Ocultando colunas desnecessárias
            this.dgvProdutos.Columns["CascadeMode"].Visible = false;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            ProdutoRepository produto = new ProdutoRepository();

            _produtos = produto.Get();
            _produtosOriginal = _produtos;
            this.dgvProdutos.DataSource = _produtos;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoRepository produtoRepository = new ProdutoRepository();
                Produto produto;

                if (this.txtId.Text == "")
                    produto = new Produto();
                else
                    produto = _produtos.Find(n => n.Id == int.Parse(this.txtId.Text));

                produto.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                produto.Nome = this.txtNome.Text;

                if (produto.EhValido())
                {
                    if (produto.Id == 0)
                    {
                        string retorno = produtoRepository.Add(produto);
                        this.txtId.Text = retorno.ToString();
                        produto.Id = int.Parse(retorno);
                        _produtos.Add(produto);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        produtoRepository.Update(produto);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = produto.GetErros().Split(';');
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
            this.txtNome.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProdutoRepository produtoRepository = new ProdutoRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    produtoRepository.Delete(id);

                    _produtos.Remove(_produtos.Find(c => c.Id == id));
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
                this.txtId.Text = _produtos[e.RowIndex].Id.ToString();
                this.txtNome.Text = _produtos[e.RowIndex].Nome.ToString();
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
                case "Nome":
                    _produtos = _produtosOriginal.Where(c => c.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _produtos = _produtosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text != "")
                this.Pesquisar("Nome", this.txtNome.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvProdutos.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _produtos = _produtos.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _produtos = _produtos.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Nome":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _produtos = _produtos.OrderBy(x => x.Nome).ToList();
                    }
                    else
                    {
                        _produtos = _produtos.OrderByDescending(x => x.Nome).ToList();
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
