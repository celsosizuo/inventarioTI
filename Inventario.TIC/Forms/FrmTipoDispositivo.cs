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
    public partial class FrmTipoDispositivo : Form
    {
        private List<TipoDispositivo> _tipoDispositivos;
        private List<TipoDispositivo> _tipoDispositivosOriginal;
        private string _colunaSelecionada;

        public FrmTipoDispositivo()
        {
            _tipoDispositivos = new List<TipoDispositivo>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvTipoDispositivos.DataSource = null;
            this.dgvTipoDispositivos.DataSource = _tipoDispositivos;

            // Ocultando colunas desnecessárias
            this.dgvTipoDispositivos.Columns["CascadeMode"].Visible = false;
        }

        private void FrmTipoDispositivo_Load(object sender, EventArgs e)
        {
            TipoDispositivoRepository TipoDispositivo = new TipoDispositivoRepository();

            _tipoDispositivos = TipoDispositivo.Get();
            _tipoDispositivosOriginal = _tipoDispositivos;
            this.dgvTipoDispositivos.DataSource = _tipoDispositivos;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoDispositivoRepository TipoDispositivoRepository = new TipoDispositivoRepository();
                TipoDispositivo TipoDispositivo;

                if (this.txtId.Text == "")
                    TipoDispositivo = new TipoDispositivo();
                else
                    TipoDispositivo = _tipoDispositivos.Find(n => n.Id == int.Parse(this.txtId.Text));

                TipoDispositivo.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                TipoDispositivo.Tipo = this.txtTipo.Text;

                if (TipoDispositivo.EhValido())
                {
                    if (TipoDispositivo.Id == 0)
                    {
                        string retorno = TipoDispositivoRepository.Add(TipoDispositivo);
                        this.txtId.Text = retorno.ToString();
                        TipoDispositivo.Id = int.Parse(retorno);
                        _tipoDispositivos.Add(TipoDispositivo);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        TipoDispositivoRepository.Update(TipoDispositivo);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = TipoDispositivo.GetErros().Split(';');
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
            this.txtTipo.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TipoDispositivoRepository TipoDispositivoRepository = new TipoDispositivoRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    TipoDispositivoRepository.Delete(id);

                    _tipoDispositivos.Remove(_tipoDispositivos.Find(c => c.Id == id));
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

        private void dgvTipoDispositivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _tipoDispositivos[e.RowIndex].Id.ToString();
                this.txtTipo.Text = _tipoDispositivos[e.RowIndex].Tipo.ToString();
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
                case "Tipo":
                    _tipoDispositivos = _tipoDispositivosOriginal.Where(c => c.Tipo.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _tipoDispositivos = _tipoDispositivosOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtTipo.Text != "")
                this.Pesquisar("Tipo", this.txtTipo.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvTipoDispositivos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvTipoDispositivos.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _tipoDispositivos = _tipoDispositivos.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _tipoDispositivos = _tipoDispositivos.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Tipo":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _tipoDispositivos = _tipoDispositivos.OrderBy(x => x.Tipo).ToList();
                    }
                    else
                    {
                        _tipoDispositivos = _tipoDispositivos.OrderByDescending(x => x.Tipo).ToList();
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
