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
    public partial class FrmCarregador : Form
    {
        private List<Carregador> _carregadores;
        private List<Carregador> _carregadoresOriginal;
        private string _colunaSelecionada;

        public FrmCarregador()
        {
            _carregadores = new List<Carregador>();
            InitializeComponent();
        }

        private void AtualizaDataGridView()
        {
            this.dgvCarregadores.DataSource = null;
            this.dgvCarregadores.DataSource = _carregadores;

            // Ocultando colunas desnecessárias
            this.dgvCarregadores.Columns["CascadeMode"].Visible = false;
        }

        private void FrmCarregador_Load(object sender, EventArgs e)
        {
            CarregadorRepository carregador = new CarregadorRepository();

            _carregadores = carregador.Get();
            _carregadoresOriginal = _carregadores;
            this.dgvCarregadores.DataSource = _carregadores;
            this.AtualizaDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregadorRepository carregadorRepository = new CarregadorRepository();
                Carregador carregador;

                if (this.txtId.Text == "")
                    carregador = new Carregador();
                else
                    carregador = _carregadores.Find(n => n.Id == int.Parse(this.txtId.Text));

                carregador.Id = this.txtId.Text == "" ? 0 : Convert.ToInt32(this.txtId.Text);
                carregador.Marca = this.txtMarca.Text;
                carregador.NumSerie = this.txtNumSerie.Text;
                carregador.Valor = decimal.Parse(this.txtValor.Text);

                if (carregador.EhValido())
                {
                    if (carregador.Id == 0)
                    {
                        string retorno = carregadorRepository.Add(carregador);
                        this.txtId.Text = retorno.ToString();
                        carregador.Id = int.Parse(retorno);
                        _carregadores.Add(carregador);
                        MessageBox.Show("Inclusão efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        carregadorRepository.Update(carregador);
                        MessageBox.Show("Atualização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.AtualizaDataGridView();
                }
                else
                {
                    string[] msgs = carregador.GetErros().Split(';');
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
                    CarregadorRepository carregadorRepository = new CarregadorRepository();
                    int id = this.txtId.Text == "" ? 0 : int.Parse(this.txtId.Text);
                    carregadorRepository.Delete(id);

                    _carregadores.Remove(_carregadores.Find(c => c.Id == id));
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
            this.txtMarca.Clear();
            this.txtNumSerie.Clear();
            this.txtValor.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.limparCampos();

        }

        private void dgvCarregadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtId.Text = _carregadores[e.RowIndex].Id.ToString();
                this.txtMarca.Text = _carregadores[e.RowIndex].Marca.ToString();
                this.txtNumSerie.Text = _carregadores[e.RowIndex].NumSerie == null ? "" : _carregadores[e.RowIndex].NumSerie.ToString();
                this.txtValor.Text = _carregadores[e.RowIndex].Valor.ToString();
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
                case "Marca":
                    _carregadores = _carregadoresOriginal.Where(c => c.Marca.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                case "NumSerie":
                    _carregadores = _carregadoresOriginal.Where(c => c.NumSerie.ToUpper().Contains(texto.ToUpper())).ToList();
                    break;
                default:
                    _carregadores = _carregadoresOriginal;
                    break;
            }
            this.AtualizaDataGridView();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (this.txtMarca.Text != "")
                this.Pesquisar("Marca", this.txtMarca.Text);
            else if (this.txtNumSerie.Text != "")
                this.Pesquisar("NumSerie", this.txtNumSerie.Text);
            else
                this.Pesquisar("", "");
        }

        private void dgvCarregadores_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var colunaSelecionada = this.dgvCarregadores.Columns[e.ColumnIndex].Name;

            switch (colunaSelecionada)
            {
                case "Id":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _carregadores = _carregadores.OrderBy(x => x.Id).ToList();
                    }
                    else
                    {
                        _carregadores = _carregadores.OrderByDescending(x => x.Id).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Marca":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _carregadores = _carregadores.OrderBy(x => x.Marca).ToList();
                    }
                    else
                    {
                        _carregadores = _carregadores.OrderByDescending(x => x.Marca).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "NumSerie":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _carregadores = _carregadores.OrderBy(x => x.NumSerie).ToList();
                    }
                    else
                    {
                        _carregadores = _carregadores.OrderByDescending(x => x.NumSerie).ToList();
                        this._colunaSelecionada = "";
                    }
                    break;
                case "Valor":
                    if (colunaSelecionada != this._colunaSelecionada)
                    {
                        this._colunaSelecionada = colunaSelecionada;
                        _carregadores = _carregadores.OrderBy(x => x.Valor).ToList();
                    }
                    else
                    {
                        _carregadores = _carregadores.OrderByDescending(x => x.Valor).ToList();
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
