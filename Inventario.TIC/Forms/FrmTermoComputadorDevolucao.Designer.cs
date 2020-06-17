namespace Inventario.TIC.Forms
{
    partial class FrmTermoComputadorDevolucao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAviso = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTermoComputadorId = new System.Windows.Forms.TextBox();
            this.txtDataDevolucao = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(39, 13);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(33, 13);
            this.lblAviso.TabIndex = 101;
            this.lblAviso.Text = "Aviso";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(222, 214);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(272, 57);
            this.txtMotivo.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Motivo";
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(500, 231);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 98;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(39, 199);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 96;
            this.label25.Text = "Num. Termo";
            // 
            // txtTermoComputadorId
            // 
            this.txtTermoComputadorId.Location = new System.Drawing.Point(42, 215);
            this.txtTermoComputadorId.MaxLength = 9;
            this.txtTermoComputadorId.Name = "txtTermoComputadorId";
            this.txtTermoComputadorId.ReadOnly = true;
            this.txtTermoComputadorId.Size = new System.Drawing.Size(62, 20);
            this.txtTermoComputadorId.TabIndex = 97;
            // 
            // txtDataDevolucao
            // 
            this.txtDataDevolucao.Location = new System.Drawing.Point(116, 215);
            this.txtDataDevolucao.Mask = "00/00/0000";
            this.txtDataDevolucao.Name = "txtDataDevolucao";
            this.txtDataDevolucao.Size = new System.Drawing.Size(86, 20);
            this.txtDataDevolucao.TabIndex = 94;
            this.txtDataDevolucao.ValidatingType = typeof(System.DateTime);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(113, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 95;
            this.label20.Text = "Data de Devolução";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(40, 29);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(648, 164);
            this.dgvUsuarios.TabIndex = 93;
            // 
            // FrmTermoComputadorDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 278);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtTermoComputadorId);
            this.Controls.Add(this.txtDataDevolucao);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dgvUsuarios);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTermoComputadorDevolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução";
            this.Load += new System.EventHandler(this.FrmTermoComputadorDevolucao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTermoComputadorId;
        private System.Windows.Forms.MaskedTextBox txtDataDevolucao;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}