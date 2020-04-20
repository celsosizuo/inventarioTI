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
    public partial class FrmWaitingForm : Form
    {
        public Action Worker { get; set; }
        int segundos = 0;
        int minutos = 0;

        public FrmWaitingForm(Action worker)
        {
            InitializeComponent();
            timer1.Enabled = true;

            if (worker == null)
                throw new ArgumentNullException();

            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { Module1.tempoImportacao = this.label2.Text; this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;

            if(segundos >= 60)
            {
                minutos++;
                segundos = 0;
            }

            this.label2.Text = String.Format("{0:00}", minutos) + ":" + String.Format("{0:00}", segundos);
        }
    }
}
