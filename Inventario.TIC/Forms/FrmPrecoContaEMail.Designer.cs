namespace Inventario.TIC.Forms
{
    partial class FrmPrecoContaEMail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtValorUnitSemImposto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorUnitComImposto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCargaTributaria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtTipoConta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.dgvPrecoContaEMail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecoContaEMail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorUnitSemImposto
            // 
            this.txtValorUnitSemImposto.Location = new System.Drawing.Point(123, 72);
            this.txtValorUnitSemImposto.MaxLength = 200;
            this.txtValorUnitSemImposto.Name = "txtValorUnitSemImposto";
            this.txtValorUnitSemImposto.Size = new System.Drawing.Size(117, 20);
            this.txtValorUnitSemImposto.TabIndex = 62;
            this.txtValorUnitSemImposto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitSemImposto_KeyPress);
            this.txtValorUnitSemImposto.Leave += new System.EventHandler(this.txtValorUnitSemImposto_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Valor Unit. Sem Imposto";
            // 
            // txtValorUnitComImposto
            // 
            this.txtValorUnitComImposto.Location = new System.Drawing.Point(345, 72);
            this.txtValorUnitComImposto.MaxLength = 9;
            this.txtValorUnitComImposto.Name = "txtValorUnitComImposto";
            this.txtValorUnitComImposto.Size = new System.Drawing.Size(131, 20);
            this.txtValorUnitComImposto.TabIndex = 60;
            this.txtValorUnitComImposto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitComImposto_KeyPress);
            this.txtValorUnitComImposto.Leave += new System.EventHandler(this.txtValorUnitComImposto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Valor Unitário Com Imposto";
            // 
            // txtCargaTributaria
            // 
            this.txtCargaTributaria.Location = new System.Drawing.Point(246, 72);
            this.txtCargaTributaria.MaxLength = 9;
            this.txtCargaTributaria.Name = "txtCargaTributaria";
            this.txtCargaTributaria.Size = new System.Drawing.Size(93, 20);
            this.txtCargaTributaria.TabIndex = 58;
            this.txtCargaTributaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCargaTributaria_KeyPress);
            this.txtCargaTributaria.Leave += new System.EventHandler(this.txtCargaTributaria_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Carga Tributária";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(380, 108);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 56;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(218, 108);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 55;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(299, 108);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 54;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(137, 108);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 53;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtTipoConta
            // 
            this.txtTipoConta.Location = new System.Drawing.Point(172, 27);
            this.txtTipoConta.MaxLength = 200;
            this.txtTipoConta.Name = "txtTipoConta";
            this.txtTipoConta.Size = new System.Drawing.Size(304, 20);
            this.txtTipoConta.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tipo de Conta (*)";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(123, 27);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(43, 20);
            this.txtId.TabIndex = 50;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(120, 11);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 49;
            this.lblId.Text = "ID";
            // 
            // dgvPrecoContaEMail
            // 
            this.dgvPrecoContaEMail.AllowDrop = true;
            this.dgvPrecoContaEMail.AllowUserToAddRows = false;
            this.dgvPrecoContaEMail.AllowUserToDeleteRows = false;
            this.dgvPrecoContaEMail.AllowUserToOrderColumns = true;
            this.dgvPrecoContaEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrecoContaEMail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPrecoContaEMail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrecoContaEMail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPrecoContaEMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrecoContaEMail.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPrecoContaEMail.Location = new System.Drawing.Point(2, 137);
            this.dgvPrecoContaEMail.MultiSelect = false;
            this.dgvPrecoContaEMail.Name = "dgvPrecoContaEMail";
            this.dgvPrecoContaEMail.ReadOnly = true;
            this.dgvPrecoContaEMail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPrecoContaEMail.Size = new System.Drawing.Size(592, 227);
            this.dgvPrecoContaEMail.TabIndex = 48;
            this.dgvPrecoContaEMail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrecoContaEMail_CellDoubleClick);
            this.dgvPrecoContaEMail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrecoContaEMail_ColumnHeaderMouseClick);
            // 
            // FrmPrecoContaEMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 364);
            this.Controls.Add(this.txtValorUnitSemImposto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValorUnitComImposto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCargaTributaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtTipoConta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvPrecoContaEMail);
            this.MaximizeBox = false;
            this.Name = "FrmPrecoContaEMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valores das Contas de E-Mail";
            this.Load += new System.EventHandler(this.FrmPrecoContaEMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecoContaEMail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorUnitSemImposto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorUnitComImposto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCargaTributaria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtTipoConta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DataGridView dgvPrecoContaEMail;
    }
}