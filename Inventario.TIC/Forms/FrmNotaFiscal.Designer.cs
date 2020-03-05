namespace Inventario.TIC.Forms
{
    partial class FrmNotaFiscal
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
            this.dgvNotasFiscais = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasFiscais)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNotasFiscais
            // 
            this.dgvNotasFiscais.AllowDrop = true;
            this.dgvNotasFiscais.AllowUserToOrderColumns = true;
            this.dgvNotasFiscais.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotasFiscais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotasFiscais.Location = new System.Drawing.Point(-2, 236);
            this.dgvNotasFiscais.MultiSelect = false;
            this.dgvNotasFiscais.Name = "dgvNotasFiscais";
            this.dgvNotasFiscais.ReadOnly = true;
            this.dgvNotasFiscais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotasFiscais.Size = new System.Drawing.Size(825, 216);
            this.dgvNotasFiscais.TabIndex = 1;
            // 
            // FrmNotaFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 448);
            this.Controls.Add(this.dgvNotasFiscais);
            this.Name = "FrmNotaFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNotaFiscal";
            this.Load += new System.EventHandler(this.FrmNotaFiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasFiscais)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNotasFiscais;
    }
}