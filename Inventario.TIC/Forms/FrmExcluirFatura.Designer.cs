namespace Inventario.TIC.Forms
{
    partial class FrmExcluirFatura
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
            this.btnExcluir = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(415, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(115, 23);
            this.btnExcluir.TabIndex = 1;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 11);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(397, 154);
            this.checkedListBox1.TabIndex = 0;
            // 
            // FrmExcluirFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 172);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.checkedListBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExcluirFatura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir Fatura";
            this.Load += new System.EventHandler(this.FrmExcluirFatura_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}