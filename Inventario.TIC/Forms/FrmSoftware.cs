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
    public partial class FrmSoftware : Form
    {
        private List<Software> _softwares;
        private List<Software> _softwaresOriginal;
        private string _colunaSelecionada;

        public FrmSoftware()
        {
            _softwares = new List<Software>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvSoftwares.DataSource = null;
            this.dgvSoftwares.DataSource = _softwares;

            // Ocultando colunas desnecessárias
            this.dgvSoftwares.Columns["CascadeMode"].Visible = false;
        }

        private void FrmSoftware_Load(object sender, EventArgs e)
        {
            SoftwareRepository soft = new SoftwareRepository();

            _softwares = soft.Get();
            _softwaresOriginal = _softwares;
            this.dgvSoftwares.DataSource = _softwares;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SoftwareRepository softRepository = new SoftwareRepository();
                Software soft;

                if (this.txtId.Text == "")
                    soft = new Software();
                else
                    soft = _softwares.Find(n => n.Id == int.Parse(this.txtId.Text));

                soft.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                soft.Nome = this.txtNome.Text;

                if (soft.EhValido())
                {
                    if (soft.Id == 0)
                    {
                        string retorno = softRepository.Add(soft);
                        this.txtId.Text = retorno.ToString();
                        soft.Id = int.Parse(retorno);
                        _softwares.Add(soft);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        softRepository.Update(soft);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = soft.GetErros().Split(';');
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
                    SoftwareRepository softRepository = new SoftwareRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    softRepository.Delete(id);

                    _softwares.Remove(_softwares.Find(c => c.Id == id));
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
            this.txtNome.Clear();
        }


        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvSoftwares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _softwares[e.RowIndex].Id.ToString();
                this.txtNome.Text = _softwares[e.RowIndex].Nome.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text != "")
                this.Pesquisar("Nome", this.txtNome.Text);
            else
                this.Pesquisar("", "");
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Nome":
                    _softwares = _softwaresOriginal.Where(c => c.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _softwares = _softwaresOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void dgvSoftwares_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvSoftwares.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _softwares = _softwares.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _softwares = _softwares.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Nome":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _softwares = _softwares.OrderBy(x => x.Nome).ToList();
                    }
                    else
                    {
                        _softwares = _softwares.OrderByDescending(x => x.Nome).ToList();
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
