namespace Inventario.TIC.Forms
{
    partial class FrmRateioDispositivoAlugado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimparDadosPedido = new System.Windows.Forms.Button();
            this.txtValorReadOnly = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataEmissaoReadOnly = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFornecedorReadOnly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVerificarDadosPedido = new System.Windows.Forms.Button();
            this.txtNumeroMovReadOnly = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdMovReadOnly = new System.Windows.Forms.TextBox();
            this.txtNumPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.lblTotalPedido = new System.Windows.Forms.Label();
            this.txtSenhaTOTVS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuarioTOTVS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalRateado = new System.Windows.Forms.Label();
            this.btnLancarRateio = new System.Windows.Forms.Button();
            this.dgvRateios = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateios)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 146);
            this.groupBox1.TabIndex = 25;
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
            // btnVerificarDadosPedido
            // 
            this.btnVerificarDadosPedido.Location = new System.Drawing.Point(290, 21);
            this.btnVerificarDadosPedido.Name = "btnVerificarDadosPedido";
            this.btnVerificarDadosPedido.Size = new System.Drawing.Size(161, 24);
            this.btnVerificarDadosPedido.TabIndex = 1;
            this.btnVerificarDadosPedido.Text = "Verificar Dados do Pedido";
            this.btnVerificarDadosPedido.UseVisualStyleBackColor = true;
            this.btnVerificarDadosPedido.Click += new System.EventHandler(this.btnVerificarDadosPedido_Click);
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
            // txtNumPedido
            // 
            this.txtNumPedido.Location = new System.Drawing.Point(146, 24);
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.Size = new System.Drawing.Size(138, 20);
            this.txtNumPedido.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Número do Pedido TOTVS";
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenca.ForeColor = System.Drawing.Color.Red;
            this.lblDiferenca.Location = new System.Drawing.Point(8, 518);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(356, 20);
            this.lblDiferenca.TabIndex = 35;
            this.lblDiferenca.Text = "Diferença:";
            this.lblDiferenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalPedido
            // 
            this.lblTotalPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPedido.Location = new System.Drawing.Point(8, 492);
            this.lblTotalPedido.Name = "lblTotalPedido";
            this.lblTotalPedido.Size = new System.Drawing.Size(427, 20);
            this.lblTotalPedido.TabIndex = 34;
            this.lblTotalPedido.Text = "Valor Total Pedido: ";
            this.lblTotalPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSenhaTOTVS
            // 
            this.txtSenhaTOTVS.Location = new System.Drawing.Point(723, 488);
            this.txtSenhaTOTVS.Name = "txtSenhaTOTVS";
            this.txtSenhaTOTVS.PasswordChar = '*';
            this.txtSenhaTOTVS.Size = new System.Drawing.Size(138, 20);
            this.txtSenhaTOTVS.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Senha TOTVS";
            // 
            // txtUsuarioTOTVS
            // 
            this.txtUsuarioTOTVS.Location = new System.Drawing.Point(723, 460);
            this.txtUsuarioTOTVS.Name = "txtUsuarioTOTVS";
            this.txtUsuarioTOTVS.Size = new System.Drawing.Size(138, 20);
            this.txtUsuarioTOTVS.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Usuário TOTVS";
            // 
            // lblTotalRateado
            // 
            this.lblTotalRateado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRateado.Location = new System.Drawing.Point(8, 466);
            this.lblTotalRateado.Name = "lblTotalRateado";
            this.lblTotalRateado.Size = new System.Drawing.Size(356, 20);
            this.lblTotalRateado.TabIndex = 31;
            this.lblTotalRateado.Text = "Valor Total Rateado: ";
            this.lblTotalRateado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLancarRateio
            // 
            this.btnLancarRateio.Location = new System.Drawing.Point(638, 517);
            this.btnLancarRateio.Name = "btnLancarRateio";
            this.btnLancarRateio.Size = new System.Drawing.Size(223, 25);
            this.btnLancarRateio.TabIndex = 6;
            this.btnLancarRateio.Text = "Lançar Rateio no TOTVS";
            this.btnLancarRateio.UseVisualStyleBackColor = true;
            this.btnLancarRateio.Click += new System.EventHandler(this.btnLancarRateio_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRateios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRateios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRateios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRateios.Location = new System.Drawing.Point(0, 164);
            this.dgvRateios.MultiSelect = false;
            this.dgvRateios.Name = "dgvRateios";
            this.dgvRateios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRateios.Size = new System.Drawing.Size(867, 290);
            this.dgvRateios.TabIndex = 30;
            this.dgvRateios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRateios_CellEndEdit);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(606, 57);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(138, 46);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar Rateio";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FrmRateioDispositivoAlugado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 562);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.lblDiferenca);
            this.Controls.Add(this.lblTotalPedido);
            this.Controls.Add(this.txtSenhaTOTVS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsuarioTOTVS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalRateado);
            this.Controls.Add(this.btnLancarRateio);
            this.Controls.Add(this.dgvRateios);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmRateioDispositivoAlugado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançar Rateio Dispositivos Alugados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimparDadosPedido;
        private System.Windows.Forms.TextBox txtValorReadOnly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataEmissaoReadOnly;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFornecedorReadOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVerificarDadosPedido;
        private System.Windows.Forms.TextBox txtNumeroMovReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdMovReadOnly;
        private System.Windows.Forms.TextBox txtNumPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDiferenca;
        private System.Windows.Forms.Label lblTotalPedido;
        private System.Windows.Forms.TextBox txtSenhaTOTVS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuarioTOTVS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalRateado;
        private System.Windows.Forms.Button btnLancarRateio;
        private System.Windows.Forms.DataGridView dgvRateios;
        private System.Windows.Forms.Button btnListar;
    }
}