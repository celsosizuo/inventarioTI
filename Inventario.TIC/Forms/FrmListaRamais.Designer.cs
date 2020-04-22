namespace Inventario.TIC.Forms
{
    partial class FrmListaRamais
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRamais = new System.Windows.Forms.DataGridView();
            this.btnListarAD = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRamais)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRamais
            // 
            this.dgvRamais.AllowDrop = true;
            this.dgvRamais.AllowUserToAddRows = false;
            this.dgvRamais.AllowUserToDeleteRows = false;
            this.dgvRamais.AllowUserToOrderColumns = true;
            this.dgvRamais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRamais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRamais.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRamais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRamais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRamais.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRamais.Location = new System.Drawing.Point(12, 62);
            this.dgvRamais.MultiSelect = false;
            this.dgvRamais.Name = "dgvRamais";
            this.dgvRamais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRamais.Size = new System.Drawing.Size(904, 563);
            this.dgvRamais.TabIndex = 31;
            // 
            // btnListarAD
            // 
            this.btnListarAD.Location = new System.Drawing.Point(281, 12);
            this.btnListarAD.Name = "btnListarAD";
            this.btnListarAD.Size = new System.Drawing.Size(165, 44);
            this.btnListarAD.TabIndex = 32;
            this.btnListarAD.Text = "Listar Usuários do AD";
            this.btnListarAD.UseVisualStyleBackColor = true;
            this.btnListarAD.Click += new System.EventHandler(this.btnListarAD_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(452, 12);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(165, 44);
            this.btnSincronizar.TabIndex = 33;
            this.btnSincronizar.Text = "Sincronizar com Lista de Ramais";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // FrmListaRamais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 637);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnListarAD);
            this.Controls.Add(this.dgvRamais);
            this.MaximizeBox = false;
            this.Name = "FrmListaRamais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronização da Lista de Ramais";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRamais)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRamais;
        private System.Windows.Forms.Button btnListarAD;
        private System.Windows.Forms.Button btnSincronizar;
    }
}