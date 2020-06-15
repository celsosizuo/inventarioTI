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
    public partial class FrmTermoComputador : Form
    {
        private TermoComputadorRepository _termoRepository;
        private List<Usuario> _usuarios;
        private List<Gestor> _gestores;
        private List<TermoComputadorResponse> _termoComputadorResponse;
        private List<TermoComputador> _termoComputador;




        public FrmTermoComputador()
        {
            _termoRepository = new TermoComputadorRepository();
            _usuarios = new List<Usuario>();
            _gestores = new List<Gestor>();
            _termoComputadorResponse = new List<TermoComputadorResponse>();
            _termoComputador = new List<TermoComputador>();
            InitializeComponent();
        }

        public void CarregaDataGridView()
        {
            _termoComputador = _termoRepository.Get();
            _termoComputadorResponse = _termoComputador.Select(x => (TermoComputadorResponse)x).ToList();

            this.dgvTermoComputador.DataSource = _termoComputadorResponse;

        }

        public void AtualizaDataGridView()
        {
            this.dgvTermoComputador.DataSource = null;
            this.dgvTermoComputador.DataSource = _termoComputadorResponse;

            // Ocultando colunas desnecessárias
            //this.dgvTermoComputador.Columns["LinhaId"].Visible = false;
            //this.dgvTermoComputador.Columns["AparelhoId"].Visible = false;
            //this.dgvTermoComputador.Columns["CarregadorId"].Visible = false;
            //this.dgvTermoComputador.Columns["GestorId"].Visible = false;
            //this.dgvTermoComputador.Columns["FoneOuvido"].Visible = false;
            //this.dgvTermoComputador.Columns["LinkEntrega"].Visible = false;
            //this.dgvTermoComputador.Columns["LinkDevolucao"].Visible = false;
            //this.dgvTermoComputador.Columns["Usuario"].Visible = false;
        }




        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void FrmTermoComputador_Load(object sender, EventArgs e)
        {
            GestorRepository gestor = new GestorRepository();

            _gestores = gestor.Get();

            Gestor gest = new Gestor()
            {
                Id = 0,
                Nome = "",
                Status = 0,
                StatusDescricao = ""
            };
            _gestores.Insert(0, gest);

            this.cboGestores.DataSource = _gestores;
            this.cboGestores.ValueMember = "Id";
            this.cboGestores.DisplayMember = "Nome";

            this.CarregaDataGridView();
        }
    }
}
