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
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;

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
            //try
            //{
            //    this.drpAtivoNovo.DataSource = this.GetComputadores();
            //    this.drpAtivoNovo.DisplayMember = "ATIVONOVO";
            //    this.drpAtivoNovo.ValueMember = "ID";

            //    this.drpNotaFiscal.DataSource = this.GetNotaFiscal();
            //    this.drpNotaFiscal.DisplayMember = "NUMNF";
            //    this.drpNotaFiscal.ValueMember = "NUMNF";

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTextoCriptografado.Text = StringCrypt.Encrypt(this.txtTextoACriptografar.Text, this.txtChavePrivada.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTextoDecriptado.Text = StringCrypt.Decrypt(this.txtTextoCriptografado.Text, this.txtChavePrivada.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtHashGerado.Text = Codifica(this.txtGerarHash.Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string senhaCodificada = Codifica(this.txtGerarHash.Text);

            if (Compara(txtGerarHash.Text, this.txtHashGerado.Text))
                this.label10.Text = "Senha OK";
            else
                this.label10.Text = "Senha incorreta";


        }

        public static string Codifica(string senha)
        {
            byte[] keyBytes = Encoding.ASCII.GetBytes(senha);
            string crypt = CryptSharp.Crypter.Blowfish.Crypt(keyBytes, CryptSharp.Crypter.Blowfish.GenerateSalt(6));
            return crypt;
        }

        public static bool Compara(string senha, string crypted)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(senha);
            return CryptSharp.Crypter.CheckPassword(crypted, crypted); // CryptSharp.Crypter.Blowfish.Crypt(bytes, crypted));
        }






        private void btnXML_Click(object sender, EventArgs e)
        {
            //StringBuilder xml = new StringBuilder();
            //XmlWriter writer = XmlWriter.Create(xml);

            //XNamespace ns1 = "http://example.com/ns1";
            //string prefix = "pf1";
            //string localName = "foo";
            //XElement el = new XElement(ns1 + localName, new XAttribute(XNamespace.Xmlns + prefix, ns1));
            //Console.WriteLine(el);


            ////// MONTANDO O XML
            ////writer.WriteStartElement("MovConcluirPedidoProcParams"); //ABRINDO A TAG MovConcluirPedidoProcParams
            ////writer.WriteAttributeString("z:Id", "i1");
            ////writer.WriteStartElement("TPRODUTO"); //ABRINDO A TAG TPRODUTO
            ////writer.WriteElementString("CODCOLPRD", "");
            ////writer.WriteElementString("CODCOLIGADA", "");
            ////writer.WriteElementString("IDPRD", "");
            ////writer.WriteEndElement(); //FECHANDO A TAG TPRODUTO
            ////writer.WriteEndElement(); //FECHANDO A TAG EstPrdBR

            ////FECHANDO O ARQUIVO XML
            //writer.Flush();
            //writer.Close();

            //string xmlString = xml.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Replace(@"\", "");

            //txtXML.Text = xmlString;


            string x = "55";

            XNamespace aw = "http://m.xyz.com/rss/";
            XDocument document = new XDocument(
                       new XDeclaration("1.0", "utf-8", "yes"), new XElement("MovConcluirPedidoProcParams", new XAttribute(XNamespace.Xmlns + "media", "http://m.xyz.com/rss/"), new XAttribute("version", "2.0"),

                           new XElement("channel",
                               new XAttribute("vendor", "ABC"),
                               new XAttribute("lastpublishdate", DateTime.Now.ToString("dd/MM/yyyy hh:mm"))),

                               new XElement("title", "Videos"),
                               new XElement(aw + "thumbnail", new XAttribute("width", x.Trim()), new XAttribute("height", x.Trim()))
                   )
            );

            this.txtXML.Text = document.ToString();

        }
    }






    public class Hash
    {
        private HashAlgorithm _algoritmo;

        public Hash(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }

        public string CriptografarSenha(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");

            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString() == senhaCadastrada;
        }
    }
}
