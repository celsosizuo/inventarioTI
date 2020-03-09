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
    public partial class FrmAssociarLicencaNoComputador : Form
    {
        private NotaFiscal _notaFiscal;
        private List<Computadores> _computadores;
        private List<Licenca> _licenca;

        public FrmAssociarLicencaNoComputador()
        {
            _notaFiscal = new NotaFiscal();
            _computadores = new List<Computadores>();
            _licenca = new List<Licenca>();
            InitializeComponent();
        }

        private void AssociarLicencaNoComputador_Load(object sender, EventArgs e)
        {
            List<Computadores> c = new List<Computadores>();
            ComputadoresRepository computadoresRepository = new ComputadoresRepository();

            Computadores c1 = new Computadores()
            {
                Id = 0,
                AtivoNovo = ""
            };

            c = computadoresRepository.Get().OrderBy(m => m.AtivoNovo).ToList();
            _computadores = c;
            c.Insert(0, c1);

            this.cboComputador.DataSource = c;
            this.cboComputador.DisplayMember = "AtivoNovo";
            this.cboComputador.ValueMember = "Id";
        }

        private void txtNumNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtNumNF_Leave(object sender, EventArgs e)
        {
            if (this.txtNumNF.Text != "")
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

                LicencaRepository l = new LicencaRepository();
                _licenca = l.Get();
                _licenca = _licenca.Where(li => li.NotaFiscal.Id == int.Parse(this.txtNotaFiscalIdReadOnly.Text)).ToList();
                List<LicencasResponse> licencasResponses = new List<LicencasResponse>();

                _licenca.ForEach(lic =>
                {
                    licencasResponses.Add((LicencasResponse)lic);
                });

                LicencasResponse lr = new LicencasResponse()
                {
                    Id = 0,
                    SoftwareEChave = "",
                };

                licencasResponses.Insert(0, lr);
                this.cboLicenca.DataSource = licencasResponses;
                this.cboLicenca.DisplayMember = "SoftwareEChave";
                this.cboLicenca.ValueMember = "Id";
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

        private void btnNovaPesquisaComputador_Click(object sender, EventArgs e)
        {
            this.cboComputador.Enabled = true;
            this.cboComputador.SelectedValue = 0;
            this.txtAtivoAntigoReadOnly.Clear();
            this.txtAtivoNovoReadOnly.Clear();
            this.txtUsuarioReadOnly.Clear();
            this.txtDepartamentoReadOnly.Clear();
            this.dgvLicencasAssociadas.DataSource = null;

        }

        private void cboComputador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cboComputador.SelectedIndex > 0)
            {
                Computadores c = _computadores.FirstOrDefault(co => co.Id == int.Parse(this.cboComputador.SelectedValue.ToString()));

                this.txtAtivoNovoReadOnly.Text = c.AtivoNovo;
                this.txtAtivoAntigoReadOnly.Text = c.AtivoAntigo;
                this.txtUsuarioReadOnly.Text = c.Usuario;
                this.txtDepartamentoReadOnly.Text = c.Departamento;
                this.cboComputador.Enabled = false;

                LicencaRepository l = new LicencaRepository();
                List<LicencasResponse> licencas = l.GetLicencasComputadoresResponses(int.Parse(this.cboComputador.SelectedValue.ToString()));

                this.dgvLicencasAssociadas.DataSource = licencas;
                this.dgvLicencasAssociadas.Columns["NotaFiscalId"].Visible = false;
                this.dgvLicencasAssociadas.Columns["SoftwareId"].Visible = false;
                this.dgvLicencasAssociadas.Columns["Software"].Visible = false;
                this.dgvLicencasAssociadas.Columns["NotaFiscal"].Visible = false;
                this.dgvLicencasAssociadas.Columns["SoftwareEChave"].Visible = false;
                this.dgvLicencasAssociadas.Columns["Quantidade"].Visible = false;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.cboComputador.Enabled = true;
            this.cboComputador.SelectedValue = 0;
            this.txtAtivoAntigoReadOnly.Clear();
            this.txtAtivoNovoReadOnly.Clear();
            this.txtUsuarioReadOnly.Clear();
            this.txtDepartamentoReadOnly.Clear();
            this.dgvLicencasAssociadas.DataSource = null;

            this.txtNotaFiscalIdReadOnly.Clear();
            this.txtNumNFReadOnly.Clear();
            this.txtFornecedorReadOnly.Clear();
            this.txtDataReadOnly.Clear();
            this.txtEmpresaReadOnly.Clear();
            this.txtLinkReadOnly.Clear();
            this.txtNumNF.ReadOnly = false;
            this.txtNumNF.Clear();

            this.cboLicenca.SelectedIndex = -1;
            this.cboLicenca.DataSource = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ComputadoresLicencaRepository clr = new ComputadoresLicencaRepository();
                ComputadoresLicencas c = new ComputadoresLicencas()
                {
                    LicencaId = int.Parse(this.cboLicenca.SelectedValue.ToString()),
                    ComputadoresId = int.Parse(this.cboComputador.SelectedValue.ToString()),
                };

                if (c.EhValido())
                {
                    clr.Add(c);

                    // atualizar o grid de licenças
                    LicencaRepository l = new LicencaRepository();
                    List<LicencasResponse> licencas = l.GetLicencasComputadoresResponses(int.Parse(this.cboComputador.SelectedValue.ToString()));

                    this.dgvLicencasAssociadas.DataSource = licencas;
                    this.dgvLicencasAssociadas.Columns["NotaFiscalId"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["SoftwareId"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["Software"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["NotaFiscal"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["SoftwareEChave"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["Quantidade"].Visible = false;

                    MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLicencasAssociadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtNumNF.Text = dgvLicencasAssociadas.Rows[e.RowIndex].Cells["NumNF"].Value.ToString();
                this.txtNumNF.Focus();
                this.dgvLicencasAssociadas.Focus();
                this.cboLicenca.SelectedValue = int.Parse(dgvLicencasAssociadas.Rows[e.RowIndex].Cells["Id"].Value.ToString());
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
                if (MessageBox.Show("Você tem certeza que deseja excluir a associação selecionada?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ComputadoresLicencaRepository crl = new ComputadoresLicencaRepository();
                    int computadorId = int.Parse(this.cboComputador.SelectedValue.ToString());
                    int licencaId = int.Parse(this.cboLicenca.SelectedValue.ToString());

                    crl.Delete(computadorId, licencaId);

                    // atualizar o grid de licenças
                    LicencaRepository l = new LicencaRepository();
                    List<LicencasResponse> licencas = l.GetLicencasComputadoresResponses(int.Parse(this.cboComputador.SelectedValue.ToString()));

                    this.dgvLicencasAssociadas.DataSource = licencas;
                    this.dgvLicencasAssociadas.Columns["NotaFiscalId"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["SoftwareId"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["Software"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["NotaFiscal"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["SoftwareEChave"].Visible = false;
                    this.dgvLicencasAssociadas.Columns["Quantidade"].Visible = false;

                    // Limpando os campos da parte da Nota Fiscal
                    this.txtNotaFiscalIdReadOnly.Clear();
                    this.txtNumNFReadOnly.Clear();
                    this.txtFornecedorReadOnly.Clear();
                    this.txtDataReadOnly.Clear();
                    this.txtEmpresaReadOnly.Clear();
                    this.txtLinkReadOnly.Clear();
                    this.txtNumNF.ReadOnly = false;
                    this.txtNumNF.Clear();

                    this.cboLicenca.SelectedIndex = -1;
                    this.cboLicenca.DataSource = null;

                    MessageBox.Show("Associação excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
