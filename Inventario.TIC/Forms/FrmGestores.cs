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
    public partial class FrmGestores : Form
    {
        private List<Gestor> _gestores;
        private List<Gestor> _gestoresOriginal;
        private string _colunaSelecionada;

        public FrmGestores()
        {
            _gestores = new List<Gestor>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvGestores.DataSource = null;
            this.dgvGestores.DataSource = _gestores;

            // Ocultando colunas desnecessárias
            this.dgvGestores.Columns["CascadeMode"].Visible = false;
            this.dgvGestores.Columns["Status"].Visible = false;
        }

        private void FrmGestores_Load(object sender, EventArgs e)
        {
            GestorRepository gestor = new GestorRepository();

            _gestores = gestor.Get();
            _gestoresOriginal = _gestores;
            this.dgvGestores.DataSource = _gestores;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorRepository gestorRepository = new GestorRepository();
                Gestor gestor;

                if (this.txtId.Text == "")
                    gestor = new Gestor();
                else
                    gestor = _gestores.Find(n => n.Id == int.Parse(this.txtId.Text));

                gestor.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                gestor.Nome = this.txtNome.Text;
                gestor.Status = this.chkAtivo.Checked ? 0 : 1;
                gestor.StatusDescricao = this.chkAtivo.Checked ? "ATIVO" : "INATIVO";

                if (gestor.EhValido())
                {
                    if (gestor.Id == 0)
                    {
                        string retorno = gestorRepository.Add(gestor);
                        this.txtId.Text = retorno.ToString();
                        gestor.Id = int.Parse(retorno);
                        _gestores.Add(gestor);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        gestorRepository.Update(gestor);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = gestor.GetErros().Split(';');
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

        private void limparCampos()
        {
            this.txtId.Clear();
            this.txtNome.Clear();
            this.chkAtivo.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GestorRepository gestorRepository = new GestorRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    gestorRepository.Delete(id);

                    _gestores.Remove(_gestores.Find(c => c.Id == id));
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
        }

        private void dgvGestores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _gestores[e.RowIndex].Id.ToString();
                this.txtNome.Text = _gestores[e.RowIndex].Nome.ToString();
                this.chkAtivo.Checked = _gestores[e.RowIndex].Status.ToString() == "0" ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pesquisar(string coluna, string texto)
        {
            switch (coluna)
            {
                case "Nome":
                    _gestores = _gestoresOriginal.Where(c => c.Nome.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "Status":
                    _gestores = _gestoresOriginal.Where(c => c.Status.Equals(texto.ToUpper())).ToList();
                    break;
                default:
                    _gestores = _gestoresOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text != "")
                this.Pesquisar("Nome", this.txtNome.Text);
            else if (this.chkAtivo.Checked)
                this.Pesquisar("Status", this.chkAtivo.Checked == true ? "0" : "1");
            else
                this.Pesquisar("", "");
        }

        private void dgvGestores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvGestores.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _gestores = _gestores.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _gestores = _gestores.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Nome":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _gestores = _gestores.OrderBy(x => x.Nome).ToList();
                    }
                    else
                    {
                        _gestores = _gestores.OrderByDescending(x => x.Nome).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Status":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _gestores = _gestores.OrderBy(x => x.Status).ToList();
                    }
                    else
                    {
                        _gestores = _gestores.OrderByDescending(x => x.Status).ToList();
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
