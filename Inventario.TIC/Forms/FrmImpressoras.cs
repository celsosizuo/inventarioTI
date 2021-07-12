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
    public partial class FrmImpressoras : Form
    {
        private List<Impressora> _impressoras;
        private List<Impressora> _impressorasOriginal;
        private List<ImpressoraResponse> _impressorasReponse;
        private string _colunaSelecionada;

        public FrmImpressoras()
        {
            _impressoras = new List<Impressora>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvImpressoras.DataSource = null;
            this.dgvImpressoras.DataSource = _impressorasReponse;

            // Ocultando colunas desnecessárias
            // this.dgvImpressoras.Columns["CascadeMode"].Visible = false;
        }

        private void FrmImpressora_Load(object sender, EventArgs e)
        {
            ImpressoraRepository impressora = new ImpressoraRepository();
            _impressoras = impressora.Get();
            _impressorasReponse = impressora.GetResponse();
            _impressorasOriginal = _impressoras;
            this.dgvImpressoras.DataSource = _impressoras;
            this.AtualizaDataGridView();

            TipoImpressaoRepository tipoImpressaoRepository = new TipoImpressaoRepository();
            List<TipoImpressao> tiposImpressao = new List<TipoImpressao>();
            tiposImpressao = tipoImpressaoRepository.Get();
            TipoImpressao tipoImpressao = new TipoImpressao()
            {
                Id = 0,
                Descricao = ""
            };
            tiposImpressao.Insert(0, tipoImpressao);
            this.cboTipoImpressaoId.DataSource = tiposImpressao;
            this.cboTipoImpressaoId.DisplayMember = "DESCRICAO";
            this.cboTipoImpressaoId.ValueMember = "ID";

            FornecedorRepository fornecedorRepository = new FornecedorRepository();
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            fornecedores = fornecedorRepository.Get();

            Fornecedor fornecedor = new Fornecedor()
            {
                Id = 0,
                Nome = "",
            };
            fornecedores.Insert(0, fornecedor);
            this.cboFornecedorId.DataSource = fornecedores;
            this.cboFornecedorId.DisplayMember = "NOME";
            this.cboFornecedorId.ValueMember = "ID";

            this.cboStatus.DataSource = impressora.GetImpressoraStatus();
            this.cboStatus.DisplayMember = "DESCRICAO";
            this.cboStatus.ValueMember = "CODIGO";

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ImpressoraRepository impressoraRepository = new ImpressoraRepository();
                Impressora impressora;

                if (this.txtId.Text == "")
                    impressora = new Impressora();
                else
                    impressora = _impressoras.Find(n => n.Id == int.Parse(this.txtId.Text));

                impressora.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                impressora.FornecedorId = int.Parse(this.cboFornecedorId.SelectedValue.ToString());
                impressora.TipoImpressaoId = int.Parse(this.cboTipoImpressaoId.SelectedValue.ToString());
                impressora.NumSerie = this.txtNumSerie.Text;
                impressora.Modelo = this.txtModelo.Text;
                impressora.Setor = this.txtSetor.Text;
                impressora.CCusto = this.txtCCusto.Text;
                impressora.ValorFixo = decimal.Parse(this.txtValorFixo.Text);
                impressora.Observacao = this.txtObservacao.Text;
                impressora.Status = this.cboStatus.SelectedValue.ToString();

                if (impressora.EhValido())
                {
                    if (impressora.Id == 0)
                    {
                        string retorno = impressoraRepository.Add(impressora);
                        this.txtId.Text = retorno.ToString();
                        impressora.Id = int.Parse(retorno);
                        _impressoras.Add(impressora);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        impressoraRepository.Update(impressora);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = impressora.GetErros().Split(';');
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
                    ImpressoraRepository impressoraRepository = new ImpressoraRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    impressoraRepository.Delete(id);

                    _impressoras.Remove(_impressoras.Find(c => c.Id == id));
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
            this.cboFornecedorId.SelectedIndex = -1;
            this.cboTipoImpressaoId.SelectedIndex = -1;
            this.txtNumSerie.Clear();
            this.txtModelo.Clear();
            this.txtSetor.Clear();
            this.txtCCusto.Clear();
            this.txtValorFixo.Clear();
            this.txtObservacao.Clear();
            this.cboStatus.SelectedIndex = -1;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvImpressoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _impressoras[e.RowIndex].Id.ToString();
                this.cboFornecedorId.SelectedValue = _impressoras[e.RowIndex].FornecedorId;
                this.cboTipoImpressaoId.SelectedValue = _impressoras[e.RowIndex].TipoImpressaoId;
                this.txtNumSerie.Text = _impressoras[e.RowIndex].NumSerie.ToString();
                this.txtModelo.Text = _impressoras[e.RowIndex].Modelo.ToString();
                this.txtSetor.Text = _impressoras[e.RowIndex].Setor.ToString();
                this.txtCCusto.Text = _impressoras[e.RowIndex].CCusto.ToString();
                this.txtValorFixo.Text = _impressoras[e.RowIndex].ValorFixo.ToString();
                this.txtObservacao.Text = _impressoras[e.RowIndex].Observacao.ToString();
                this.cboStatus.SelectedValue = _impressoras[e.RowIndex].Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtModelo.Text != "")
                this.Pesquisar("Modelo", this.txtModelo.Text);
            else if (this.txtNumSerie.Text != "")
                this.Pesquisar("NumSerie", this.txtNumSerie.Text);
            else if (this.txtSetor.Text != "")
                this.Pesquisar("Setor", this.txtSetor.Text);
            else if (this.cboTipoImpressaoId.SelectedValue.ToString() != "")
                this.Pesquisar("TipoImpressaoId", this.cboTipoImpressaoId.SelectedValue.ToString());
            else if (this.cboFornecedorId.SelectedValue.ToString() != "")
                this.Pesquisar("FornecedorId", this.cboFornecedorId.SelectedValue.ToString());
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Modelo":
                    _impressoras = _impressorasOriginal.Where(c => c.Modelo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "NumSerie":
                    _impressoras = _impressorasOriginal.Where(c => c.NumSerie.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Setor":
                    _impressoras = _impressorasOriginal.Where(c => c.Setor.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "TipoImpressaoId":
                    _impressoras = _impressorasOriginal.Where(c => c.TipoImpressaoId.Equals(texto.ToUpper())).ToList();
                    break;
                case "FornecedorId":
                    _impressoras = _impressorasOriginal.Where(c => c.FornecedorId.Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _impressoras = _impressorasOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvImpressoras_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvImpressoras.Columns[e.ColumnIndex].Name;

            //switch (colunaSelecionada)
            //{
            //    case "Id":
            //        if (colunaSelecionada != this._colunaSelecionada)
            //        {
            //            this._colunaSelecionada = colunaSelecionada;
            //            _impressoras = _impressoras.OrderBy(x => x.Id).ToList();
            //        }
            //        else
            //        {
            //            _impressoras = _impressoras.OrderByDescending(x => x.Id).ToList();
            //            this._colunaSelecionada = "";
            //        }
            //        break;
            //    case "Nome":
            //        if (colunaSelecionada != this._colunaSelecionada)
            //        {
            //            this._colunaSelecionada = colunaSelecionada;
            //            _impressoras = _impressoras.OrderBy(x => x.Nome).ToList();
            //        }
            //        else
            //        {
            //            _impressoras = _impressoras.OrderByDescending(x => x.Nome).ToList();
            //            this._colunaSelecionada = "";
            //        }
            //        break;
            //    case "Fabricante":
            //        if (colunaSelecionada != this._colunaSelecionada)
            //        {
            //            this._colunaSelecionada = colunaSelecionada;
            //            _impressoras = _impressoras.OrderBy(x => x.Fabricante).ToList();
            //        }
            //        else
            //        {
            //            _impressoras = _impressoras.OrderByDescending(x => x.Fabricante).ToList();
            //            this._colunaSelecionada = "";
            //        }
            //        break;
            //    case "Versao":
            //        if (colunaSelecionada != this._colunaSelecionada)
            //        {
            //            this._colunaSelecionada = colunaSelecionada;
            //            _impressoras = _impressoras.OrderBy(x => x.Versao).ToList();
            //        }
            //        else
            //        {
            //            _impressoras = _impressoras.OrderByDescending(x => x.Versao).ToList();
            //            this._colunaSelecionada = "";
            //        }
            //        break;
            //    case "NomeTecnico":
            //        if (colunaSelecionada != this._colunaSelecionada)
            //        {
            //            this._colunaSelecionada = colunaSelecionada;
            //            _impressoras = _impressoras.OrderBy(x => x.NomeTecnico).ToList();
            //        }
            //        else
            //        {
            //            _impressoras = _impressoras.OrderByDescending(x => x.NomeTecnico).ToList();
            //            this._colunaSelecionada = "";
            //        }
            //        break;
            //    default:
            //        break;
            //}
            this.AtualizaDataGridView();
        }
    }
}
