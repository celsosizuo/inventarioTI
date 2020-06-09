namespace Inventario.TIC
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.drpAtivoNovo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drpNotaFiscal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drpSoftware = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTextoACriptografar = new System.Windows.Forms.TextBox();
            this.txtChavePrivada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTextoCriptografado = new System.Windows.Forms.TextBox();
            this.txtTextoDecriptado = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGerarHash = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtHashGerado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGuidGerado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // drpAtivoNovo
            // 
            this.drpAtivoNovo.FormattingEnabled = true;
            this.drpAtivoNovo.Location = new System.Drawing.Point(15, 25);
            this.drpAtivoNovo.Name = "drpAtivoNovo";
            this.drpAtivoNovo.Size = new System.Drawing.Size(175, 21);
            this.drpAtivoNovo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ativo Novo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nota Fiscal";
            // 
            // drpNotaFiscal
            // 
            this.drpNotaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpNotaFiscal.FormattingEnabled = true;
            this.drpNotaFiscal.Location = new System.Drawing.Point(15, 88);
            this.drpNotaFiscal.Name = "drpNotaFiscal";
            this.drpNotaFiscal.Size = new System.Drawing.Size(175, 21);
            this.drpNotaFiscal.TabIndex = 2;
            this.drpNotaFiscal.SelectedIndexChanged += new System.EventHandler(this.drpNotaFiscal_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Software";
            // 
            // drpSoftware
            // 
            this.drpSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSoftware.FormattingEnabled = true;
            this.drpSoftware.Location = new System.Drawing.Point(196, 88);
            this.drpSoftware.Name = "drpSoftware";
            this.drpSoftware.Size = new System.Drawing.Size(684, 21);
            this.drpSoftware.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(131, 286);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(55, 13);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Resultado";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // txtTextoACriptografar
            // 
            this.txtTextoACriptografar.Location = new System.Drawing.Point(439, 146);
            this.txtTextoACriptografar.Name = "txtTextoACriptografar";
            this.txtTextoACriptografar.Size = new System.Drawing.Size(122, 20);
            this.txtTextoACriptografar.TabIndex = 9;
            // 
            // txtChavePrivada
            // 
            this.txtChavePrivada.Location = new System.Drawing.Point(439, 190);
            this.txtChavePrivada.Name = "txtChavePrivada";
            this.txtChavePrivada.Size = new System.Drawing.Size(145, 20);
            this.txtChavePrivada.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Texto Criptografado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Texto decriptado";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(439, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Criptografar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Texto a ser criptografado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(436, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Chave Privada da Criptografia";
            // 
            // txtTextoCriptografado
            // 
            this.txtTextoCriptografado.Location = new System.Drawing.Point(644, 146);
            this.txtTextoCriptografado.Name = "txtTextoCriptografado";
            this.txtTextoCriptografado.Size = new System.Drawing.Size(221, 20);
            this.txtTextoCriptografado.TabIndex = 16;
            // 
            // txtTextoDecriptado
            // 
            this.txtTextoDecriptado.Location = new System.Drawing.Point(644, 190);
            this.txtTextoDecriptado.Name = "txtTextoDecriptado";
            this.txtTextoDecriptado.Size = new System.Drawing.Size(221, 20);
            this.txtTextoDecriptado.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(567, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Decriptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Texto a gerar Hash";
            // 
            // txtGerarHash
            // 
            this.txtGerarHash.Location = new System.Drawing.Point(439, 330);
            this.txtGerarHash.Name = "txtGerarHash";
            this.txtGerarHash.Size = new System.Drawing.Size(145, 20);
            this.txtGerarHash.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(439, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Gerar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtHashGerado
            // 
            this.txtHashGerado.Location = new System.Drawing.Point(590, 330);
            this.txtHashGerado.Name = "txtHashGerado";
            this.txtHashGerado.Size = new System.Drawing.Size(221, 20);
            this.txtHashGerado.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(587, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Hash gerado";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(439, 385);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "Verificar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(567, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Hash gerado";
            // 
            // txtGuidGerado
            // 
            this.txtGuidGerado.Location = new System.Drawing.Point(817, 330);
            this.txtGuidGerado.Name = "txtGuidGerado";
            this.txtGuidGerado.Size = new System.Drawing.Size(145, 20);
            this.txtGuidGerado.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(814, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Guid Gerado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 502);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGuidGerado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtHashGerado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGerarHash);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtTextoDecriptado);
            this.Controls.Add(this.txtTextoCriptografado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChavePrivada);
            this.Controls.Add(this.txtTextoACriptografar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drpSoftware);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drpNotaFiscal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpAtivoNovo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox drpAtivoNovo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpNotaFiscal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpSoftware;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTextoACriptografar;
        private System.Windows.Forms.TextBox txtChavePrivada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTextoCriptografado;
        private System.Windows.Forms.TextBox txtTextoDecriptado;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGerarHash;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtHashGerado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGuidGerado;
        private System.Windows.Forms.Label label11;
    }
}

