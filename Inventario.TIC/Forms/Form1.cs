using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using Inventario.TIC.Class;

namespace Inventario.TIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.drpAtivoNovo.DataSource = this.GetComputadores();
                this.drpAtivoNovo.DisplayMember = "ATIVONOVO";
                this.drpAtivoNovo.ValueMember = "ID";

                this.drpNotaFiscal.DataSource = this.GetNotaFiscal();
                this.drpNotaFiscal.DisplayMember = "NUMNF";
                this.drpNotaFiscal.ValueMember = "NUMNF";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void drpNotaFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpNotaFiscal.SelectedIndex != -1)
                {
                    this.drpSoftware.DataSource = this.GetLicencas(this.drpNotaFiscal.SelectedValue.ToString());
                    this.drpSoftware.DisplayMember = "NOME";
                    this.drpSoftware.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string con = Properties.Settings.Default.conSQL;

                SqlCommand command = new SqlCommand
                {
                    Connection = new SqlConnection(con),
                    CommandType = CommandType.Text,
                    CommandText = @"INSERT COMPUTADORESLICENCAS VALUES (" + this.drpAtivoNovo.SelectedValue.ToString() + ", " + this.drpSoftware.SelectedValue.ToString() + ")",
                };

                command.Connection.Open();
                command.ExecuteScalar();

                MessageBox.Show("Inclusão efetuada com sucesso.", "", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetComputadores()
        {
            try
            {
                string con = Properties.Settings.Default.conSQL;

                SqlCommand command = new SqlCommand
                {
                    Connection = new SqlConnection(con),
                    CommandType = CommandType.Text,
                    CommandText = "SELECT ID, ATIVONOVO FROM COMPUTADORES ORDER BY ATIVONOVO",
                };

                command.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "";
                    dt.Rows.InsertAt(dr, 0);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetNotaFiscal()
        {
            try
            {
                string con = Properties.Settings.Default.conSQL;

                SqlCommand command = new SqlCommand
                {
                    Connection = new SqlConnection(con),
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT DISTINCT A.NUMNF
                                    FROM NOTAFISCAL A
                                    INNER JOIN LICENCAS B ON A.ID = B.NOTAFISCALID
                                    INNER JOIN SOFTWARE C ON C.ID = B.SOFTWAREID
                                    ORDER BY NUMNF",
                };

                command.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "";
                    dt.Rows.InsertAt(dr, 0);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetLicencas(string numNF)
        {
            try
            {
                string con = Properties.Settings.Default.conSQL;

                SqlCommand command = new SqlCommand
                {
                    Connection = new SqlConnection(con),
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT B.ID, C.NOME + ' [ ' + B.CHAVE + ' ]' AS NOME
                                    FROM NOTAFISCAL A
                                    INNER JOIN LICENCAS B ON A.ID = B.NOTAFISCALID
                                    INNER JOIN SOFTWARE C ON C.ID = B.SOFTWAREID
                                    WHERE A.NUMNF = '" + numNF + "'" +
                                    "ORDER BY NUMNF, C.NOME",
                };

                command.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = "";
                    dt.Rows.InsertAt(dr, 0);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
