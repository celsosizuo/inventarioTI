using Inventario.TIC.Class;
using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void computadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            int w = Screen.PrimaryScreen.Bounds.Width;
            // int h = Screen.PrimaryScreen.Bounds.Height;
            FrmComputadores newMDIChild = new FrmComputadores();
            newMDIChild.MdiParent = this;

            if(w == 1366)
                newMDIChild.WindowState = FormWindowState.Maximized;
            else
                newMDIChild.WindowState = FormWindowState.Normal;

            newMDIChild.Show();
        }

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotaFiscal newMDIChild = new FrmNotaFiscal();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSoftware newMDIChild = new FrmSoftware();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void licençasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void licençasNFXSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void associarLicençaNoComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssociarLicencaNoComputador newMDIChild = new FrmAssociarLicencaNoComputador();
            newMDIChild.MdiParent = this;

            int w = Screen.PrimaryScreen.Bounds.Width;
            if (w == 1366)
                newMDIChild.WindowState = FormWindowState.Maximized;
            else
                newMDIChild.WindowState = FormWindowState.Normal;

            newMDIChild.Show();
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

        private void licençasNFXSoftwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void licençasNFXSoftwareToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLicencas newMDIChild = new FrmLicencas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
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

        private void linhasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeAparelhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cadastroDeCarregadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void celularesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeGestoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importarFaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linhasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmLinha newMDIChild = new FrmLinha();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void aparelhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAparelho newMDIChild = new FrmAparelho();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void carregadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCarregador newMDIChild = new FrmCarregador();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios newMDIChild = new FrmUsuarios();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void gestoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestores newMDIChild = new FrmGestores();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void celularesTermosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTermoCelular newMDIChild = new FrmTermoCelular();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void importarFaturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmImportarFatura newMDIChild = new FrmImportarFatura();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
