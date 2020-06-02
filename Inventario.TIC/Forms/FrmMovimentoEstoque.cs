using Inventario.TIC.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC.Forms
{
    public partial class FrmMovimentoEstoque : Form
    {
        private List<Movimentos> _movimentos;
        private List<Movimentos> _movimentosOriginal;
        private string _colunaSelecionada;
        private MovimentoRepository _movimentoRepository;
        private Produto _produtoSelecionado;
        private List<Produto> _produtos;

        public FrmMovimentoEstoque()
        {
            _movimentos = new List<Movimentos>();
            _produtoSelecionado = new Produto();
            _movimentoRepository = new MovimentoRepository();
            _produtos = new List<Produto>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            _movimentos = _movimentos.OrderByDescending(m => m.Data).ToList();
            this.dgvMovimentos.DataSource = null;
            this.dgvMovimentos.DataSource = _movimentos;

            // Ocultando colunas desnecessárias
            this.dgvMovimentos.Columns["CascadeMode"].Visible = false;
            this.dgvMovimentos.Columns["Produto"].Visible = false;
            this.dgvMovimentos.Columns["Tipo"].Visible = false;

            this.cboProduto.DataSource = _produtos;
            this.cboProduto.DisplayMember = "nome";
            this.cboProduto.ValueMember = "id";
        }

        private void CarregaComboProduto()
        {
            ProdutoRepository produtoRepository = new ProdutoRepository();

            _produtos = produtoRepository.Get();
            _produtos = _produtos.OrderBy(p => p.Nome).ToList();

            _produtos.Insert(0, new Produto { Id = 0, Nome = "", QtdeEstoque = 0 });

            this.txtData.Value = DateTime.Now;

            this.cboProduto.DataSource = null;
            this.cboProduto.DataSource = _produtos;
            this.cboProduto.DisplayMember = "nome";
            this.cboProduto.ValueMember = "id";
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            _movimentos = _movimentoRepository.Get();
            _movimentosOriginal = _movimentos;
            this.dgvMovimentos.DataSource = _movimentos;
            this.AtualizaDataGridView();
            this.CarregaComboProduto();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Movimentos movimento;

                if (this.txtId.Text == "")
                    movimento = new Movimentos();
                else
                    movimento = _movimentos.Find(n => n.Id == int.Parse(this.txtId.Text));

                movimento.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                movimento.Produto = _produtoSelecionado;
                movimento.NomeProduto = _produtoSelecionado.Nome;
                movimento.Data = DateTime.Parse(this.txtData.Value.ToShortDateString());
                movimento.Solicitante = this.txtSolicitante.Text;
                movimento.Tipo = this.rdoEntrada.Checked ? "E" : "S";
                movimento.Quantidade = decimal.Parse(this.txtQuantidadeEfetivada.Text);

                if (movimento.EhValido())
                {
                    ProdutoRepository produtoRepository = new ProdutoRepository();
                    Produto p = produtoRepository.GetOne(movimento.Produto.Id);

                    decimal quantidade = p.QtdeEstoque + movimento.Quantidade;

                    if (quantidade < 0)
                        throw new Exception("Se esta movimentação for feita, o produto " + movimento.Produto.Nome +
                                            " ficará com saldo negativo de " + quantidade.ToString() +
                                            ". O movimento não será salvo. " + 
                                            "O saldo atual do produto " + movimento.Produto.Nome + " é de " + p.QtdeEstoque.ToString());

                    if (movimento.Id == 0)
                    {
                        string retorno = _movimentoRepository.Add(movimento);
                        this.txtId.Text = retorno.ToString();
                        movimento.Id = int.Parse(retorno);
                        _movimentos.Add(movimento);

                        decimal saldoAtual = decimal.Parse(this.txtSaldoAtual.Text);
                        decimal qtdeBaixada = decimal.Parse(this.txtQuantidadeEfetivada.Text);

                        this.txtSaldoAtual.Text = (saldoAtual + qtdeBaixada).ToString();
                        _produtos.Find(r => r.Id == _produtoSelecionado.Id).QtdeEstoque = (saldoAtual + qtdeBaixada);

                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        _movimentoRepository.Update(movimento);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = movimento.GetErros().Split(';');
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
            this.txtSolicitante.Clear();
            this.txtQuantidade.Clear();
            this.txtQuantidadeEfetivada.Clear();
            this.rdoEntrada.Checked = false;
            this.rdoSaida.Checked = false;
            this.cboProduto.SelectedValue = 0;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    _movimentoRepository.Delete(id);

                    this.CarregaComboProduto();

                    _movimentos.Remove(_movimentos.Find(c => c.Id == id));
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
                this.txtId.Text = _movimentos[e.RowIndex].Id.ToString();
                this.cboProduto.SelectedValue = _movimentos[e.RowIndex].Produto.Id;
                this.txtData.Value = _movimentos[e.RowIndex].Data;
                this.txtSolicitante.Text = _movimentos[e.RowIndex].Solicitante.ToString();
                this.txtQuantidade.Text = _movimentos[e.RowIndex].Quantidade.ToString();
                if (_movimentos[e.RowIndex].Tipo == "E") { this.rdoEntrada.Checked = true; } else { this.rdoSaida.Checked = true; }
                this.txtQuantidadeEfetivada.Text = _movimentos[e.RowIndex].Quantidade.ToString();
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
                case "NomeProduto":
                    _movimentos = _movimentosOriginal.Where(c => c.NomeProduto.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Solicitante":
                    _movimentos = _movimentosOriginal.Where(c => c.Solicitante.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Tipo":
                    _movimentos = _movimentosOriginal.Where(c => c.Tipo.ToUpper().Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _movimentos = _movimentosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if(this.cboProduto.Text != "")
                this.Pesquisar("NomeProduto", this.cboProduto.Text);
            else if (this.txtSolicitante.Text != "")
                this.Pesquisar("Solicitante", this.txtSolicitante.Text);
            else if (this.rdoEntrada.Checked)
                this.Pesquisar("Tipo", "E");
            else if (this.rdoSaida.Checked)
                this.Pesquisar("Tipo", "S");
            else
                this.Pesquisar("", "");
        }

        private void dgvProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvMovimentos.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _movimentos = _movimentos.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _movimentos = _movimentos.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NomeProduto":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _movimentos = _movimentos.OrderBy(x => x.NomeProduto).ToList();
                    }
                    else
                    {
                        _movimentos = _movimentos.OrderByDescending(x => x.NomeProduto).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Data":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _movimentos = _movimentos.OrderBy(x => x.Data).ToList();
                    }
                    else
                    {
                        _movimentos = _movimentos.OrderByDescending(x => x.Data).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Solicitante":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _movimentos = _movimentos.OrderBy(x => x.Solicitante).ToList();
                    }
                    else
                    {
                        _movimentos = _movimentos.OrderByDescending(x => x.Solicitante).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Quantidade":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _movimentos = _movimentos.OrderBy(x => x.Quantidade).ToList();
                    }
                    else
                    {
                        _movimentos = _movimentos.OrderByDescending(x => x.Quantidade).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtQuantidade.Text == "" ? 0 : decimal.Parse(this.txtQuantidade.Text);
            this.txtQuantidade.Text = valor == 0 ? "" : valor.ToString("N2");
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cboProduto.SelectedIndex > -1)
            {
                _produtoSelecionado = (Produto)this.cboProduto.Items[this.cboProduto.SelectedIndex];
                this.txtSaldoAtual.Text = _produtoSelecionado.Id == 0 ? "" : _produtoSelecionado.QtdeEstoque.ToString();
            }
        }

        private void rdoEntrada_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void rdoSaida_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.rdoSaida.Checked)
            //{
            //    if (this.txtQuantidade.Text == "")
            //    {
            //        MessageBox.Show("Favor digitar a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.rdoSaida.Checked = false;
            //        this.txtQuantidade.Focus();
            //    }
            //    else
            //    {
            //        decimal quantidade = rdoSaida.Checked ? decimal.Parse(this.txtQuantidade.Text) * -1 : decimal.Parse(this.txtQuantidadeEfetivada.Text);
            //        this.txtQuantidadeEfetivada.Text = quantidade.ToString();
            //    }
            //}
            //else
            //    this.rdoSaida.Checked = false;
        }

        private void rdoEntrada_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.txtQuantidade.Text == "" && this.rdoEntrada.Checked)
            {
                MessageBox.Show("Favor digitar a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.rdoEntrada.Checked = false;
                this.txtQuantidade.Focus();
                this.txtQuantidadeEfetivada.Clear();
            }
            else
            {
                decimal quantidade = rdoEntrada.Checked ? decimal.Parse(this.txtQuantidade.Text) : decimal.Parse(this.txtQuantidade.Text) * -1;
                this.txtQuantidadeEfetivada.Text = quantidade.ToString();
            }
        }

        private void rdoSaida_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.txtQuantidade.Text == "" && this.rdoSaida.Checked)
            {
                MessageBox.Show("Favor digitar a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.rdoSaida.Checked = false;
                this.txtQuantidade.Focus();
                this.txtQuantidadeEfetivada.Clear();
            }
            else
            {
                decimal quantidade = rdoEntrada.Checked ? decimal.Parse(this.txtQuantidade.Text) : decimal.Parse(this.txtQuantidade.Text) * -1;
                this.txtQuantidadeEfetivada.Text = quantidade.ToString();
            }
        }
    }
}
