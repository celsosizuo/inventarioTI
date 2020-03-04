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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 502);
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
    }
}

