namespace Inventario.TIC.Forms
{
    partial class FrmLicencas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtVersaoReadOnly = new System.Windows.Forms.TextBox();
            this.txtFabricanteReadOnly = new System.Windows.Forms.TextBox();
            this.txtNomeReadOnly = new System.Windows.Forms.TextBox();
            this.btnNovaPesquisaSoftware = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSoftware = new System.Windows.Forms.ComboBox();
            this.dgvLicencas = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencas)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 198);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Nota Fiscal";
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
            // 
            // txtNumNF
            // 
            this.txtNumNF.Location = new System.Drawing.Point(16, 36);
            this.txtNumNF.MaxLength = 9;
            this.txtNumNF.Name = "txtNumNF";
            this.txtNumNF.Size = new System.Drawing.Size(86, 20);
            this.txtNumNF.TabIndex = 39;
            this.txtNumNF.Leave += new System.EventHandler(this.txtNumNF_Leave_1);
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
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtVersaoReadOnly);
            this.groupBox2.Controls.Add(this.txtFabricanteReadOnly);
            this.groupBox2.Controls.Add(this.txtNomeReadOnly);
            this.groupBox2.Controls.Add(this.btnNovaPesquisaSoftware);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboSoftware);
            this.groupBox2.Location = new System.Drawing.Point(569, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 198);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados do Software";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Software (*)";
            // 
            // txtVersaoReadOnly
            // 
            this.txtVersaoReadOnly.Location = new System.Drawing.Point(85, 121);
            this.txtVersaoReadOnly.MaxLength = 9;
            this.txtVersaoReadOnly.Name = "txtVersaoReadOnly";
            this.txtVersaoReadOnly.ReadOnly = true;
            this.txtVersaoReadOnly.Size = new System.Drawing.Size(305, 20);
            this.txtVersaoReadOnly.TabIndex = 44;
            // 
            // txtFabricanteReadOnly
            // 
            this.txtFabricanteReadOnly.Location = new System.Drawing.Point(85, 93);
            this.txtFabricanteReadOnly.MaxLength = 9;
            this.txtFabricanteReadOnly.Name = "txtFabricanteReadOnly";
            this.txtFabricanteReadOnly.ReadOnly = true;
            this.txtFabricanteReadOnly.Size = new System.Drawing.Size(305, 20);
            this.txtFabricanteReadOnly.TabIndex = 43;
            // 
            // txtNomeReadOnly
            // 
            this.txtNomeReadOnly.Location = new System.Drawing.Point(85, 66);
            this.txtNomeReadOnly.MaxLength = 9;
            this.txtNomeReadOnly.Name = "txtNomeReadOnly";
            this.txtNomeReadOnly.ReadOnly = true;
            this.txtNomeReadOnly.Size = new System.Drawing.Size(305, 20);
            this.txtNomeReadOnly.TabIndex = 42;
            // 
            // btnNovaPesquisaSoftware
            // 
            this.btnNovaPesquisaSoftware.Location = new System.Drawing.Point(295, 35);
            this.btnNovaPesquisaSoftware.Name = "btnNovaPesquisaSoftware";
            this.btnNovaPesquisaSoftware.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaSoftware.TabIndex = 41;
            this.btnNovaPesquisaSoftware.Text = "Nova Pesquisa";
            this.btnNovaPesquisaSoftware.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaSoftware.Click += new System.EventHandler(this.btnNovaPesquisaSoftware_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(29, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Versão:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Fabricante:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome:";
            // 
            // cboSoftware
            // 
            this.cboSoftware.FormattingEnabled = true;
            this.cboSoftware.Location = new System.Drawing.Point(6, 39);
            this.cboSoftware.Name = "cboSoftware";
            this.cboSoftware.Size = new System.Drawing.Size(283, 21);
            this.cboSoftware.TabIndex = 0;
            this.cboSoftware.SelectedIndexChanged += new System.EventHandler(this.cboSoftware_SelectedIndexChanged);
            // 
            // dgvLicencas
            // 
            this.dgvLicencas.AllowDrop = true;
            this.dgvLicencas.AllowUserToOrderColumns = true;
            this.dgvLicencas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicencas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicencas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLicencas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLicencas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLicencas.Location = new System.Drawing.Point(2, 332);
            this.dgvLicencas.MultiSelect = false;
            this.dgvLicencas.Name = "dgvLicencas";
            this.dgvLicencas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLicencas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLicencas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLicencas.Size = new System.Drawing.Size(990, 335);
            this.dgvLicencas.TabIndex = 41;
            this.dgvLicencas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLicencas_CellDoubleClick);
            this.dgvLicencas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLicencas_ColumnHeaderMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cboStatus);
            this.groupBox3.Controls.Add(this.txtChave);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(215, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 81);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados da Licença";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(9, 39);
            this.txtId.MaxLength = 9;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(49, 20);
            this.txtId.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(400, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Status (*)";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cboStatus.Location = new System.Drawing.Point(403, 39);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(109, 21);
            this.cboStatus.TabIndex = 42;
            // 
            // txtChave
            // 
            this.txtChave.Location = new System.Drawing.Point(64, 39);
            this.txtChave.MaxLength = 200;
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(333, 20);
            this.txtChave.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Chave (*)";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(583, 303);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 46;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(502, 303);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 45;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(421, 303);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 44;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(340, 303);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 43;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FrmLicencas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvLicencas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmLicencas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciamento de Licenças";
            this.Load += new System.EventHandler(this.FrmLicencas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNovaPesquisa;
        private System.Windows.Forms.TextBox txtNumNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSoftware;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNovaPesquisaSoftware;
        private System.Windows.Forms.DataGridView dgvLicencas;
        private System.Windows.Forms.TextBox txtNotaFiscalIdReadOnly;
        private System.Windows.Forms.TextBox txtLinkReadOnly;
        private System.Windows.Forms.TextBox txtEmpresaReadOnly;
        private System.Windows.Forms.TextBox txtDataReadOnly;
        private System.Windows.Forms.TextBox txtFornecedorReadOnly;
        private System.Windows.Forms.TextBox txtNumNFReadOnly;
        private System.Windows.Forms.TextBox txtVersaoReadOnly;
        private System.Windows.Forms.TextBox txtFabricanteReadOnly;
        private System.Windows.Forms.TextBox txtNomeReadOnly;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtId;
    }
}