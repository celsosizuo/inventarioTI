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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaRamais));
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRamais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRamais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRamais.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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