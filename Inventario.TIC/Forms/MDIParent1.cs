using Inventario.TIC.Class;
using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void computadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerenciamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var text = "";
            //Screen.AllScreens.ToList().ForEach(a =>
            //{
            //    text += a.DeviceName;
            //});

            //MessageBox.Show(text.ToString());
        }

        private void licençasUtilizadasXNãoUtilizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Licencas.Nao.Utilizadas", parametros);
            // newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void listaDeRamaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Computadores", parametros);
            // newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void computadoresXLicençasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Computadores.Licencas", parametros);
            // newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void valoresContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrecoContaEMail newMDIChild = new FrmPrecoContaEMail();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void importarFaturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmImportarFaturaEMail newMDIChild = new FrmImportarFaturaEMail();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentoDeRateioNoTOTVSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRateioEMail newMDIChild = new FrmRateioEMail();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            string[] tipoBase = Properties.Settings.Default.conSQL.Split(';');

            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var version = fieVersionInfo.FileVersion;

            this.toolStripStatusLabel.Text = tipoBase[1].ToString().Replace("Initial Catalog", "Database") + " - Versão: " + version;

            this.Text = "ARTFIX TIC - Sistema de Gerenciamento - Versão " + version;
        }

        private void linhasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmLinha newMDIChild = new FrmLinha();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void aparelhosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmAparelho newMDIChild = new FrmAparelho();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void carregadoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCarregador newMDIChild = new FrmCarregador();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void usuáriosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmUsuarios newMDIChild = new FrmUsuarios();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void gestoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmGestores newMDIChild = new FrmGestores();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void celularesTermosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmTermoCelular newMDIChild = new FrmTermoCelular();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void importarFaturaToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FrmImportarFaturaTelefoniaFixa newMDIChild = new FrmImportarFaturaTelefoniaFixa();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentoDeRateioTOTVSToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmRateioTelefoniaFixa newMDIChild = new FrmRateioTelefoniaFixa();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentoDeRateioTOTVSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmRateioLinkInternet newMDIChild = new FrmRateioLinkInternet();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void importarFaturaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmImportarFaturaImpressoras newMDIChild = new FrmImportarFaturaImpressoras();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentoDeRateioTOTVSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmRateioImpressoras newMDIChild = new FrmRateioImpressoras();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void sincronizaçãoDaListaDeRamaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaRamais newMDIChild = new FrmListaRamais();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void importarFaturaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmImportarFatura newMDIChild = new FrmImportarFatura();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void excluirFaturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmExcluirFatura newMDIChild = new FrmExcluirFatura();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentosManuaisToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmDetalheFatura newMDIChild = new FrmDetalheFatura();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void lançamentoDeRateioDoTOTVSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmRateioTelefoniaMovel newMDIChild = new FrmRateioTelefoniaMovel();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void dispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDispositivoAlugado newMDIChild = new FrmDispositivoAlugado();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void lançamentoDeRateioTOTVSToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmRateioDispositivoAlugado newMDIChild = new FrmRateioDispositivoAlugado();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void associarLicençaAoDispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssociarLicencaNoDispositivoAlugado newMDIChild = new FrmAssociarLicencaNoDispositivoAlugado();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void notaFiscalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNotaFiscal newMDIChild = new FrmNotaFiscal();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }

        private void softwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSoftware newMDIChild = new FrmSoftware();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void licençasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLicencas newMDIChild = new FrmLicencas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cadastroDeComputadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //// int h = Screen.PrimaryScreen.Bounds.Height;
            FrmComputadores newMDIChild = new FrmComputadores();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);


            //if (w == 1366)
            //    newMDIChild.WindowState = FormWindowState.Maximized;
            //else
            //    newMDIChild.WindowState = FormWindowState.Normal;

        }

        private void associarLicençaDoComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssociarLicencaNoComputador newMDIChild = new FrmAssociarLicencaNoComputador();
            newMDIChild.MdiParent = this;

            //int w = Screen.PrimaryScreen.Bounds.Width;
            //if (w == 1366)
            //    newMDIChild.WindowState = FormWindowState.Maximized;
            //else
            //    newMDIChild.WindowState = FormWindowState.Normal;

            newMDIChild.Show();
            LayoutMdi(MdiLayout.TileVertical);
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void tiposDeDispositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoDispositivo newMDIChild = new FrmTipoDispositivo();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 newMDIChild = new AboutBox1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cadastroDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos newMDIChild = new FrmProdutos();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentoEstoque newMDIChild = new FrmMovimentoEstoque();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newMDIChild = new Form1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void gerenciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccess newMDIChild = new FrmAccess();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void termosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTermoComputador newMDIChild = new FrmTermoComputador();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void usuáriosDoRateioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ParametrosRelatorio> parametros = new List<ParametrosRelatorio>();
            FrmRelatorios newMDIChild = new FrmRelatorios("Rel.Usuarios.Rateio.Internet", parametros);
            // newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void pensoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRateioEMailPenso newMDIChild = new FrmRateioEMailPenso();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cadastroDeTipoDeImpressãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoImpressao newMDIChild = new FrmTipoImpressao();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cadastroDeReferênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReferencia newMDIChild = new FrmReferencia();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedor newMDIChild = new FrmFornecedor();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cadastroDeImpressorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImpressoras newMDIChild = new FrmImpressoras();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }
    }
}
