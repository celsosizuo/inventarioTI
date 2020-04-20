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
    public partial class FrmRateioImpressoras : Form
    {
        private List<RateioCentroCusto> _rateios;
        private List<dynamic> _dadosPedido;
        private decimal _valorTotalRateio = 0;
        private decimal _valorTotalPedido = 0;
        private decimal _diferenca = 0;
        private bool sucesso = false;

        public FrmRateioImpressoras ()
        {
            _rateios = new List<RateioCentroCusto>();
            _dadosPedido = new List<dynamic>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvRateios.DataSource = null;
            this.dgvRateios.DataSource = _rateios;

            // Ocultando colunas desnecessárias
            // this.dgvRateios.Columns["CascadeMode"].Visible = false;
            this.dgvRateios.Columns["CodColigada"].Visible = false;
            this.dgvRateios.Columns["IdMov"].Visible = false;
            this.dgvRateios.Columns["NSeqItMMov"].Visible = false;
            this.dgvRateios.Columns["Referencia"].Visible = false;
            this.dgvRateios.Columns["IdMovRatCcu"].Visible = false;
        }

        private void CalcularDiferenca()
        {
            this.lblTotalRateado.Text = "Valor Total Rateado: " + _valorTotalRateio.ToString("C4");
            this.lblTotalPedido.Text = "Valor Total do Pedido TOTVS: " + _valorTotalPedido.ToString("C4");

            _diferenca = decimal.Round(_valorTotalPedido, 4) - decimal.Round(_valorTotalRateio, 4);

            this.lblDiferenca.Text = "Diferença apurada: " + _diferenca.ToString("C4");
        }

        private void btnVerificarDadosPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNumPedido.Text == "")
                    throw new Exception("Favor digitar um número de pedido de compra");

                RateioCentroCusto rateio = new RateioCentroCusto();
                List<dynamic> dadosPedido = rateio.GetDadosPedidoTOTVS(this.txtNumPedido.Text);

                this.txtIdMovReadOnly.Text = dadosPedido[0].IDMOV.ToString();
                this.txtNumeroMovReadOnly.Text = dadosPedido[0].NUMEROMOV;
                this.txtFornecedorReadOnly.Text = dadosPedido[0].FORNECEDOR;
                this.txtDataEmissaoReadOnly.Text = dadosPedido[0].DATAEMISSAO.ToString("dd/MM/yyyy");
                this.txtValorReadOnly.Text = dadosPedido[0].VALORLIQUIDO.ToString("N2");

                _dadosPedido = dadosPedido;

                _valorTotalPedido = dadosPedido[0].VALORLIQUIDO;

                this.txtNumPedido.ReadOnly = true;

                this.CalcularDiferenca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cboReferencia.Text == "")
                    throw new Exception("Favor selecionar uma referência");

                RateioCentroCusto rateio = new RateioCentroCusto();
               
                _rateios = rateio.GetRateioImpressoras(this.cboReferencia.Text);
                decimal totalUsuarios = _rateios.Sum(r => r.Qtde ?? 0);

                _valorTotalRateio = 0;

                _rateios.ForEach(x => {
                    x.Porcentagem = decimal.Round(((x.Qtde / totalUsuarios) * 100) ?? 0, 4);
                    // x.Valor = decimal.Round((((x.Porcentagem / 100) * totalFatura) ?? 0), 4);
                    _valorTotalRateio += x.Valor;
                });


                this.AtualizaDataGridView();
                this.CalcularDiferenca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LancarRateio()
        {
            try
            {
                LancarRateioTOTVS lancarRateioTOTVS = new LancarRateioTOTVS();

                if (_dadosPedido.Count() > 0)
                {
                    RateioCentroCusto rateio = new RateioCentroCusto();
                    _dadosPedido = rateio.GetDadosPedidoTOTVS(this.txtNumPedido.Text);

                    int idMovRatCcu = rateio.GetLastIdMovRatCCu();
                    idMovRatCcu++;


                    if (_rateios.Count() <= 0)
                        throw new Exception("Favor selecionar uma referência e clicar no botão 'Listar'.");

                    _rateios.ForEach(r =>
                    {
                        r.CodColigada = _dadosPedido[0].CODCOLIGADA;
                        r.IdMov = _dadosPedido[0].IDMOV;
                        r.NSeqItMMov = _dadosPedido[0].NSEQITMMOV;
                        r.IdMovRatCcu = idMovRatCcu;
                        idMovRatCcu++;
                    });

                    if (this.txtUsuarioTOTVS.Text == "" || this.txtSenhaTOTVS.Text == "")
                        throw new Exception("Favor digitar usuário e senha do TOTVS.");

                    string retorno = lancarRateioTOTVS.InserirRateioTOTVS(this.txtUsuarioTOTVS.Text, this.txtSenhaTOTVS.Text, _rateios);

                    if (retorno.Contains(";"))
                        sucesso = true;
                    else
                        throw new Exception(retorno);
                }
                else
                    throw new Exception("O pedido da TOTVS não foi verificado. Favor digitar o número do pedido e clicar em 'Verificar Dados do Pedido'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLancarRateio_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Round(_diferenca, 2) != 0)
                    throw new Exception("Existe diferença de " + _diferenca.ToString("C2") + " entre o valor do pedido e o rateio calculado. Favor corrigir o rateio ou alterar o valor do pedido no TOTVS.");
                else
                {
                    using (FrmWaitingForm frm = new FrmWaitingForm(LancarRateio))
                    {
                        try
                        {
                            frm.ShowDialog(this);
                            if (sucesso)
                                MessageBox.Show("Rateio incluído com sucesso. Favor validar os lançamentos no TOTVS.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparDadosPedido_Click(object sender, EventArgs e)
        {
            this.txtIdMovReadOnly.Clear();
            this.txtNumeroMovReadOnly.Clear();
            this.txtFornecedorReadOnly.Clear();
            this.txtDataEmissaoReadOnly.Clear();
            this.txtValorReadOnly.Clear();
            this.txtNumPedido.Clear();
            this.txtNumPedido.ReadOnly = false;

        }

        private void dgvRateios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _rateios[e.RowIndex].Valor = decimal.Parse(this.dgvRateios.Rows[e.RowIndex].Cells["Valor"].Value.ToString());

            _valorTotalRateio = 0;
            _rateios.ForEach(x => _valorTotalRateio += x.Valor);

            this.AtualizaDataGridView();
            this.CalcularDiferenca();
        }

        private void txtValorFatura_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmRateioEMail_Load(object sender, EventArgs e)
        {
            DetalheFaturaImpressoras refer = new DetalheFaturaImpressoras();
            List<string> referencia = refer.GetReferencia();

            referencia = referencia.OrderByDescending(x => x.ToString()).ToList();

            referencia.Insert(0, "");
            this.cboReferencia.DataSource = referencia;
        }
    }
}
