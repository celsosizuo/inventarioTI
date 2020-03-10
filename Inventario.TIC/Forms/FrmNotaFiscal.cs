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
    public partial class FrmNotaFiscal : Form
    {
        private List<NotaFiscal> _notasFiscais;
        private List<NotaFiscal> _notasFiscaisOriginal;
        private string _colunaSelecionada;

        public FrmNotaFiscal()
        {
            InitializeComponent();
            _notasFiscais = new List<NotaFiscal>();
        }

        private void AtualizaDataGridView()
        {
            this.dgvNotasFiscais.DataSource = null;
            this.dgvNotasFiscais.DataSource = _notasFiscais;

            // Ocultando colunas desnecessárias
            this.dgvNotasFiscais.Columns["CascadeMode"].Visible = false;
        }

        private void FrmNotaFiscal_Load(object sender, EventArgs e)
        {
            NotaFiscalRepository nf = new NotaFiscalRepository();

            _notasFiscais = nf.Get();
            _notasFiscaisOriginal = _notasFiscais;
            this.dgvNotasFiscais.DataSource = _notasFiscais;
            this.AtualizaDataGridView();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                NotaFiscalRepository nfRepository = new NotaFiscalRepository();
                NotaFiscal nf;

                if (this.txtId.Text == "")
                    nf = new NotaFiscal();
                else
                    nf = _notasFiscais.Find(n => n.Id == int.Parse(this.txtId.Text));

                nf.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                nf.NumNF = this.txtNumNF.Text;
                nf.Fornecedor = this.txtFornecedor.Text;
                nf.Data = DateTime.Parse(this.txtData.Text);
                nf.Empresa = this.cboEmpresa.Text;
                nf.Link = this.txtLink.Text;

                if (nf.EhValido())
                {
                    if(nf.Id == 0)
                    {
                        string retorno = nfRepository.Add(nf);
                        this.txtId.Text = retorno.ToString();
                        nf.Id = int.Parse(retorno);
                        _notasFiscais.Add(nf);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        nfRepository.Update(nf);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = nf.GetErros().Split(';');
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
                    NotaFiscalRepository nfRepository = new NotaFiscalRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    nfRepository.Delete(id);

                    _notasFiscais.Remove(_notasFiscais.Find(c => c.Id == id));
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

        private void dgvNotasFiscais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _notasFiscais[e.RowIndex].Id.ToString();
                this.txtNumNF.Text = _notasFiscais[e.RowIndex].NumNF.ToString();
                this.txtFornecedor.Text = _notasFiscais[e.RowIndex].Fornecedor.ToString();
                this.txtData.Text = _notasFiscais[e.RowIndex].Data.ToString("dd/MM/yyyy");
                this.cboEmpresa.Text = _notasFiscais[e.RowIndex].Empresa.ToString();
                this.txtLink.Text = _notasFiscais[e.RowIndex].Link.ToString();

                if (e.ColumnIndex == 5)
                {
                    string link = this.dgvNotasFiscais.Rows[e.RowIndex].Cells["Link"].Value.ToString();

                    FrmVisualizadorAdobe frmVisualizadorAdobe = new FrmVisualizadorAdobe(link);
                    // frmVisualizadorAdobe.MdiParent = MdiParent;
                    frmVisualizadorAdobe.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumNF_Leave(object sender, EventArgs e)
        {
            this.txtNumNF.Text = this.txtNumNF.Text.PadLeft(9, '0');
        }

        private void limparCampos()
        {
            this.txtId.Text = "";
            this.txtNumNF.Text = "";
            this.txtFornecedor.Text = "";
            this.txtData.Text = "";
            this.cboEmpresa.Text = "";
            this.txtLink.Text = "";

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNumNF.Text != "")
                this.Pesquisar("NumNF", this.txtNumNF.Text);
            else if (this.txtFornecedor.Text != "")
                this.Pesquisar("Fornecedor", this.txtFornecedor.Text);
            else if (this.txtData.Text != "  /  /")
                this.Pesquisar("Data", this.txtData.Text);
            else if (this.cboEmpresa.Text != "")
                this.Pesquisar("Empresa", this.cboEmpresa.Text);
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "NumNF":
                    _notasFiscais = _notasFiscaisOriginal.Where(c => c.NumNF.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Fornecedor":
                    _notasFiscais = _notasFiscaisOriginal.Where(c => c.Fornecedor.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Data":
                    _notasFiscais = _notasFiscaisOriginal.Where(c => c.Data.Equals(texto)).ToList();
                    break;
                case "Empresa":
                    _notasFiscais = _notasFiscaisOriginal.Where(c => c.Empresa.Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _notasFiscais = _notasFiscaisOriginal;
                    break;
                    // this.dgvComputadores.DataSource = _computadores;
            }
            this.AtualizaDataGridView();
        }

        private void dgvNotasFiscais_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvNotasFiscais.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if(colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NumNF":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.NumNF).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.NumNF).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Fornecedor":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.Fornecedor).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.Fornecedor).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Data":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.Data).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.Data).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Empresa":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.Empresa).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.Empresa).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Link":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _notasFiscais = _notasFiscais.OrderBy(x => x.Link).ToList();
                    }
                    else
                    {
                        _notasFiscais = _notasFiscais.OrderByDescending(x => x.Link).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void txtNumNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var arquivo = this.openFileDialog1.OpenFile();

            

            // System.IO.File.Copy();

            // @"\\fs\adm\Tics\Inventario"

        }
    }
}
