namespace Inventario.TIC.Forms
{
    partial class FrmAssociarLicencaNoComputador
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotaFiscalIdReadOnly = new System.Windows.Forms.TextBox();
            this.txtLinkReadOnly = new System.Windows.Forms.TextBox();
            this.txtEmpresaReadOnly = new System.Windows.Forms.TextBox();
            this.txtDataReadOnly = new System.Windows.Forms.TextBox();
            this.txtFornecedorReadOnly = new System.Windows.Forms.TextBox();
            this.txtNumNFReadOnly = new System.Windows.Forms.TextBox();
            this.btnNovaPesquisa = new System.Windows.Forms.Button();
            this.txtNumNF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNovaPesquisaComputador = new System.Windows.Forms.Button();
            this.txtDepartamentoReadOnly = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUsuarioReadOnly = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAtivoAntigoReadOnly = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAtivoNovoReadOnly = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboComputador = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboLicenca = new System.Windows.Forms.ComboBox();
            this.dgvLicencasAssociadas = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencasAssociadas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotaFiscalIdReadOnly);
            this.groupBox1.Controls.Add(this.txtLinkReadOnly);
            this.groupBox1.Controls.Add(this.txtEmpresaReadOnly);
            this.groupBox1.Controls.Add(this.txtDataReadOnly);
            this.groupBox1.Controls.Add(this.txtFornecedorReadOnly);
            this.groupBox1.Controls.Add(this.txtNumNFReadOnly);
            this.groupBox1.Controls.Add(this.btnNovaPesquisa);
            this.groupBox1.Controls.Add(this.txtNumNF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(543, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 198);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar Nota Fiscal";
            // 
            // txtNotaFiscalIdReadOnly
            // 
            this.txtNotaFiscalIdReadOnly.Location = new System.Drawing.Point(244, 172);
            this.txtNotaFiscalIdReadOnly.MaxLength = 9;
            this.txtNotaFiscalIdReadOnly.Name = "txtNotaFiscalIdReadOnly";
            this.txtNotaFiscalIdReadOnly.ReadOnly = true;
            this.txtNotaFiscalIdReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtNotaFiscalIdReadOnly.TabIndex = 46;
            // 
            // txtLinkReadOnly
            // 
            this.txtLinkReadOnly.Location = new System.Drawing.Point(244, 121);
            this.txtLinkReadOnly.MaxLength = 9;
            this.txtLinkReadOnly.Multiline = true;
            this.txtLinkReadOnly.Name = "txtLinkReadOnly";
            this.txtLinkReadOnly.ReadOnly = true;
            this.txtLinkReadOnly.Size = new System.Drawing.Size(300, 45);
            this.txtLinkReadOnly.TabIndex = 45;
            // 
            // txtEmpresaReadOnly
            // 
            this.txtEmpresaReadOnly.Location = new System.Drawing.Point(244, 94);
            this.txtEmpresaReadOnly.MaxLength = 9;
            this.txtEmpresaReadOnly.Name = "txtEmpresaReadOnly";
            this.txtEmpresaReadOnly.ReadOnly = true;
            this.txtEmpresaReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtEmpresaReadOnly.TabIndex = 44;
            // 
            // txtDataReadOnly
            // 
            this.txtDataReadOnly.Location = new System.Drawing.Point(244, 68);
            this.txtDataReadOnly.MaxLength = 9;
            this.txtDataReadOnly.Name = "txtDataReadOnly";
            this.txtDataReadOnly.ReadOnly = true;
            this.txtDataReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtDataReadOnly.TabIndex = 43;
            // 
            // txtFornecedorReadOnly
            // 
            this.txtFornecedorReadOnly.Location = new System.Drawing.Point(244, 42);
            this.txtFornecedorReadOnly.MaxLength = 9;
            this.txtFornecedorReadOnly.Name = "txtFornecedorReadOnly";
            this.txtFornecedorReadOnly.ReadOnly = true;
            this.txtFornecedorReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtFornecedorReadOnly.TabIndex = 42;
            // 
            // txtNumNFReadOnly
            // 
            this.txtNumNFReadOnly.Location = new System.Drawing.Point(244, 16);
            this.txtNumNFReadOnly.MaxLength = 9;
            this.txtNumNFReadOnly.Name = "txtNumNFReadOnly";
            this.txtNumNFReadOnly.ReadOnly = true;
            this.txtNumNFReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtNumNFReadOnly.TabIndex = 41;
            // 
            // btnNovaPesquisa
            // 
            this.btnNovaPesquisa.Location = new System.Drawing.Point(16, 62);
            this.btnNovaPesquisa.Name = "btnNovaPesquisa";
            this.btnNovaPesquisa.Size = new System.Drawing.Size(86, 35);
            this.btnNovaPesquisa.TabIndex = 40;
            this.btnNovaPesquisa.Text = "Nova Pesquisa";
            this.btnNovaPesquisa.UseVisualStyleBackColor = true;
            this.btnNovaPesquisa.Click += new System.EventHandler(this.btnNovaPesquisa_Click);
            // 
            // txtNumNF
            // 
            this.txtNumNF.Location = new System.Drawing.Point(16, 36);
            this.txtNumNF.MaxLength = 9;
            this.txtNumNF.Name = "txtNumNF";
            this.txtNumNF.Size = new System.Drawing.Size(86, 20);
            this.txtNumNF.TabIndex = 39;
            this.txtNumNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumNF_KeyPress);
            this.txtNumNF.Leave += new System.EventHandler(this.txtNumNF_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Número da NF (*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(216, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Id:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(203, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Link:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(179, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Empresa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fornecedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número da NF:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNovaPesquisaComputador);
            this.groupBox2.Controls.Add(this.txtDepartamentoReadOnly);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtUsuarioReadOnly);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtAtivoAntigoReadOnly);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtAtivoNovoReadOnly);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboComputador);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 198);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar Computador";
            // 
            // btnNovaPesquisaComputador
            // 
            this.btnNovaPesquisaComputador.Location = new System.Drawing.Point(392, 39);
            this.btnNovaPesquisaComputador.Name = "btnNovaPesquisaComputador";
            this.btnNovaPesquisaComputador.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaComputador.TabIndex = 50;
            this.btnNovaPesquisaComputador.Text = "Nova Pesquisa";
            this.btnNovaPesquisaComputador.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaComputador.Click += new System.EventHandler(this.btnNovaPesquisaComputador_Click);
            // 
            // txtDepartamentoReadOnly
            // 
            this.txtDepartamentoReadOnly.Location = new System.Drawing.Point(140, 161);
            this.txtDepartamentoReadOnly.MaxLength = 9;
            this.txtDepartamentoReadOnly.Name = "txtDepartamentoReadOnly";
            this.txtDepartamentoReadOnly.ReadOnly = true;
            this.txtDepartamentoReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtDepartamentoReadOnly.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(43, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Departamento:";
            // 
            // txtUsuarioReadOnly
            // 
            this.txtUsuarioReadOnly.Location = new System.Drawing.Point(140, 135);
            this.txtUsuarioReadOnly.MaxLength = 9;
            this.txtUsuarioReadOnly.Name = "txtUsuarioReadOnly";
            this.txtUsuarioReadOnly.ReadOnly = true;
            this.txtUsuarioReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtUsuarioReadOnly.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(80, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Usuário:";
            // 
            // txtAtivoAntigoReadOnly
            // 
            this.txtAtivoAntigoReadOnly.Location = new System.Drawing.Point(140, 105);
            this.txtAtivoAntigoReadOnly.MaxLength = 9;
            this.txtAtivoAntigoReadOnly.Name = "txtAtivoAntigoReadOnly";
            this.txtAtivoAntigoReadOnly.ReadOnly = true;
            this.txtAtivoAntigoReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtAtivoAntigoReadOnly.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Ativo Antigo:";
            // 
            // txtAtivoNovoReadOnly
            // 
            this.txtAtivoNovoReadOnly.Location = new System.Drawing.Point(140, 77);
            this.txtAtivoNovoReadOnly.MaxLength = 9;
            this.txtAtivoNovoReadOnly.Name = "txtAtivoNovoReadOnly";
            this.txtAtivoNovoReadOnly.ReadOnly = true;
            this.txtAtivoNovoReadOnly.Size = new System.Drawing.Size(300, 20);
            this.txtAtivoNovoReadOnly.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(60, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Ativo Novo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Computador (*)";
            // 
            // cboComputador
            // 
            this.cboComputador.FormattingEnabled = true;
            this.cboComputador.Location = new System.Drawing.Point(9, 40);
            this.cboComputador.Name = "cboComputador";
            this.cboComputador.Size = new System.Drawing.Size(377, 21);
            this.cboComputador.TabIndex = 0;
            this.cboComputador.SelectedIndexChanged += new System.EventHandler(this.cboComputador_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cboLicenca);
            this.groupBox3.Location = new System.Drawing.Point(12, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1082, 68);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selecionar a Licença a ser aplicada";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(243, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Licença (*)";
            // 
            // cboLicenca
            // 
            this.cboLicenca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLicenca.FormattingEnabled = true;
            this.cboLicenca.Location = new System.Drawing.Point(244, 37);
            this.cboLicenca.Name = "cboLicenca";
            this.cboLicenca.Size = new System.Drawing.Size(605, 21);
            this.cboLicenca.TabIndex = 0;
            // 
            // dgvLicencasAssociadas
            // 
            this.dgvLicencasAssociadas.AllowUserToAddRows = false;
            this.dgvLicencasAssociadas.AllowUserToDeleteRows = false;
            this.dgvLicencasAssociadas.AllowUserToOrderColumns = true;
            this.dgvLicencasAssociadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicencasAssociadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLicencasAssociadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLicencasAssociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicencasAssociadas.Location = new System.Drawing.Point(12, 320);
            this.dgvLicencasAssociadas.MultiSelect = false;
            this.dgvLicencasAssociadas.Name = "dgvLicencasAssociadas";
            this.dgvLicencasAssociadas.ReadOnly = true;
            this.dgvLicencasAssociadas.Size = new System.Drawing.Size(1082, 293);
            this.dgvLicencasAssociadas.TabIndex = 40;
            this.dgvLicencasAssociadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLicencasAssociadas_CellDoubleClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(604, 291);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 43;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(523, 291);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 42;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(442, 291);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 41;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FrmAssociarLicencaNoComputador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 625);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvLicencasAssociadas);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAssociarLicencaNoComputador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associação de Licenças no Computador";
            this.Load += new System.EventHandler(this.AssociarLicencaNoComputador_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencasAssociadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotaFiscalIdReadOnly;
        private System.Windows.Forms.TextBox txtLinkReadOnly;
        private System.Windows.Forms.TextBox txtEmpresaReadOnly;
        private System.Windows.Forms.TextBox txtDataReadOnly;
        private System.Windows.Forms.TextBox txtFornecedorReadOnly;
        private System.Windows.Forms.TextBox txtNumNFReadOnly;
        private System.Windows.Forms.Button btnNovaPesquisa;
        private System.Windows.Forms.TextBox txtNumNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboComputador;
        private System.Windows.Forms.TextBox txtAtivoNovoReadOnly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAtivoAntigoReadOnly;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUsuarioReadOnly;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDepartamentoReadOnly;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnNovaPesquisaComputador;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboLicenca;
        private System.Windows.Forms.DataGridView dgvLicencasAssociadas;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
    }
}