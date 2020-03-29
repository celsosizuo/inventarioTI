namespace Inventario.TIC.Forms
{
    partial class FrmCelulares
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLinhas = new System.Windows.Forms.DataGridView();
            this.txtLinha = new System.Windows.Forms.TextBox();
            this.txtLinhaIdReadOnly = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtChipReadOnly = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroReadOnly = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaLinha = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUsuarioIdReadOnly = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtChapaReadOnly = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCpfReadOnly = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeReadOnly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaUsuario = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAparelhoIdReadOnly = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImei1ReadOnly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModeloReadOnly = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMarcaReadOnly = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvAparelhos = new System.Windows.Forms.DataGridView();
            this.txtImei1 = new System.Windows.Forms.TextBox();
            this.btnNovaPesquisaAparelho = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dgvCelulares = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAparelhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCelulares)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLinhas);
            this.groupBox1.Controls.Add(this.txtLinha);
            this.groupBox1.Controls.Add(this.txtLinhaIdReadOnly);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtChipReadOnly);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumeroReadOnly);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnNovaPesquisaLinha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar Linha";
            // 
            // dgvLinhas
            // 
            this.dgvLinhas.AllowUserToAddRows = false;
            this.dgvLinhas.AllowUserToDeleteRows = false;
            this.dgvLinhas.AllowUserToOrderColumns = true;
            this.dgvLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLinhas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLinhas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLinhas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinhas.Location = new System.Drawing.Point(6, 68);
            this.dgvLinhas.MultiSelect = false;
            this.dgvLinhas.Name = "dgvLinhas";
            this.dgvLinhas.ReadOnly = true;
            this.dgvLinhas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinhas.Size = new System.Drawing.Size(393, 88);
            this.dgvLinhas.TabIndex = 83;
            this.dgvLinhas.Visible = false;
            this.dgvLinhas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinhas_CellDoubleClick);
            this.dgvLinhas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvLinhas_KeyPress);
            // 
            // txtLinha
            // 
            this.txtLinha.Location = new System.Drawing.Point(6, 40);
            this.txtLinha.MaxLength = 9;
            this.txtLinha.Name = "txtLinha";
            this.txtLinha.Size = new System.Drawing.Size(258, 20);
            this.txtLinha.TabIndex = 82;
            this.txtLinha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLinha_KeyPress);
            // 
            // txtLinhaIdReadOnly
            // 
            this.txtLinhaIdReadOnly.Location = new System.Drawing.Point(475, 46);
            this.txtLinhaIdReadOnly.MaxLength = 9;
            this.txtLinhaIdReadOnly.Name = "txtLinhaIdReadOnly";
            this.txtLinhaIdReadOnly.ReadOnly = true;
            this.txtLinhaIdReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtLinhaIdReadOnly.TabIndex = 81;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(419, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "ID";
            // 
            // txtChipReadOnly
            // 
            this.txtChipReadOnly.Location = new System.Drawing.Point(475, 98);
            this.txtChipReadOnly.MaxLength = 9;
            this.txtChipReadOnly.Name = "txtChipReadOnly";
            this.txtChipReadOnly.ReadOnly = true;
            this.txtChipReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtChipReadOnly.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Chip";
            // 
            // txtNumeroReadOnly
            // 
            this.txtNumeroReadOnly.Location = new System.Drawing.Point(475, 72);
            this.txtNumeroReadOnly.MaxLength = 9;
            this.txtNumeroReadOnly.Name = "txtNumeroReadOnly";
            this.txtNumeroReadOnly.ReadOnly = true;
            this.txtNumeroReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtNumeroReadOnly.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(419, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Número";
            // 
            // btnNovaPesquisaLinha
            // 
            this.btnNovaPesquisaLinha.Location = new System.Drawing.Point(269, 37);
            this.btnNovaPesquisaLinha.Name = "btnNovaPesquisaLinha";
            this.btnNovaPesquisaLinha.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaLinha.TabIndex = 52;
            this.btnNovaPesquisaLinha.Text = "Nova Pesquisa";
            this.btnNovaPesquisaLinha.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaLinha.Click += new System.EventHandler(this.btnNovaPesquisaLinha_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Linha (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsuarioIdReadOnly);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.dgvUsuarios);
            this.groupBox2.Controls.Add(this.txtChapaReadOnly);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCpfReadOnly);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNomeReadOnly);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnNovaPesquisaUsuario);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 152);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar Usuário";
            // 
            // txtUsuarioIdReadOnly
            // 
            this.txtUsuarioIdReadOnly.Location = new System.Drawing.Point(476, 30);
            this.txtUsuarioIdReadOnly.MaxLength = 9;
            this.txtUsuarioIdReadOnly.Name = "txtUsuarioIdReadOnly";
            this.txtUsuarioIdReadOnly.ReadOnly = true;
            this.txtUsuarioIdReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtUsuarioIdReadOnly.TabIndex = 81;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(420, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "ID";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(6, 38);
            this.txtUsuario.MaxLength = 9;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(258, 20);
            this.txtUsuario.TabIndex = 73;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
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
            this.dgvUsuarios.Location = new System.Drawing.Point(1, 64);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(393, 82);
            this.dgvUsuarios.TabIndex = 72;
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsuarios_KeyDown);
            this.dgvUsuarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvUsuarios_KeyPress);
            // 
            // txtChapaReadOnly
            // 
            this.txtChapaReadOnly.Location = new System.Drawing.Point(476, 108);
            this.txtChapaReadOnly.MaxLength = 9;
            this.txtChapaReadOnly.Name = "txtChapaReadOnly";
            this.txtChapaReadOnly.ReadOnly = true;
            this.txtChapaReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtChapaReadOnly.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(420, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Chapa";
            // 
            // txtCpfReadOnly
            // 
            this.txtCpfReadOnly.Location = new System.Drawing.Point(476, 82);
            this.txtCpfReadOnly.MaxLength = 9;
            this.txtCpfReadOnly.Name = "txtCpfReadOnly";
            this.txtCpfReadOnly.ReadOnly = true;
            this.txtCpfReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtCpfReadOnly.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "CPF";
            // 
            // txtNomeReadOnly
            // 
            this.txtNomeReadOnly.Location = new System.Drawing.Point(476, 56);
            this.txtNomeReadOnly.MaxLength = 9;
            this.txtNomeReadOnly.Name = "txtNomeReadOnly";
            this.txtNomeReadOnly.ReadOnly = true;
            this.txtNomeReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtNomeReadOnly.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Nome";
            // 
            // btnNovaPesquisaUsuario
            // 
            this.btnNovaPesquisaUsuario.Location = new System.Drawing.Point(270, 34);
            this.btnNovaPesquisaUsuario.Name = "btnNovaPesquisaUsuario";
            this.btnNovaPesquisaUsuario.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaUsuario.TabIndex = 52;
            this.btnNovaPesquisaUsuario.Text = "Nova Pesquisa";
            this.btnNovaPesquisaUsuario.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaUsuario.Click += new System.EventHandler(this.btnNovaPesquisaUsuario_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Usuário (*)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAparelhoIdReadOnly);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtImei1ReadOnly);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtModeloReadOnly);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMarcaReadOnly);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dgvAparelhos);
            this.groupBox3.Controls.Add(this.txtImei1);
            this.groupBox3.Controls.Add(this.btnNovaPesquisaAparelho);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(754, 152);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selecionar Aparelho";
            // 
            // txtAparelhoIdReadOnly
            // 
            this.txtAparelhoIdReadOnly.Location = new System.Drawing.Point(476, 33);
            this.txtAparelhoIdReadOnly.MaxLength = 9;
            this.txtAparelhoIdReadOnly.Name = "txtAparelhoIdReadOnly";
            this.txtAparelhoIdReadOnly.ReadOnly = true;
            this.txtAparelhoIdReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtAparelhoIdReadOnly.TabIndex = 79;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(420, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "ID";
            // 
            // txtImei1ReadOnly
            // 
            this.txtImei1ReadOnly.Location = new System.Drawing.Point(476, 111);
            this.txtImei1ReadOnly.MaxLength = 9;
            this.txtImei1ReadOnly.Name = "txtImei1ReadOnly";
            this.txtImei1ReadOnly.ReadOnly = true;
            this.txtImei1ReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtImei1ReadOnly.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(420, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "IMEI 1";
            // 
            // txtModeloReadOnly
            // 
            this.txtModeloReadOnly.Location = new System.Drawing.Point(476, 85);
            this.txtModeloReadOnly.MaxLength = 9;
            this.txtModeloReadOnly.Name = "txtModeloReadOnly";
            this.txtModeloReadOnly.ReadOnly = true;
            this.txtModeloReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtModeloReadOnly.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(420, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Modelo";
            // 
            // txtMarcaReadOnly
            // 
            this.txtMarcaReadOnly.Location = new System.Drawing.Point(476, 59);
            this.txtMarcaReadOnly.MaxLength = 9;
            this.txtMarcaReadOnly.Name = "txtMarcaReadOnly";
            this.txtMarcaReadOnly.ReadOnly = true;
            this.txtMarcaReadOnly.Size = new System.Drawing.Size(248, 20);
            this.txtMarcaReadOnly.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(420, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Marca";
            // 
            // dgvAparelhos
            // 
            this.dgvAparelhos.AllowUserToAddRows = false;
            this.dgvAparelhos.AllowUserToDeleteRows = false;
            this.dgvAparelhos.AllowUserToOrderColumns = true;
            this.dgvAparelhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAparelhos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAparelhos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAparelhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAparelhos.Location = new System.Drawing.Point(6, 64);
            this.dgvAparelhos.MultiSelect = false;
            this.dgvAparelhos.Name = "dgvAparelhos";
            this.dgvAparelhos.ReadOnly = true;
            this.dgvAparelhos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAparelhos.Size = new System.Drawing.Size(393, 82);
            this.dgvAparelhos.TabIndex = 71;
            this.dgvAparelhos.Visible = false;
            this.dgvAparelhos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAparelhos_CellDoubleClick);
            this.dgvAparelhos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAparelhos_KeyDown);
            this.dgvAparelhos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvAparelhos_KeyPress);
            // 
            // txtImei1
            // 
            this.txtImei1.Location = new System.Drawing.Point(6, 38);
            this.txtImei1.MaxLength = 9;
            this.txtImei1.Name = "txtImei1";
            this.txtImei1.Size = new System.Drawing.Size(258, 20);
            this.txtImei1.TabIndex = 70;
            this.txtImei1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImei1_KeyPress);
            // 
            // btnNovaPesquisaAparelho
            // 
            this.btnNovaPesquisaAparelho.Location = new System.Drawing.Point(270, 33);
            this.btnNovaPesquisaAparelho.Name = "btnNovaPesquisaAparelho";
            this.btnNovaPesquisaAparelho.Size = new System.Drawing.Size(87, 25);
            this.btnNovaPesquisaAparelho.TabIndex = 52;
            this.btnNovaPesquisaAparelho.Text = "Nova Pesquisa";
            this.btnNovaPesquisaAparelho.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaAparelho.Click += new System.EventHandler(this.btnNovaPesquisaAparelho_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "IMEI 1 (*)";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(435, 508);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 63;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(354, 508);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 62;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(273, 508);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 61;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // dgvCelulares
            // 
            this.dgvCelulares.AllowUserToAddRows = false;
            this.dgvCelulares.AllowUserToDeleteRows = false;
            this.dgvCelulares.AllowUserToOrderColumns = true;
            this.dgvCelulares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCelulares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCelulares.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCelulares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCelulares.Location = new System.Drawing.Point(13, 537);
            this.dgvCelulares.MultiSelect = false;
            this.dgvCelulares.Name = "dgvCelulares";
            this.dgvCelulares.ReadOnly = true;
            this.dgvCelulares.Size = new System.Drawing.Size(753, 233);
            this.dgvCelulares.TabIndex = 60;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(18, 496);
            this.txtId.MaxLength = 9;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(53, 20);
            this.txtId.TabIndex = 83;
            // 
            // FrmCelulares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 782);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvCelulares);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmCelulares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Celulaes";
            this.Load += new System.EventHandler(this.FrmCelulares_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAparelhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCelulares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNovaPesquisaLinha;
        private System.Windows.Forms.TextBox txtChipReadOnly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroReadOnly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCpfReadOnly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeReadOnly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNovaPesquisaUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChapaReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNovaPesquisaAparelho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvCelulares;
        private System.Windows.Forms.TextBox txtAparelhoIdReadOnly;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtImei1ReadOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModeloReadOnly;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMarcaReadOnly;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvAparelhos;
        private System.Windows.Forms.TextBox txtImei1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtUsuarioIdReadOnly;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLinha;
        private System.Windows.Forms.TextBox txtLinhaIdReadOnly;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvLinhas;
        private System.Windows.Forms.TextBox txtId;
    }
}