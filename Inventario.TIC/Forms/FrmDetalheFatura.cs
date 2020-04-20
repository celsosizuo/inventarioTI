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
    public partial class FrmDetalheFatura : Form
    {
        private List<DetalheFaturaTelefoniaMovel> _detalheFatura;
        private List<DetalheFaturaTelefoniaMovel> _detalheFaturaOriginal;
        private string _colunaSelecionada;

        public FrmDetalheFatura()
        {
            _detalheFatura = new List<DetalheFaturaTelefoniaMovel>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvDetalheFatura.DataSource = null;
            this.dgvDetalheFatura.DataSource = _detalheFatura;

            // Ocultando colunas desnecessárias
            this.dgvDetalheFatura.Columns["DescricaoChamada"].Name = "Descricao";
            this.dgvDetalheFatura.Columns["SecaoChamada"].Visible = false;
            this.dgvDetalheFatura.Columns["DataHoraChamada"].Visible = false;
            this.dgvDetalheFatura.Columns["TipoChamada"].Visible = false;
            this.dgvDetalheFatura.Columns["CidadeOrigem"].Visible = false;
            this.dgvDetalheFatura.Columns["UfOrigem"].Visible = false;
            this.dgvDetalheFatura.Columns["CidadeDestino"].Visible = false;
            this.dgvDetalheFatura.Columns["UfDestino"].Visible = false;
            this.dgvDetalheFatura.Columns["NumeroChamado"].Visible = false;
            this.dgvDetalheFatura.Columns["Tarifa"].Visible = false;
            this.dgvDetalheFatura.Columns["Duracao"].Visible = false;
            this.dgvDetalheFatura.Columns["Quantidade"].Visible = false;
            this.dgvDetalheFatura.Columns["Contratados"].Visible = false;
            this.dgvDetalheFatura.Columns["Utilizados"].Visible = false;
            this.dgvDetalheFatura.Columns["Excedentes"].Visible = false;
            this.dgvDetalheFatura.Columns["Unidade"].Visible = false;
            this.dgvDetalheFatura.Columns["CascadeMode"].Visible = false;
        }

        private void FrmDetalheFatura_Load(object sender, EventArgs e)
        {
            DetalheFaturaTelefoniaMovel detalheFatura = new DetalheFaturaTelefoniaMovel();

            List<string> referencia = detalheFatura.GetReferencia();
            referencia.Insert(0, "");

            this.cboReferencia.DataSource = referencia;

            _detalheFatura = detalheFatura.Get();
            _detalheFaturaOriginal = _detalheFatura;
            this.dgvDetalheFatura.DataSource = _detalheFatura;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DetalheFaturaTelefoniaMovel detalheFaturaRepository = new DetalheFaturaTelefoniaMovel();
                DetalheFaturaTelefoniaMovel detalheFatura;

                if (this.txtId.Text == "")
                    detalheFatura = new DetalheFaturaTelefoniaMovel();
                else
                    detalheFatura = _detalheFatura.Find(n => n.Id == int.Parse(this.txtId.Text));

                detalheFatura.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                detalheFatura.LinhaNumero = this.txtLinhaNumero.Text;
                detalheFatura.SecaoChamada = this.txtDescricaoChamada.Text;
                detalheFatura.Referencia = this.cboReferencia.Text;
                detalheFatura.DescricaoChamada = this.txtDescricaoChamada.Text;
                detalheFatura.Unidade = "MANUAL";
                detalheFatura.Valor = Convert.ToDecimal(this.txtValor.Text);

                if (detalheFatura.EhValido())
                {
                    if (detalheFatura.Id == 0)
                    {
                        string retorno = detalheFaturaRepository.Add(detalheFatura);
                        this.txtId.Text = retorno.ToString();
                        detalheFatura.Id = int.Parse(retorno);
                        _detalheFatura.Add(detalheFatura);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        detalheFaturaRepository.Update(detalheFatura);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = detalheFatura.GetErros().Split(';');
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
            this.txtLinhaNumero.Clear();
            this.cboReferencia.SelectedIndex = 0;
            this.txtDescricaoChamada.Clear();
            this.txtValor.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DetalheFaturaTelefoniaMovel detalheFatura = new DetalheFaturaTelefoniaMovel();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    detalheFatura.Delete(id);

                    _detalheFatura.Remove(_detalheFatura.Find(c => c.Id == id));
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

        private void dgvDetalheFatura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _detalheFatura[e.RowIndex].Id.ToString();
                this.txtLinhaNumero.Text = _detalheFatura[e.RowIndex].LinhaNumero.ToString();
                this.cboReferencia.Text = _detalheFatura[e.RowIndex].Referencia.ToString();
                this.txtDescricaoChamada.Text = _detalheFatura[e.RowIndex].DescricaoChamada.ToString();
                this.txtValor.Text = _detalheFatura[e.RowIndex].Valor.ToString();
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
                case "LinhaNumero":
                    _detalheFatura = _detalheFaturaOriginal.Where(c => c.LinhaNumero.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Referencia":
                    _detalheFatura = _detalheFaturaOriginal.Where(c => c.Referencia.Equals(texto.ToUpper())).ToList();
                    break;
                case "DescricaoChamada":
                    _detalheFatura = _detalheFaturaOriginal.Where(c => c.DescricaoChamada.Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _detalheFatura = _detalheFaturaOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtLinhaNumero.Text != "")
                this.Pesquisar("LinhaNumero", this.txtLinhaNumero.Text);
            else if (this.cboReferencia.SelectedText != "")
                this.Pesquisar("Referencia", this.cboReferencia.SelectedText);
            else if (this.txtDescricaoChamada.Text != "")
                this.Pesquisar("DescricaoChamada", this.txtDescricaoChamada.Text);
            this.Pesquisar("", "");
        }

        private void dgvDetalheFatura_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvDetalheFatura.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _detalheFatura = _detalheFatura.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _detalheFatura = _detalheFatura.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "LinhaNumero":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _detalheFatura = _detalheFatura.OrderBy(x => x.LinhaNumero).ToList();
                    }
                    else
                    {
                        _detalheFatura = _detalheFatura.OrderByDescending(x => x.LinhaNumero).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Referencia":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _detalheFatura = _detalheFatura.OrderBy(x => x.Referencia).ToList();
                    }
                    else
                    {
                        _detalheFatura = _detalheFatura.OrderByDescending(x => x.Referencia).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "DescricaoChamada":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _detalheFatura = _detalheFatura.OrderBy(x => x.DescricaoChamada).ToList();
                    }
                    else
                    {
                        _detalheFatura = _detalheFatura.OrderByDescending(x => x.DescricaoChamada).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Valor":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _detalheFatura = _detalheFatura.OrderBy(x => x.Valor).ToList();
                    }
                    else
                    {
                        _detalheFatura = _detalheFatura.OrderByDescending(x => x.Valor).ToList();
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
