namespace Inventario.TIC.Forms
{
    partial class FrmDispositivoAlugado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAssociar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dgvComputadores = new System.Windows.Forms.DataGridView();
            this.grpDadosComputadores = new System.Windows.Forms.GroupBox();
            this.chkAvulso = new System.Windows.Forms.CheckBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDispositivo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAtivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuarioIdReadOnly = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtChapaReadOnly = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCpfReadOnly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeReadOnly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaUsuario = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOCSMemory = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOCSProcessorT = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOCSWorkGroup = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOCSWinProdKey = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOCSWinProdId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOCSUserId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOCSOsName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOCSIpAddr = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOCSName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtOCSId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).BeginInit();
            this.grpDadosComputadores.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAssociar
            // 
            this.btnAssociar.Location = new System.Drawing.Point(337, 466);
            this.btnAssociar.Name = "btnAssociar";
            this.btnAssociar.Size = new System.Drawing.Size(113, 23);
            this.btnAssociar.TabIndex = 33;
            this.btnAssociar.Text = "Associar ao OCS";
            this.btnAssociar.UseVisualStyleBackColor = true;
            this.btnAssociar.Click += new System.EventHandler(this.btnAssociar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(256, 466);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 32;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(175, 466);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 31;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(94, 466);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 30;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(13, 466);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // dgvComputadores
            // 
            this.dgvComputadores.AllowDrop = true;
            this.dgvComputadores.AllowUserToOrderColumns = true;
            this.dgvComputadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComputadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComputadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComputadores.Location = new System.Drawing.Point(1, 495);
            this.dgvComputadores.MultiSelect = false;
            this.dgvComputadores.Name = "dgvComputadores";
            this.dgvComputadores.ReadOnly = true;
            this.dgvComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvComputadores.Size = new System.Drawing.Size(1335, 255);
            this.dgvComputadores.TabIndex = 28;
            this.dgvComputadores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComputadores_CellDoubleClick);
            this.dgvComputadores.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvComputadores_ColumnHeaderMouseClick);
            // 
            // grpDadosComputadores
            // 
            this.grpDadosComputadores.Controls.Add(this.txtDepartamento);
            this.grpDadosComputadores.Controls.Add(this.label21);
            this.grpDadosComputadores.Controls.Add(this.chkAvulso);
            this.grpDadosComputadores.Controls.Add(this.txtValor);
            this.grpDadosComputadores.Controls.Add(this.label3);
            this.grpDadosComputadores.Controls.Add(this.txtModelo);
            this.grpDadosComputadores.Controls.Add(this.label2);
            this.grpDadosComputadores.Controls.Add(this.cboTipoDispositivo);
            this.grpDadosComputadores.Controls.Add(this.label5);
            this.grpDadosComputadores.Controls.Add(this.txtAtivo);
            this.grpDadosComputadores.Controls.Add(this.label1);
            this.grpDadosComputadores.Controls.Add(this.txtId);
            this.grpDadosComputadores.Controls.Add(this.lblId);
            this.grpDadosComputadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDadosComputadores.Location = new System.Drawing.Point(13, 12);
            this.grpDadosComputadores.Name = "grpDadosComputadores";
            this.grpDadosComputadores.Size = new System.Drawing.Size(588, 113);
            this.grpDadosComputadores.TabIndex = 34;
            this.grpDadosComputadores.TabStop = false;
            this.grpDadosComputadores.Text = "Dados Gerais";
            // 
            // chkAvulso
            // 
            this.chkAvulso.AutoSize = true;
            this.chkAvulso.Location = new System.Drawing.Point(518, 78);
            this.chkAvulso.Name = "chkAvulso";
            this.chkAvulso.Size = new System.Drawing.Size(64, 17);
            this.chkAvulso.TabIndex = 17;
            this.chkAvulso.Text = "Avulso?";
            this.chkAvulso.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(167, 78);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(94, 20);
            this.txtValor.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Valor";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(324, 37);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(250, 20);
            this.txtModelo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Modelo (*)";
            // 
            // cboTipoDispositivo
            // 
            this.cboTipoDispositivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDispositivo.Items.AddRange(new object[] {
            ""});
            this.cboTipoDispositivo.Location = new System.Drawing.Point(64, 37);
            this.cboTipoDispositivo.Name = "cboTipoDispositivo";
            this.cboTipoDispositivo.Size = new System.Drawing.Size(253, 21);
            this.cboTipoDispositivo.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Dispositivo (*)";
            // 
            // txtAtivo
            // 
            this.txtAtivo.Location = new System.Drawing.Point(16, 78);
            this.txtAtivo.Name = "txtAtivo";
            this.txtAtivo.Size = new System.Drawing.Size(145, 20);
            this.txtAtivo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ativo (*)";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(16, 37);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(43, 20);
            this.txtId.TabIndex = 2;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(13, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsuarioIdReadOnly);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.dgvUsuarios);
            this.groupBox1.Controls.Add(this.txtChapaReadOnly);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCpfReadOnly);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNomeReadOnly);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnNovaPesquisaUsuario);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(13, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 172);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuário";
            // 
            // txtUsuarioIdReadOnly
            // 
            this.txtUsuarioIdReadOnly.Location = new System.Drawing.Point(385, 36);
            this.txtUsuarioIdReadOnly.MaxLength = 9;
            this.txtUsuarioIdReadOnly.Name = "txtUsuarioIdReadOnly";
            this.txtUsuarioIdReadOnly.ReadOnly = true;
            this.txtUsuarioIdReadOnly.Size = new System.Drawing.Size(189, 20);
            this.txtUsuarioIdReadOnly.TabIndex = 105;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(329, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 104;
            this.label13.Text = "ID";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(16, 41);
            this.txtUsuario.MaxLength = 500;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtUsuario.TabIndex = 94;
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
            this.dgvUsuarios.Location = new System.Drawing.Point(16, 70);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(307, 92);
            this.dgvUsuarios.TabIndex = 95;
            this.dgvUsuarios.Visible = false;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsuarios_KeyDown);
            this.dgvUsuarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvUsuarios_KeyPress);
            // 
            // txtChapaReadOnly
            // 
            this.txtChapaReadOnly.Location = new System.Drawing.Point(385, 114);
            this.txtChapaReadOnly.MaxLength = 9;
            this.txtChapaReadOnly.Name = "txtChapaReadOnly";
            this.txtChapaReadOnly.ReadOnly = true;
            this.txtChapaReadOnly.Size = new System.Drawing.Size(189, 20);
            this.txtChapaReadOnly.TabIndex = 103;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(329, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "Chapa";
            // 
            // txtCpfReadOnly
            // 
            this.txtCpfReadOnly.Location = new System.Drawing.Point(385, 88);
            this.txtCpfReadOnly.MaxLength = 9;
            this.txtCpfReadOnly.Name = "txtCpfReadOnly";
            this.txtCpfReadOnly.ReadOnly = true;
            this.txtCpfReadOnly.Size = new System.Drawing.Size(189, 20);
            this.txtCpfReadOnly.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(329, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "CPF";
            // 
            // txtNomeReadOnly
            // 
            this.txtNomeReadOnly.Location = new System.Drawing.Point(385, 62);
            this.txtNomeReadOnly.MaxLength = 9;
            this.txtNomeReadOnly.Name = "txtNomeReadOnly";
            this.txtNomeReadOnly.ReadOnly = true;
            this.txtNomeReadOnly.Size = new System.Drawing.Size(189, 20);
            this.txtNomeReadOnly.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(329, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 98;
            this.label7.Text = "Nome";
            // 
            // btnNovaPesquisaUsuario
            // 
            this.btnNovaPesquisaUsuario.Location = new System.Drawing.Point(228, 38);
            this.btnNovaPesquisaUsuario.Name = "btnNovaPesquisaUsuario";
            this.btnNovaPesquisaUsuario.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaUsuario.TabIndex = 97;
            this.btnNovaPesquisaUsuario.Text = "Nova Pesquisa";
            this.btnNovaPesquisaUsuario.UseVisualStyleBackColor = true;
            this.btnNovaPesquisaUsuario.Click += new System.EventHandler(this.btnNovaPesquisaUsuario_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Usuário (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtOCSWorkGroup);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOCSWinProdKey);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtOCSWinProdId);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtOCSUserId);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtOCSOsName);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtOCSIpAddr);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtOCSName);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtOCSId);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(607, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 301);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados Coletados do OCS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDiscos);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtOCSMemory);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtOCSProcessorT);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(16, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(703, 186);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hardware";
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.AllowUserToDeleteRows = false;
            this.dgvDiscos.AllowUserToOrderColumns = true;
            this.dgvDiscos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDiscos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiscos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiscos.Location = new System.Drawing.Point(3, 78);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiscos.Size = new System.Drawing.Size(697, 98);
            this.dgvDiscos.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Discos";
            // 
            // txtOCSMemory
            // 
            this.txtOCSMemory.Location = new System.Drawing.Point(472, 36);
            this.txtOCSMemory.Name = "txtOCSMemory";
            this.txtOCSMemory.ReadOnly = true;
            this.txtOCSMemory.Size = new System.Drawing.Size(82, 20);
            this.txtOCSMemory.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(469, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Memória (GB)";
            // 
            // txtOCSProcessorT
            // 
            this.txtOCSProcessorT.Location = new System.Drawing.Point(6, 36);
            this.txtOCSProcessorT.Name = "txtOCSProcessorT";
            this.txtOCSProcessorT.ReadOnly = true;
            this.txtOCSProcessorT.Size = new System.Drawing.Size(460, 20);
            this.txtOCSProcessorT.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Processador";
            // 
            // txtOCSWorkGroup
            // 
            this.txtOCSWorkGroup.Location = new System.Drawing.Point(621, 37);
            this.txtOCSWorkGroup.Name = "txtOCSWorkGroup";
            this.txtOCSWorkGroup.ReadOnly = true;
            this.txtOCSWorkGroup.Size = new System.Drawing.Size(82, 20);
            this.txtOCSWorkGroup.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(618, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "WorkGroup";
            // 
            // txtOCSWinProdKey
            // 
            this.txtOCSWinProdKey.Location = new System.Drawing.Point(408, 37);
            this.txtOCSWinProdKey.Name = "txtOCSWinProdKey";
            this.txtOCSWinProdKey.ReadOnly = true;
            this.txtOCSWinProdKey.Size = new System.Drawing.Size(207, 20);
            this.txtOCSWinProdKey.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(405, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Chave";
            // 
            // txtOCSWinProdId
            // 
            this.txtOCSWinProdId.Location = new System.Drawing.Point(263, 80);
            this.txtOCSWinProdId.Name = "txtOCSWinProdId";
            this.txtOCSWinProdId.ReadOnly = true;
            this.txtOCSWinProdId.Size = new System.Drawing.Size(200, 20);
            this.txtOCSWinProdId.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(260, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Windows ID";
            // 
            // txtOCSUserId
            // 
            this.txtOCSUserId.Location = new System.Drawing.Point(296, 37);
            this.txtOCSUserId.Name = "txtOCSUserId";
            this.txtOCSUserId.ReadOnly = true;
            this.txtOCSUserId.Size = new System.Drawing.Size(106, 20);
            this.txtOCSUserId.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(293, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Usuário";
            // 
            // txtOCSOsName
            // 
            this.txtOCSOsName.Location = new System.Drawing.Point(16, 80);
            this.txtOCSOsName.Name = "txtOCSOsName";
            this.txtOCSOsName.ReadOnly = true;
            this.txtOCSOsName.Size = new System.Drawing.Size(241, 20);
            this.txtOCSOsName.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Sistema Operacional";
            // 
            // txtOCSIpAddr
            // 
            this.txtOCSIpAddr.Location = new System.Drawing.Point(208, 37);
            this.txtOCSIpAddr.Name = "txtOCSIpAddr";
            this.txtOCSIpAddr.ReadOnly = true;
            this.txtOCSIpAddr.Size = new System.Drawing.Size(82, 20);
            this.txtOCSIpAddr.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(205, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "IP";
            // 
            // txtOCSName
            // 
            this.txtOCSName.Location = new System.Drawing.Point(65, 37);
            this.txtOCSName.Name = "txtOCSName";
            this.txtOCSName.ReadOnly = true;
            this.txtOCSName.Size = new System.Drawing.Size(137, 20);
            this.txtOCSName.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(62, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Nome";
            // 
            // txtOCSId
            // 
            this.txtOCSId.Location = new System.Drawing.Point(16, 37);
            this.txtOCSId.Name = "txtOCSId";
            this.txtOCSId.ReadOnly = true;
            this.txtOCSId.Size = new System.Drawing.Size(43, 20);
            this.txtOCSId.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(13, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "ID";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(267, 78);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(245, 20);
            this.txtDepartamento.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(264, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Departamento (*)";
            // 
            // FrmDispositivoAlugado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDadosComputadores);
            this.Controls.Add(this.btnAssociar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvComputadores);
            this.Name = "FrmDispositivoAlugado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispositivos Alugados";
            this.Load += new System.EventHandler(this.FrmDispositivoAlugado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).EndInit();
            this.grpDadosComputadores.ResumeLayout(false);
            this.grpDadosComputadores.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAssociar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvComputadores;
        private System.Windows.Forms.GroupBox grpDadosComputadores;
        private System.Windows.Forms.ComboBox cboTipoDispositivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAtivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAvulso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUsuarioIdReadOnly;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtChapaReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCpfReadOnly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeReadOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNovaPesquisaUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOCSMemory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOCSProcessorT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOCSWorkGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOCSWinProdKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOCSWinProdId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOCSUserId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOCSOsName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtOCSIpAddr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOCSName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtOCSId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label label21;
    }
}