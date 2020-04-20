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
    public partial class FrmPrecoContaEMail : Form
    {
        private List<PrecoContaEMail> _precoContaEMail;
        private List<PrecoContaEMail> _precoContaEMailOriginal;
        private string _colunaSelecionada;

        public FrmPrecoContaEMail()
        {
            _precoContaEMail = new List<PrecoContaEMail>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvPrecoContaEMail.DataSource = null;
            this.dgvPrecoContaEMail.DataSource = _precoContaEMail;

            // Ocultando colunas desnecessárias
            this.dgvPrecoContaEMail.Columns["CascadeMode"].Visible = false;
        }

        private void FrmPrecoContaEMail_Load(object sender, EventArgs e)
        {
            PrecoContaEMailRepository precoContaEMail = new PrecoContaEMailRepository();

            _precoContaEMail = precoContaEMail.Get();
            _precoContaEMailOriginal = _precoContaEMail;
            this.dgvPrecoContaEMail.DataSource = _precoContaEMail;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PrecoContaEMailRepository precoContaEMailRepository = new PrecoContaEMailRepository();
                PrecoContaEMail precoContaEMail;

                if (this.txtId.Text == "")
                    precoContaEMail = new PrecoContaEMail();
                else
                    precoContaEMail = _precoContaEMail.Find(n => n.Id == int.Parse(this.txtId.Text));

                precoContaEMail.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                precoContaEMail.TipoConta = this.txtTipoConta.Text;
                precoContaEMail.ValorUnitSemImposto = decimal.Parse(this.txtValorUnitSemImposto.Text);
                precoContaEMail.CargaTributaria = decimal.Parse(this.txtCargaTributaria.Text);
                precoContaEMail.ValorUnitComImposto = decimal.Parse(this.txtValorUnitComImposto.Text);

                if (precoContaEMail.EhValido())
                {
                    if (precoContaEMail.Id == 0)
                    {
                        string retorno = precoContaEMailRepository.Add(precoContaEMail);
                        this.txtId.Text = retorno.ToString();
                        precoContaEMail.Id = int.Parse(retorno);
                        _precoContaEMail.Add(precoContaEMail);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        precoContaEMailRepository.Update(precoContaEMail);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = precoContaEMail.GetErros().Split(';');
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
                    PrecoContaEMailRepository precoContaEMailRepository = new PrecoContaEMailRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    precoContaEMailRepository.Delete(id);

                    _precoContaEMail.Remove(_precoContaEMail.Find(c => c.Id == id));
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
            this.txtTipoConta.Clear();
            this.txtValorUnitSemImposto.Clear();
            this.txtCargaTributaria.Clear();
            this.txtValorUnitComImposto.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtTipoConta.Text != "")
                this.Pesquisar("TipoConta", this.txtTipoConta.Text);
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "TipoConta":
                    _precoContaEMail = _precoContaEMailOriginal.Where(c => c.TipoConta.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _precoContaEMail = _precoContaEMailOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvPrecoContaEMail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _precoContaEMail[e.RowIndex].Id.ToString();
                this.txtTipoConta.Text = _precoContaEMail[e.RowIndex].TipoConta.ToString();
                this.txtValorUnitSemImposto.Text = _precoContaEMail[e.RowIndex].ValorUnitSemImposto.ToString();
                this.txtCargaTributaria.Text = _precoContaEMail[e.RowIndex].CargaTributaria.ToString();
                this.txtValorUnitComImposto.Text = _precoContaEMail[e.RowIndex].ValorUnitComImposto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrecoContaEMail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvPrecoContaEMail.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _precoContaEMail = _precoContaEMail.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _precoContaEMail = _precoContaEMail.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "TipoConta":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _precoContaEMail = _precoContaEMail.OrderBy(x => x.TipoConta).ToList();
                    }
                    else
                    {
                        _precoContaEMail = _precoContaEMail.OrderByDescending(x => x.TipoConta).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "ValorUnitSemImposto":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _precoContaEMail = _precoContaEMail.OrderBy(x => x.ValorUnitSemImposto).ToList();
                    }
                    else
                    {
                        _precoContaEMail = _precoContaEMail.OrderByDescending(x => x.ValorUnitSemImposto).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "CargaTributaria":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _precoContaEMail = _precoContaEMail.OrderBy(x => x.CargaTributaria).ToList();
                    }
                    else
                    {
                        _precoContaEMail = _precoContaEMail.OrderByDescending(x => x.CargaTributaria).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "ValorUnitComImposto":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _precoContaEMail = _precoContaEMail.OrderBy(x => x.ValorUnitComImposto).ToList();
                    }
                    else
                    {
                        _precoContaEMail = _precoContaEMail.OrderByDescending(x => x.ValorUnitComImposto).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void txtValorUnitSemImposto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCargaTributaria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValorUnitComImposto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValorUnitSemImposto_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtValorUnitSemImposto.Text == "" ? 0 : decimal.Parse(this.txtValorUnitSemImposto.Text);
            this.txtValorUnitSemImposto.Text = valor.ToString("N4");
        }

        private void txtCargaTributaria_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtCargaTributaria.Text == "" ? 0 : decimal.Parse(this.txtCargaTributaria.Text);
            this.txtCargaTributaria.Text = valor.ToString("N4");
        }

        private void txtValorUnitComImposto_Leave(object sender, EventArgs e)
        {
            decimal valor = this.txtValorUnitComImposto.Text == "" ? 0 : decimal.Parse(this.txtValorUnitComImposto.Text);
            this.txtValorUnitComImposto.Text = valor.ToString("N4");
        }
    }
}
