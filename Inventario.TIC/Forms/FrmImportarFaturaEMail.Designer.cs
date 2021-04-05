namespace Inventario.TIC.Forms
{
    partial class FrmImportarFaturaEMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportarFaturaEMail));
            this.lblTempo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQtdeRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.MaskedTextBox();
            this.rdoI3SI = new System.Windows.Forms.RadioButton();
            this.rdoPenso = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(229, 126);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(23, 20);
            this.lblTempo.TabIndex = 15;
            this.lblTempo.Text = "xx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tempo de importação:";
            // 
            // lblQtdeRegistros
            // 
            this.lblQtdeRegistros.AutoSize = true;
            this.lblQtdeRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeRegistros.Location = new System.Drawing.Point(338, 106);
            this.lblQtdeRegistros.Name = "lblQtdeRegistros";
            this.lblQtdeRegistros.Size = new System.Drawing.Size(23, 20);
            this.lblQtdeRegistros.TabIndex = 13;
            this.lblQtdeRegistros.Text = "xx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quantidade de Registros Importados:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selecionar Arquivo";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(403, 32);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 10;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(373, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(24, 20);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "...";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(42, 35);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(325, 20);
            this.txtArquivo.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Referência";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(42, 74);
            this.txtReferencia.Mask = "00/0000";
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(81, 20);
            this.txtReferencia.TabIndex = 18;
            this.txtReferencia.ValidatingType = typeof(System.DateTime);
            // 
            // rdoI3SI
            // 
            this.rdoI3SI.AutoSize = true;
            this.rdoI3SI.Location = new System.Drawing.Point(144, 74);
            this.rdoI3SI.Name = "rdoI3SI";
            this.rdoI3SI.Size = new System.Drawing.Size(44, 17);
            this.rdoI3SI.TabIndex = 19;
            this.rdoI3SI.TabStop = true;
            this.rdoI3SI.Text = "I3SI";
            this.rdoI3SI.UseVisualStyleBackColor = true;
            // 
            // rdoPenso
            // 
            this.rdoPenso.AutoSize = true;
            this.rdoPenso.Location = new System.Drawing.Point(233, 75);
            this.rdoPenso.Name = "rdoPenso";
            this.rdoPenso.Size = new System.Drawing.Size(112, 17);
            this.rdoPenso.TabIndex = 20;
            this.rdoPenso.TabStop = true;
            this.rdoPenso.Text = "Penso Mail Zimbra";
            this.rdoPenso.UseVisualStyleBackColor = true;
            // 
            // FrmImportarFaturaEMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 166);
            this.Controls.Add(this.rdoPenso);
            this.Controls.Add(this.rdoI3SI);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblQtdeRegistros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtArquivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportarFaturaEMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Fatura E-Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQtdeRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtReferencia;
        private System.Windows.Forms.RadioButton rdoI3SI;
        private System.Windows.Forms.RadioButton rdoPenso;
    }
}