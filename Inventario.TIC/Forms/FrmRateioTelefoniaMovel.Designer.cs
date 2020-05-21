namespace Inventario.TIC.Forms
{
    partial class FrmRateioTelefoniaMovel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRateioTelefoniaMovel));
            this.label1 = new System.Windows.Forms.Label();
            this.cboReferencia = new System.Windows.Forms.ComboBox();
            this.dgvRateios = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnLancarRateio = new System.Windows.Forms.Button();
            this.txtNumPedido = new System.Windows.Forms.TextBox();
            this.lblTotalRateado = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnVerificarDadosPedido = new System.Windows.Forms.Button();
            this.txtUsuarioTOTVS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenhaTOTVS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimparDadosPedido = new System.Windows.Forms.Button();
            this.txtValorReadOnly = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataEmissaoReadOnly = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFornecedorReadOnly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumeroMovReadOnly = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdMovReadOnly = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPedido = new System.Windows.Forms.Label();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Referência";
            // 
            // cboReferencia
            // 
            this.cboReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReferencia.FormattingEnabled = true;
            this.cboReferencia.Location = new System.Drawing.Point(99, 21);
            this.cboReferencia.Name = "cboReferencia";
            this.cboReferencia.Size = new System.Drawing.Size(138, 21);
            this.cboReferencia.TabIndex = 0;
            // 
            // dgvRateios
            // 
            this.dgvRateios.AllowDrop = true;
            this.dgvRateios.AllowUserToAddRows = false;
            this.dgvRateios.AllowUserToDeleteRows = false;
            this.dgvRateios.AllowUserToOrderColumns = true;
            this.dgvRateios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRateios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRateios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRateios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRateios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRateios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRateios.Location = new System.Drawing.Point(7, 158);
            this.dgvRateios.MultiSelect = false;
            this.dgvRateios.Name = "dgvRateios";
            this.dgvRateios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRateios.Size = new System.Drawing.Size(854, 290);
            this.dgvRateios.TabIndex = 11;
            this.dgvRateios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRateios_CellEndEdit);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Número do Pedido TOTVS";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(243, 19);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(123, 23);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnLancarRateio
            // 
            this.btnLancarRateio.Location = new System.Drawing.Point(633, 511);
            this.btnLancarRateio.Name = "btnLancarRateio";
            this.btnLancarRateio.Size = new System.Drawing.Size(223, 25);
            this.btnLancarRateio.TabIndex = 6;
            this.btnLancarRateio.Text = "Lançar Rateio no TOTVS";
            this.btnLancarRateio.UseVisualStyleBackColor = true;
            this.btnLancarRateio.Click += new System.EventHandler(this.btnLancarRateio_Click);
            // 
            // txtNumPedido
            // 
            this.txtNumPedido.Location = new System.Drawing.Point(146, 24);
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.Size = new System.Drawing.Size(138, 20);
            this.txtNumPedido.TabIndex = 2;
            // 
            // lblTotalRateado
            // 
            this.lblTotalRateado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRateado.Location = new System.Drawing.Point(3, 460);
            this.lblTotalRateado.Name = "lblTotalRateado";
            this.lblTotalRateado.Size = new System.Drawing.Size(356, 20);
            this.lblTotalRateado.TabIndex = 18;
            this.lblTotalRateado.Text = "Valor Total Rateado: ";
            this.lblTotalRateado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(111, 75);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(161, 23);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "Limpar Tudo";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnVerificarDadosPedido
            // 
            this.btnVerificarDadosPedido.Location = new System.Drawing.Point(290, 21);
            this.btnVerificarDadosPedido.Name = "btnVerificarDadosPedido";
            this.btnVerificarDadosPedido.Size = new System.Drawing.Size(161, 24);
            this.btnVerificarDadosPedido.TabIndex = 3;
            this.btnVerificarDadosPedido.Text = "Verificar Dados do Pedido";
            this.btnVerificarDadosPedido.UseVisualStyleBackColor = true;
            this.btnVerificarDadosPedido.Click += new System.EventHandler(this.btnVerificarDadosPedido_Click);
            // 
            // txtUsuarioTOTVS
            // 
            this.txtUsuarioTOTVS.Location = new System.Drawing.Point(718, 454);
            this.txtUsuarioTOTVS.Name = "txtUsuarioTOTVS";
            this.txtUsuarioTOTVS.Size = new System.Drawing.Size(138, 20);
            this.txtUsuarioTOTVS.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Usuário TOTVS";
            // 
            // txtSenhaTOTVS
            // 
            this.txtSenhaTOTVS.Location = new System.Drawing.Point(718, 482);
            this.txtSenhaTOTVS.Name = "txtSenhaTOTVS";
            this.txtSenhaTOTVS.PasswordChar = '*';
            this.txtSenhaTOTVS.Size = new System.Drawing.Size(138, 20);
            this.txtSenhaTOTVS.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Senha TOTVS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimparDadosPedido);
            this.groupBox1.Controls.Add(this.txtValorReadOnly);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDataEmissaoReadOnly);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFornecedorReadOnly);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnVerificarDadosPedido);
            this.groupBox1.Controls.Add(this.txtNumeroMovReadOnly);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIdMovReadOnly);
            this.groupBox1.Controls.Add(this.txtNumPedido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(391, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 146);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar Pedido de Compra";
            // 
            // btnLimparDadosPedido
            // 
            this.btnLimparDadosPedido.Location = new System.Drawing.Point(370, 115);
            this.btnLimparDadosPedido.Name = "btnLimparDadosPedido";
            this.btnLimparDadosPedido.Size = new System.Drawing.Size(81, 23);
            this.btnLimparDadosPedido.TabIndex = 40;
            this.btnLimparDadosPedido.Text = "Limpar";
            this.btnLimparDadosPedido.UseVisualStyleBackColor = true;
            this.btnLimparDadosPedido.Click += new System.EventHandler(this.btnLimparDadosPedido_Click);
            // 
            // txtValorReadOnly
            // 
            this.txtValorReadOnly.Location = new System.Drawing.Point(258, 84);
            this.txtValorReadOnly.Name = "txtValorReadOnly";
            this.txtValorReadOnly.ReadOnly = true;
            this.txtValorReadOnly.Size = new System.Drawing.Size(193, 20);
            this.txtValorReadOnly.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Valor";
            // 
            // txtDataEmissaoReadOnly
            // 
            this.txtDataEmissaoReadOnly.Location = new System.Drawing.Point(99, 115);
            this.txtDataEmissaoReadOnly.Name = "txtDataEmissaoReadOnly";
            this.txtDataEmissaoReadOnly.ReadOnly = true;
            this.txtDataEmissaoReadOnly.Size = new System.Drawing.Size(86, 20);
            this.txtDataEmissaoReadOnly.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Data Emissão";
            // 
            // txtFornecedorReadOnly
            // 
            this.txtFornecedorReadOnly.Location = new System.Drawing.Point(258, 57);
            this.txtFornecedorReadOnly.Name = "txtFornecedorReadOnly";
            this.txtFornecedorReadOnly.ReadOnly = true;
            this.txtFornecedorReadOnly.Size = new System.Drawing.Size(193, 20);
            this.txtFornecedorReadOnly.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Fornecedor";
            // 
            // txtNumeroMovReadOnly
            // 
            this.txtNumeroMovReadOnly.Location = new System.Drawing.Point(99, 86);
            this.txtNumeroMovReadOnly.Name = "txtNumeroMovReadOnly";
            this.txtNumeroMovReadOnly.ReadOnly = true;
            this.txtNumeroMovReadOnly.Size = new System.Drawing.Size(86, 20);
            this.txtNumeroMovReadOnly.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Num. Movimento";
            // 
            // txtIdMovReadOnly
            // 
            this.txtIdMovReadOnly.Location = new System.Drawing.Point(99, 59);
            this.txtIdMovReadOnly.Name = "txtIdMovReadOnly";
            this.txtIdMovReadOnly.ReadOnly = true;
            this.txtIdMovReadOnly.Size = new System.Drawing.Size(86, 20);
            this.txtIdMovReadOnly.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Id Movimento";
            // 
            // lblTotalPedido
            // 
            this.lblTotalPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPedido.Location = new System.Drawing.Point(3, 486);
            this.lblTotalPedido.Name = "lblTotalPedido";
            this.lblTotalPedido.Size = new System.Drawing.Size(356, 20);
            this.lblTotalPedido.TabIndex = 25;
            this.lblTotalPedido.Text = "Valor Total Pedido: ";
            this.lblTotalPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenca.ForeColor = System.Drawing.Color.Red;
            this.lblDiferenca.Location = new System.Drawing.Point(3, 512);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(356, 20);
            this.lblDiferenca.TabIndex = 26;
            this.lblDiferenca.Text = "Diferença:";
            this.lblDiferenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnListar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboReferencia);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 57);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar Referência";
            // 
            // FrmRateioTelefoniaMovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 545);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblDiferenca);
            this.Controls.Add(this.lblTotalPedido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSenhaTOTVS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsuarioTOTVS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblTotalRateado);
            this.Controls.Add(this.btnLancarRateio);
            this.Controls.Add(this.dgvRateios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRateioTelefoniaMovel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançar Rateio Telefonia Móvel";
            this.Load += new System.EventHandler(this.FrmRateioTelefoniaMovel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboReferencia;
        private System.Windows.Forms.DataGridView dgvRateios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnLancarRateio;
        private System.Windows.Forms.TextBox txtNumPedido;
        private System.Windows.Forms.Label lblTotalRateado;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnVerificarDadosPedido;
        private System.Windows.Forms.TextBox txtUsuarioTOTVS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenhaTOTVS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtValorReadOnly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataEmissaoReadOnly;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFornecedorReadOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumeroMovReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdMovReadOnly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimparDadosPedido;
        private System.Windows.Forms.Label lblTotalPedido;
        private System.Windows.Forms.Label lblDiferenca;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}