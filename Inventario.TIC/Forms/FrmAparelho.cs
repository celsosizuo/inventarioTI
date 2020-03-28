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
    public partial class FrmAparelho : Form
    {
        private List<Aparelho> _aparelhos;
        private List<Aparelho> _aparelhosOriginal;
        private string _colunaSelecionada;

        public FrmAparelho()
        {
            _aparelhos = new List<Aparelho>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvAparelhos.DataSource = null;
            this.dgvAparelhos.DataSource = _aparelhos;

            // Ocultando colunas desnecessárias
            this.dgvAparelhos.Columns["CascadeMode"].Visible = false;
        }

        private void FrmAparelho_Load(object sender, EventArgs e)
        {
            AparelhoRepository aparelhos = new AparelhoRepository();

            _aparelhos = aparelhos.Get();
            _aparelhosOriginal = _aparelhos;
            this.dgvAparelhos.DataSource = _aparelhos;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                AparelhoRepository aparelhoRepository = new AparelhoRepository();
                Aparelho aparelho;

                if (this.txtId.Text == "")
                    aparelho = new Aparelho();
                else
                    aparelho = _aparelhos.Find(n => n.Id == int.Parse(this.txtId.Text));

                aparelho.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                aparelho.Marca = this.txtMarca.Text;
                aparelho.Modelo = this.txtModelo.Text;
                aparelho.Imei1 = this.txtImei1.Text;
                aparelho.Imei2 = this.txtImei2.Text;
                aparelho.Valor = decimal.Parse(this.txtValor.Text);

                if (aparelho.EhValido())
                {
                    if (aparelho.Id == 0)
                    {
                        string retorno = aparelhoRepository.Add(aparelho);
                        this.txtId.Text = retorno.ToString();
                        aparelho.Id = int.Parse(retorno);
                        _aparelhos.Add(aparelho);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        aparelhoRepository.Update(aparelho);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = aparelho.GetErros().Split(';');
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
                    AparelhoRepository aparelhoRepository = new AparelhoRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    aparelhoRepository.Delete(id);

                    _aparelhos.Remove(_aparelhos.Find(c => c.Id == id));
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
            this.txtMarca.Clear();
            this.txtModelo.Clear();
            this.txtImei1.Clear();
            this.txtImei2.Clear();
            this.txtValor.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvAparelhos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _aparelhos[e.RowIndex].Id.ToString();
                this.txtMarca.Text = _aparelhos[e.RowIndex].Marca == null ? "" : _aparelhos[e.RowIndex].Marca.ToString();
                this.txtModelo.Text = _aparelhos[e.RowIndex].Modelo == null ? "" : _aparelhos[e.RowIndex].Modelo.ToString();
                this.txtImei1.Text = _aparelhos[e.RowIndex].Imei1 == null ? "" : _aparelhos[e.RowIndex].Imei1.ToString();
                this.txtImei2.Text = _aparelhos[e.RowIndex].Imei2 == null ? "" : _aparelhos[e.RowIndex].Imei2.ToString();
                this.txtValor.Text = _aparelhos[e.RowIndex].Valor.ToString();
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
                case "Marca":
                    _aparelhos = _aparelhosOriginal.Where(c => c.Marca.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Modelo":
                    _aparelhos = _aparelhosOriginal.Where(c => c.Modelo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Imei1":
                    _aparelhos = _aparelhosOriginal.Where(c => c.Imei1.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Imei2":
                    _aparelhos = _aparelhosOriginal.Where(c => c.Imei2.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _aparelhos = _aparelhosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtMarca.Text != "")
                this.Pesquisar("Marca", this.txtMarca.Text);
            else if (this.txtModelo.Text != "")
                this.Pesquisar("Modelo", this.txtModelo.Text);
            else if (this.txtImei1.Text != "")
                this.Pesquisar("Imei1", this.txtImei1.Text);
            else if (this.txtImei2.Text != "")
                this.Pesquisar("Imei2", this.txtImei2.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvAparelhos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvAparelhos.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Marca":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Marca).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Marca).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Modelo":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Modelo).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Modelo).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Imei1":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Imei1).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Imei1).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Imei2":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Imei2).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Imei2).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Valor":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _aparelhos = _aparelhos.OrderBy(x => x.Valor).ToList();
                    }
                    else
                    {
                        _aparelhos = _aparelhos.OrderByDescending(x => x.Valor).ToList();
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
