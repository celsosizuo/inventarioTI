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
    public partial class FrmLicencas : Form
    {
        private Software _software;
        private NotaFiscal _notaFiscal;
        private List<Software> _softwares;
        private List<Licenca> _licencas;
        private List<LicencasResponse> _licencasResponse;
        private List<LicencasResponse> _licencasResponseOriginal;
        private string _colunaSelecionada;

        public FrmLicencas()
        {
            _softwares = new List<Software>();
            _licencas = new List<Licenca>();
            _licencasResponse = new List<LicencasResponse>();
            _software = new Software();
            _notaFiscal = new NotaFiscal();
            InitializeComponent();
        }

        private void txtNumNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnNovaPesquisa_Click(object sender, EventArgs e)
        {
            this.txtNotaFiscalIdReadOnly.Clear();
            this.txtNumNFReadOnly.Clear();
            this.txtFornecedorReadOnly.Clear();
            this.txtDataReadOnly.Clear();
            this.txtEmpresaReadOnly.Clear();
            this.txtLinkReadOnly.Clear();
            this.txtNumNF.ReadOnly = false;
            this.txtNumNF.Clear();
        }

        private void FrmLicencas_Load(object sender, EventArgs e)
        {
            SoftwareRepository softwareRepository = new SoftwareRepository();
            _softwares = softwareRepository.Get().OrderBy(s => s.Nome).ToList();

            Software soft = new Software()
            {
                Id = 0,
                Nome = "",
                Fabricante = "",
                Versao = ""
            };
            _softwares.Insert(0, soft);

            

            this.cboSoftware.DataSource = _softwares;
            this.cboSoftware.ValueMember = "Id";
            this.cboSoftware.DisplayMember = "Nome";

            Status status = new Status();
            this.cboStatus.DataSource = status.Get();
            this.cboStatus.ValueMember = "Codigo";
            this.cboStatus.DisplayMember = "Valor";

            this.CarregarDataGridView();
        }

        private void CarregarDataGridView()
        {
            // Carregando a lista de computadores
            LicencaRepository c = new LicencaRepository();
            _licencasResponse = c.GetLicencasResponses().ToList();
            _licencasResponseOriginal = _licencasResponse;
            _licencas = _licencasResponse.Select(x => (Licenca)x).ToList();

            this.dgvLicencas.DataSource = _licencasResponse;
            this.AtualizaDataGridView();
        }

        private void AtualizaDataGridView()
        {
            this.dgvLicencas.DataSource = null;
            this.dgvLicencas.DataSource = _licencasResponse;

            // Ocultando colunas desnecessárias
            this.dgvLicencas.Columns["Quantidade"].Visible = false;
            this.dgvLicencas.Columns["NotaFiscalId"].Visible = false;
            this.dgvLicencas.Columns["SoftwareId"].Visible = false;
            this.dgvLicencas.Columns["Software"].Visible = false;
            this.dgvLicencas.Columns["NotaFiscal"].Visible = false;
            // this.dgvLicencas.Columns["CascadeMode"].Visible = false;

        }

        private void cboSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoftware.SelectedIndex > 0)
            {
                Software s = _softwares.FirstOrDefault(so => so.Id == int.Parse(cboSoftware.SelectedValue.ToString()));

                this.txtNomeReadOnly.Text = s.Nome;
                this.txtFabricanteReadOnly.Text = s.Fabricante;
                this.txtVersaoReadOnly.Text = s.Versao;
                this.cboSoftware.Enabled = false;

                _software = s;
            }
        }

        private void btnNovaPesquisaSoftware_Click(object sender, EventArgs e)
        {
            this.txtNomeReadOnly.Text = "";
            this.txtFabricanteReadOnly.Text = "";
            this.txtVersaoReadOnly.Text = "";
            this.cboSoftware.Enabled = true;
            this.cboSoftware.SelectedIndex = 0;
        }

        private void txtNumNF_Leave_1(object sender, EventArgs e)
        {
            if(this.txtNumNF.Text != "")
            {
                this.txtNumNF.Text = this.txtNumNF.Text.PadLeft(9, '0');

                NotaFiscalRepository nfRepository = new NotaFiscalRepository();
                NotaFiscal nf = nfRepository.GetById(this.txtNumNF.Text);

                if (nf == null)
                    MessageBox.Show("Não foi encontrato nota fiscal com este número. Favor refazer a pesquisa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.txtNotaFiscalIdReadOnly.Text = nf.Id.ToString();
                    this.txtNumNFReadOnly.Text = nf.NumNF;
                    this.txtFornecedorReadOnly.Text = nf.Fornecedor;
                    this.txtDataReadOnly.Text = nf.Data.ToString("dd/MM/yyyy");
                    this.txtEmpresaReadOnly.Text = nf.Empresa;
                    this.txtLinkReadOnly.Text = nf.Link;
                    this.txtNumNF.ReadOnly = true;
                }

                _notaFiscal = nf;
            }
        }

        private void dgvLicencas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtNumNF.Text = _licencasResponse[e.RowIndex].NumNF.ToString();
            this.cboSoftware.SelectedValue = int.Parse(_licencasResponse[e.RowIndex].SoftwareId.ToString());
            this.txtNumNF.Focus();
            this.dgvLicencas.Focus();
            this.txtChave.Text = _licencasResponse[e.RowIndex].Chave.ToString();
            this.cboStatus.SelectedValue = _licencasResponse[e.RowIndex].Status.ToString();
            this.txtId.Text = _licencasResponse[e.RowIndex].Id.ToString();
        }

        private void limparCampos()
        {
            this.txtId.Clear();
            this.txtNotaFiscalIdReadOnly.Clear();
            this.txtNumNFReadOnly.Clear();
            this.txtFornecedorReadOnly.Clear();
            this.txtDataReadOnly.Clear();
            this.txtEmpresaReadOnly.Clear();
            this.txtLinkReadOnly.Clear();
            this.txtNumNF.ReadOnly = false;
            this.txtNumNF.Clear();
            this.txtNomeReadOnly.Clear();
            this.txtFabricanteReadOnly.Clear();
            this.txtVersaoReadOnly.Clear();
            this.cboSoftware.Enabled = true;
            this.cboSoftware.SelectedIndex = 0;
            this.txtChave.Clear();
            this.cboStatus.SelectedIndex = 0;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                LicencaRepository licencaRepository = new LicencaRepository();
                Licenca licenca;

                if (this.txtId.Text == "")
                    licenca = new Licenca();
                else
                    licenca = _licencas.Find(n => n.Id == int.Parse(this.txtId.Text));

                // Campos
                licenca.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                // licenca.NotaFiscal.Id = int.Parse(this.txtNotaFiscalIdReadOnly.Text);
                licenca.NotaFiscal = _notaFiscal;
                // licenca.Software.Id = int.Parse(this.cboSoftware.SelectedValue.ToString());
                licenca.Software = _software;
                licenca.Quantidade = 1;
                licenca.Chave = this.txtChave.Text;
                licenca.Status = this.cboStatus.SelectedValue.ToString();

                if (licenca.EhValido())
                {
                    if (licenca.Id == 0)
                    {
                        string retorno = licencaRepository.Add(licenca);
                        this.txtId.Text = retorno.ToString();
                        licenca.Id = int.Parse(retorno);
                        _licencas.Add(licenca);
                        _licencasResponse.Add((LicencasResponse)licenca);
                        
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        licencaRepository.Update(licenca);
                        _licencasResponse = _licencas.Select(x => (LicencasResponse)x).ToList();

                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.CarregarDataGridView();
                }
                else
                {
                    string[] msgs = licenca.GetErros().Split(';');
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNumNF.Text != "")
                this.Pesquisar("NumNF", this.txtNumNF.Text);
            else if (this.cboSoftware.SelectedIndex > 0)
                this.Pesquisar("NomeSoftware", this.cboSoftware.Text);
            else if (this.txtChave.Text != "")
                this.Pesquisar("Chave", this.txtChave.Text);
            else if (this.cboStatus.SelectedIndex > 0)
                this.Pesquisar("Status", this.cboStatus.SelectedValue.ToString());
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "NumNF":
                    _licencasResponse = _licencasResponseOriginal.Where(c => c.NumNF.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "NomeSoftware":
                    _licencasResponse = _licencasResponseOriginal.Where(c => c.NomeSoftware.Contains(texto)).ToList();
                    break;
                case "Chave":
                    _licencasResponse = _licencasResponseOriginal.Where(c => c.Chave.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Status":
                    _licencasResponse = _licencasResponseOriginal.Where(c => c.Status.Equals(texto)).ToList();
                    break;
                default:
                    _licencasResponse = _licencasResponseOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvLicencas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvLicencas.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _licencasResponse = _licencasResponse.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _licencasResponse = _licencasResponse.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NumNF":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _licencasResponse = _licencasResponse.OrderBy(x => x.NumNF).ToList();
                    }
                    else
                    {
                        _licencasResponse = _licencasResponse.OrderByDescending(x => x.NumNF).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NomeSoftware":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _licencasResponse = _licencasResponse.OrderBy(x => x.NomeSoftware).ToList();
                    }
                    else
                    {
                        _licencasResponse = _licencasResponse.OrderByDescending(x => x.NomeSoftware).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Chave":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _licencasResponse = _licencasResponse.OrderBy(x => x.Chave).ToList();
                    }
                    else
                    {
                        _licencasResponse = _licencasResponse.OrderByDescending(x => x.Chave).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Status":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _licencasResponse = _licencasResponse.OrderBy(x => x.Status).ToList();
                    }
                    else
                    {
                        _licencasResponse = _licencasResponse.OrderByDescending(x => x.Status).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;

                default:
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComputadoresLicencaRepository a = new ComputadoresLicencaRepository();

            a.Get();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LicencaRepository licencasRepository = new LicencaRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    licencasRepository.Delete(id);

                    _licencas.Remove(_licencas.Find(c => c.Id == id));
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
    }
}
