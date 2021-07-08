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
    public partial class FrmTipoImpressao : Form
    {
        private List<TipoImpressao> _tipoImpressao;
        private List<TipoImpressao> _tipoImpressaoOriginal;
        private string _colunaSelecionada;

        public FrmTipoImpressao()
        {
            _tipoImpressao = new List<TipoImpressao>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvTipoImpressao.DataSource = null;
            this.dgvTipoImpressao.DataSource = _tipoImpressao;

            // Ocultando colunas desnecessárias
            this.dgvTipoImpressao.Columns["CascadeMode"].Visible = false;
        }

        private void FrmTipoImpressao_Load(object sender, EventArgs e)
        {
            TipoImpressaoRepository tipoImpressao = new TipoImpressaoRepository();

            _tipoImpressao = tipoImpressao.Get();
            _tipoImpressaoOriginal = _tipoImpressao;
            this.dgvTipoImpressao.DataSource = _tipoImpressao;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoImpressaoRepository tipoImpressaoRepository = new TipoImpressaoRepository();
                TipoImpressao tipoImpressao;

                if (this.txtId.Text == "")
                    tipoImpressao = new TipoImpressao();
                else
                    tipoImpressao = _tipoImpressao.Find(n => n.Id == int.Parse(this.txtId.Text));

                tipoImpressao.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                tipoImpressao.Descricao = this.txtDescricao.Text;

                if (tipoImpressao.EhValido())
                {
                    if (tipoImpressao.Id == 0)
                    {
                        string retorno = tipoImpressaoRepository.Add(tipoImpressao);
                        this.txtId.Text = retorno.ToString();
                        tipoImpressao.Id = int.Parse(retorno);
                        _tipoImpressao.Add(tipoImpressao);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        tipoImpressaoRepository.Update(tipoImpressao);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = tipoImpressao.GetErros().Split(';');
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
                    TipoImpressaoRepository tipoImpressaoRepository = new TipoImpressaoRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    tipoImpressaoRepository.Delete(id);

                    _tipoImpressao.Remove(_tipoImpressao.Find(c => c.Id == id));
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
            this.txtDescricao.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvTipoImpressaos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _tipoImpressao[e.RowIndex].Id.ToString();
                this.txtDescricao.Text = _tipoImpressao[e.RowIndex].Descricao.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtDescricao.Text != "")
                this.Pesquisar("Nome", this.txtDescricao.Text);
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Descricao":
                    _tipoImpressao = _tipoImpressaoOriginal.Where(c => c.Descricao.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _tipoImpressao = _tipoImpressaoOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvTipoImpressaos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvTipoImpressao.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _tipoImpressao = _tipoImpressao.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _tipoImpressao = _tipoImpressao.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Descricao":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _tipoImpressao = _tipoImpressao.OrderBy(x => x.Descricao).ToList();
                    }
                    else
                    {
                        _tipoImpressao = _tipoImpressao.OrderByDescending(x => x.Descricao).ToList();
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
