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
    public partial class FrmReferencia : Form
    {
        private List<Referencia> _referencias;
        private List<Referencia> _referenciasOriginal;
        private string _colunaSelecionada;

        public FrmReferencia()
        {
            _referencias = new List<Referencia>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvReferencia.DataSource = null;
            this.dgvReferencia.DataSource = _referencias;

            // Ocultando colunas desnecessárias
            this.dgvReferencia.Columns["CascadeMode"].Visible = false;
        }

        private void FrmReferencia_Load(object sender, EventArgs e)
        {
            ReferenciaRepository referencia = new ReferenciaRepository();

            _referencias = referencia.Get();
            _referenciasOriginal = _referencias;
            this.dgvReferencia.DataSource = _referencias;
            this.AtualizaDataGridView();

            // Adicionando os valores no combobox
            this.cboStatus.DataSource = referencia.GetReferenciaStatus();
            this.cboStatus.DisplayMember = "DESCRICAO";
            this.cboStatus.ValueMember = "CODIGO";

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ReferenciaRepository referenciaRepository = new ReferenciaRepository();
                Referencia referencia;

                if (this.txtId.Text == "")
                    referencia = new Referencia();
                else
                    referencia = _referencias.Find(n => n.Id == int.Parse(this.txtId.Text));

                referencia.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                referencia.Ref = this.txtRef.Text;
                referencia.DataInicio = DateTime.Parse(this.txtDataInicio.Text);
                referencia.DataFim = DateTime.Parse(this.txtDataFim.Text);
                referencia.Status = this.cboStatus.SelectedValue.ToString();

                if (referencia.EhValido())
                {
                    if (referencia.Id == 0)
                    {
                        string retorno = referenciaRepository.Add(referencia);
                        this.txtId.Text = retorno.ToString();
                        referencia.Id = int.Parse(retorno);
                        _referencias.Add(referencia);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        referenciaRepository.Update(referencia);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = referencia.GetErros().Split(';');
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
                    ReferenciaRepository referenciaRepository = new ReferenciaRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    referenciaRepository.Delete(id);

                    _referencias.Remove(_referencias.Find(c => c.Id == id));
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
            this.txtRef.Clear();
            this.txtDataFim.Clear();
            this.txtDataInicio.Clear();
            this.cboStatus.SelectedIndex = -1;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvReferencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _referencias[e.RowIndex].Id.ToString();
                this.txtRef.Text = _referencias[e.RowIndex].Ref.ToString();
                this.txtDataInicio.Text = _referencias[e.RowIndex].DataInicio.ToString();
                this.txtDataFim.Text = _referencias[e.RowIndex].DataFim.ToString();
                this.cboStatus.SelectedValue = _referencias[e.RowIndex].Status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtRef.Text != "")
                this.Pesquisar("Ref", this.txtRef.Text);
            else if (this.txtDataFim.Text != "")
                this.Pesquisar("DataFim", this.txtDataFim.Text);
            else if (this.txtDataInicio.Text != "")
                this.Pesquisar("DataInicio", this.txtDataInicio.Text);
            else if (this.cboStatus.SelectedValue.ToString() != "")
                this.Pesquisar("Status", this.cboStatus.SelectedValue.ToString());
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Ref":
                    _referencias = _referenciasOriginal.Where(c => c.Ref.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "DataInicio":
                    _referencias = _referenciasOriginal.Where(c => c.DataInicio.Equals(texto)).ToList();
                    break;
                case "DataFim":
                    _referencias = _referenciasOriginal.Where(c => c.DataFim.Equals(texto)).ToList();
                    break;
                case "Status":
                    _referencias = _referenciasOriginal.Where(c => c.Status.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _referencias = _referenciasOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvReferencias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvReferencia.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _referencias = _referencias.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _referencias = _referencias.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "DataInicio":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _referencias = _referencias.OrderBy(x => x.DataInicio).ToList();
                    }
                    else
                    {
                        _referencias = _referencias.OrderByDescending(x => x.DataInicio).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "DataFim":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _referencias = _referencias.OrderBy(x => x.DataFim).ToList();
                    }
                    else
                    {
                        _referencias = _referencias.OrderByDescending(x => x.DataFim).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Status":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _referencias = _referencias.OrderBy(x => x.Status).ToList();
                    }
                    else
                    {
                        _referencias = _referencias.OrderByDescending(x => x.Status).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Ref":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _referencias = _referencias.OrderBy(x => x.Ref).ToList();
                    }
                    else
                    {
                        _referencias = _referencias.OrderByDescending(x => x.Ref).ToList();
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
