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
    public partial class FrmLinha : Form
    {
        private List<Linha> _linhas;
        private List<Linha> _linhasOriginal;
        private string _colunaSelecionada;

        public FrmLinha()
        {
            _linhas = new List<Linha>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvLinhas.DataSource = null;
            this.dgvLinhas.DataSource = _linhas;

            // Ocultando colunas desnecessárias
            this.dgvLinhas.Columns["CascadeMode"].Visible = false;
        }

        private void FrmLinha_Load(object sender, EventArgs e)
        {
            LinhaRepository linhas = new LinhaRepository();

            _linhas = linhas.Get();
            _linhasOriginal = _linhas;
            this.dgvLinhas.DataSource = _linhas;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                LinhaRepository linhaRepository = new LinhaRepository();
                Linha linha;

                if (this.txtId.Text == "")
                    linha = new Linha();
                else
                    linha = _linhas.Find(n => n.Id == int.Parse(this.txtId.Text));

                linha.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                linha.Numero = this.txtNumero.Text;
                linha.Chip = this.txtChip.Text;
                linha.Pin = this.txtPin.Text;
                linha.Puk = this.txtPuk.Text;

                if (linha.EhValido())
                {
                    if (linha.Id == 0)
                    {
                        string retorno = linhaRepository.Add(linha);
                        this.txtId.Text = retorno.ToString();
                        linha.Id = int.Parse(retorno);
                        _linhas.Add(linha);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        linhaRepository.Update(linha);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = linha.GetErros().Split(';');
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
                    LinhaRepository linhaRepository = new LinhaRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    linhaRepository.Delete(id);

                    _linhas.Remove(_linhas.Find(c => c.Id == id));
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
            this.txtNumero.Clear();
            this.txtChip.Clear();
            this.txtPin.Clear();
            this.txtPuk.Clear();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvLinhas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _linhas[e.RowIndex].Id.ToString();
                this.txtNumero.Text = _linhas[e.RowIndex].Numero.ToString();
                this.txtChip.Text = _linhas[e.RowIndex].Chip == null ? "" : _linhas[e.RowIndex].Chip.ToString();
                this.txtPin.Text = _linhas[e.RowIndex].Pin == null ? "" : _linhas[e.RowIndex].Pin.ToString();
                this.txtPuk.Text = _linhas[e.RowIndex].Puk == null ? "" : _linhas[e.RowIndex].Puk.ToString();
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
                case "Numero":
                    _linhas = _linhasOriginal.Where(c => c.Numero.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Chip":
                    _linhas = _linhasOriginal.Where(c => c.Chip.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _linhas = _linhasOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero.Text != "")
                this.Pesquisar("Numero", this.txtNumero.Text);
            else if (this.txtChip.Text != "")
                this.Pesquisar("Chip", this.txtChip.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvLinhas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvLinhas.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _linhas = _linhas.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _linhas = _linhas.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Numero":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _linhas = _linhas.OrderBy(x => x.Numero).ToList();
                    }
                    else
                    {
                        _linhas = _linhas.OrderByDescending(x => x.Numero).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Chip":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _linhas = _linhas.OrderBy(x => x.Chip).ToList();
                    }
                    else
                    {
                        _linhas = _linhas.OrderByDescending(x => x.Chip).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Pin":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _linhas = _linhas.OrderBy(x => x.Pin).ToList();
                    }
                    else
                    {
                        _linhas = _linhas.OrderByDescending(x => x.Pin).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Puk":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _linhas = _linhas.OrderBy(x => x.Puk).ToList();
                    }
                    else
                    {
                        _linhas = _linhas.OrderByDescending(x => x.Puk).ToList();
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
