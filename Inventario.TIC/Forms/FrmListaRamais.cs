using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC.Forms
{
    public partial class FrmListaRamais : Form
    {
        public FrmListaRamais()
        {
            InitializeComponent();
        }

        private DataTable GetUsuariosAD()
        {
            string LDAP = "LDAP://192.168.20.217/DC=artfix,DC=local";
            var deRoot = new DirectoryEntry(LDAP);
            var deSrch = new DirectorySearcher(deRoot, ("&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)"));
            var table = new DataTable("Resultados");

            table.Columns.Add("Nome");
            // table.Columns.Add("Usuario")
            table.Columns.Add("Email");
            table.Columns.Add("Celular");
            table.Columns.Add("Ramal");
            table.Columns.Add("Departamento");
            table.Columns.Add("Centro de Custo");
            table.Columns.Add("userPrincipalName");


            deSrch.Filter = "(department=*)";
            deSrch.PropertiesToLoad.Add("DisplayName");
            deSrch.PropertiesToLoad.Add("userPrincipalName");
            deSrch.PropertiesToLoad.Add("sAMAccountName");
            deSrch.PropertiesToLoad.Add("mail");
            deSrch.PropertiesToLoad.Add("mobile");
            deSrch.PropertiesToLoad.Add("ipPhone");
            deSrch.PropertiesToLoad.Add("department");
            deSrch.PropertiesToLoad.Add("company");
            deSrch.PropertiesToLoad.Add("userPrincipalName");
            deSrch.Sort.PropertyName = "sAMAccountName";

            foreach (SearchResult oRes in deSrch.FindAll())
            {
                DataRow row;
                row = table.NewRow();

                row["Nome"] = oRes.Properties["DisplayName"][0].ToString();

                if (oRes.Properties.Contains("mail"))
                    row["Email"] = oRes.Properties["mail"][0].ToString();

                if (oRes.Properties.Contains("mobile"))
                    row["Celular"] = oRes.Properties["mobile"][0].ToString();

                if (oRes.Properties.Contains("ipPhone"))
                    row["Ramal"] = oRes.Properties["ipPhone"][0].ToString();

                if (oRes.Properties.Contains("department"))
                    row["Departamento"] = oRes.Properties["department"][0].ToString();

                if (oRes.Properties.Contains("company"))
                    row["Centro de Custo"] = oRes.Properties["company"][0].ToString();

                if (oRes.Properties.Contains("userPrincipalName"))
                    row["userPrincipalName"] = oRes.Properties["userPrincipalName"][0].ToString();

                table.Rows.Add(row);
            }
            return table;
        }

        private void btnListarAD_Click(object sender, EventArgs e)
        {
            this.dgvRamais.DataSource = GetUsuariosAD();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.GetUsuariosAD();

                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PREZLISTARAMAL",
                };

                command.Connection.Open();
                command.ExecuteScalar();


                dt.AsEnumerable().ToList().ForEach(x =>
                {
                    SqlCommand command1 = new SqlCommand()
                    {
                        Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PRIZLISTARAMAL",
                    };
                    command1.Parameters.AddWithValue("@Nome", x["Nome"].ToString());
                    command1.Parameters.AddWithValue("@EMail", x["EMail"].ToString());
                    command1.Parameters.AddWithValue("@Celular", x["Celular"].ToString());
                    command1.Parameters.AddWithValue("@Ramal", x["Ramal"].ToString());
                    command1.Parameters.AddWithValue("@Departamento", x["Departamento"].ToString());
                    command1.Parameters.AddWithValue("@Chapa", "");

                    command1.Connection.Open();
                    command1.ExecuteScalar();
                });


                MessageBox.Show("Sincronização efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
