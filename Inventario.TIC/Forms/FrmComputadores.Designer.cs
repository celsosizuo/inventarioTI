namespace Inventario.TIC.Forms
{
    partial class FrmComputadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComputadores));
            this.dgvComputadores = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.grpDadosComputadores = new System.Windows.Forms.GroupBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAtivoNovo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAtivoAntigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOCSMemory = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOCSProcessorT = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOCSWorkGroup = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOCSWinProdKey = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOCSWinProdId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOCSUserId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOCSOsName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOCSIpAddr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOCSName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOCSId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAssociar = new System.Windows.Forms.Button();
            this.btnAtualizarDados = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvLicencas = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAlterarUsuario = new System.Windows.Forms.Button();
            this.txtUsuarioNovo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvHistoricoUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).BeginInit();
            this.grpDadosComputadores.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencas)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoUsuarios)).BeginInit();
            this.SuspendLayout();
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
            this.dgvComputadores.Location = new System.Drawing.Point(0, 494);
            this.dgvComputadores.MultiSelect = false;
            this.dgvComputadores.Name = "dgvComputadores";
            this.dgvComputadores.ReadOnly = true;
            this.dgvComputadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvComputadores.Size = new System.Drawing.Size(1358, 255);
            this.dgvComputadores.TabIndex = 0;
            this.dgvComputadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComputadores_CellContentClick);
            this.dgvComputadores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComputadores_CellDoubleClick_1);
            this.dgvComputadores.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvComputadores_ColumnHeaderMouseClick);
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
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(16, 37);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(43, 20);
            this.txtId.TabIndex = 2;
            // 
            // grpDadosComputadores
            // 
            this.grpDadosComputadores.Controls.Add(this.txtObservacoes);
            this.grpDadosComputadores.Controls.Add(this.label17);
            this.grpDadosComputadores.Controls.Add(this.cboStatus);
            this.grpDadosComputadores.Controls.Add(this.label5);
            this.grpDadosComputadores.Controls.Add(this.txtDepartamento);
            this.grpDadosComputadores.Controls.Add(this.label4);
            this.grpDadosComputadores.Controls.Add(this.txtUsuario);
            this.grpDadosComputadores.Controls.Add(this.label3);
            this.grpDadosComputadores.Controls.Add(this.txtAtivoNovo);
            this.grpDadosComputadores.Controls.Add(this.label2);
            this.grpDadosComputadores.Controls.Add(this.txtAtivoAntigo);
            this.grpDadosComputadores.Controls.Add(this.label1);
            this.grpDadosComputadores.Controls.Add(this.txtId);
            this.grpDadosComputadores.Controls.Add(this.lblId);
            this.grpDadosComputadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDadosComputadores.Location = new System.Drawing.Point(12, 13);
            this.grpDadosComputadores.Name = "grpDadosComputadores";
            this.grpDadosComputadores.Size = new System.Drawing.Size(731, 113);
            this.grpDadosComputadores.TabIndex = 3;
            this.grpDadosComputadores.TabStop = false;
            this.grpDadosComputadores.Text = "Dados Computadores";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(519, 36);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacoes.Size = new System.Drawing.Size(206, 66);
            this.txtObservacoes.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(516, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Observações";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Items.AddRange(new object[] {
            ""});
            this.cboStatus.Location = new System.Drawing.Point(387, 36);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status (*)";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(263, 82);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(241, 20);
            this.txtDepartamento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Departamento (*)";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(16, 82);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(241, 20);
            this.txtUsuario.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuário (*)";
            // 
            // txtAtivoNovo
            // 
            this.txtAtivoNovo.Location = new System.Drawing.Point(216, 37);
            this.txtAtivoNovo.Name = "txtAtivoNovo";
            this.txtAtivoNovo.Size = new System.Drawing.Size(165, 20);
            this.txtAtivoNovo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ativo Novo (*)";
            // 
            // txtAtivoAntigo
            // 
            this.txtAtivoAntigo.Location = new System.Drawing.Point(65, 37);
            this.txtAtivoAntigo.Name = "txtAtivoAntigo";
            this.txtAtivoAntigo.Size = new System.Drawing.Size(145, 20);
            this.txtAtivoAntigo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ativo Antigo (*)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtOCSWorkGroup);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtOCSWinProdKey);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtOCSWinProdId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtOCSUserId);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOCSOsName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtOCSIpAddr);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtOCSName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtOCSId);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 328);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Coletados do OCS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDiscos);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtOCSMemory);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtOCSProcessorT);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(16, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 215);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hardware";
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.AllowUserToDeleteRows = false;
            this.dgvDiscos.AllowUserToOrderColumns = true;
            this.dgvDiscos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDiscos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDiscos.Location = new System.Drawing.Point(3, 78);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.Size = new System.Drawing.Size(681, 134);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(618, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "WorkGroup";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(260, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Windows ID";
            // 
            // txtOCSUserId
            // 
            this.txtOCSUserId.Location = new System.Drawing.Point(296, 37);
            this.txtOCSUserId.Name = "txtOCSUserId";
            this.txtOCSUserId.ReadOnly = true;
            this.txtOCSUserId.Size = new System.Drawing.Size(106, 20);
            this.txtOCSUserId.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(293, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Usuário";
            // 
            // txtOCSOsName
            // 
            this.txtOCSOsName.Location = new System.Drawing.Point(16, 80);
            this.txtOCSOsName.Name = "txtOCSOsName";
            this.txtOCSOsName.ReadOnly = true;
            this.txtOCSOsName.Size = new System.Drawing.Size(241, 20);
            this.txtOCSOsName.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sistema Operacional";
            // 
            // txtOCSIpAddr
            // 
            this.txtOCSIpAddr.Location = new System.Drawing.Point(208, 37);
            this.txtOCSIpAddr.Name = "txtOCSIpAddr";
            this.txtOCSIpAddr.ReadOnly = true;
            this.txtOCSIpAddr.Size = new System.Drawing.Size(82, 20);
            this.txtOCSIpAddr.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(205, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "IP";
            // 
            // txtOCSName
            // 
            this.txtOCSName.Location = new System.Drawing.Point(65, 37);
            this.txtOCSName.Name = "txtOCSName";
            this.txtOCSName.ReadOnly = true;
            this.txtOCSName.Size = new System.Drawing.Size(137, 20);
            this.txtOCSName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(62, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Nome";
            // 
            // txtOCSId
            // 
            this.txtOCSId.Location = new System.Drawing.Point(16, 37);
            this.txtOCSId.Name = "txtOCSId";
            this.txtOCSId.ReadOnly = true;
            this.txtOCSId.Size = new System.Drawing.Size(43, 20);
            this.txtOCSId.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "ID";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(255, 465);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 26;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(174, 465);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 25;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(93, 465);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 24;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(12, 465);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAssociar
            // 
            this.btnAssociar.Location = new System.Drawing.Point(336, 465);
            this.btnAssociar.Name = "btnAssociar";
            this.btnAssociar.Size = new System.Drawing.Size(113, 23);
            this.btnAssociar.TabIndex = 27;
            this.btnAssociar.Text = "Associar ao OCS";
            this.btnAssociar.UseVisualStyleBackColor = true;
            this.btnAssociar.Click += new System.EventHandler(this.btnAssociar_Click);
            // 
            // btnAtualizarDados
            // 
            this.btnAtualizarDados.Location = new System.Drawing.Point(455, 465);
            this.btnAtualizarDados.Name = "btnAtualizarDados";
            this.btnAtualizarDados.Size = new System.Drawing.Size(104, 23);
            this.btnAtualizarDados.TabIndex = 28;
            this.btnAtualizarDados.Text = "Atualizar Tabela";
            this.btnAtualizarDados.UseVisualStyleBackColor = true;
            this.btnAtualizarDados.Click += new System.EventHandler(this.btnAtualizarDados_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvLicencas);
            this.groupBox3.Location = new System.Drawing.Point(749, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(622, 200);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Licenças (Somente Visualização)";
            // 
            // dgvLicencas
            // 
            this.dgvLicencas.AllowUserToAddRows = false;
            this.dgvLicencas.AllowUserToDeleteRows = false;
            this.dgvLicencas.AllowUserToOrderColumns = true;
            this.dgvLicencas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicencas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLicencas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLicencas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicencas.Location = new System.Drawing.Point(3, 21);
            this.dgvLicencas.MultiSelect = false;
            this.dgvLicencas.Name = "dgvLicencas";
            this.dgvLicencas.ReadOnly = true;
            this.dgvLicencas.Size = new System.Drawing.Size(613, 172);
            this.dgvLicencas.TabIndex = 15;
            this.dgvLicencas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLicencas_CellDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnAlterarUsuario);
            this.groupBox4.Controls.Add(this.txtUsuarioNovo);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.dgvHistoricoUsuarios);
            this.groupBox4.Location = new System.Drawing.Point(752, 219);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(622, 240);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Histórico de Usuários";
            // 
            // btnAlterarUsuario
            // 
            this.btnAlterarUsuario.Location = new System.Drawing.Point(253, 36);
            this.btnAlterarUsuario.Name = "btnAlterarUsuario";
            this.btnAlterarUsuario.Size = new System.Drawing.Size(104, 23);
            this.btnAlterarUsuario.TabIndex = 29;
            this.btnAlterarUsuario.Text = "Alterar Usuário";
            this.btnAlterarUsuario.UseVisualStyleBackColor = true;
            this.btnAlterarUsuario.Click += new System.EventHandler(this.btnAlterarUsuario_Click);
            // 
            // txtUsuarioNovo
            // 
            this.txtUsuarioNovo.Location = new System.Drawing.Point(6, 38);
            this.txtUsuarioNovo.Name = "txtUsuarioNovo";
            this.txtUsuarioNovo.Size = new System.Drawing.Size(241, 20);
            this.txtUsuarioNovo.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Usuário Novo (*)";
            // 
            // dgvHistoricoUsuarios
            // 
            this.dgvHistoricoUsuarios.AllowUserToAddRows = false;
            this.dgvHistoricoUsuarios.AllowUserToDeleteRows = false;
            this.dgvHistoricoUsuarios.AllowUserToOrderColumns = true;
            this.dgvHistoricoUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistoricoUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHistoricoUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistoricoUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoricoUsuarios.Location = new System.Drawing.Point(3, 77);
            this.dgvHistoricoUsuarios.MultiSelect = false;
            this.dgvHistoricoUsuarios.Name = "dgvHistoricoUsuarios";
            this.dgvHistoricoUsuarios.ReadOnly = true;
            this.dgvHistoricoUsuarios.Size = new System.Drawing.Size(613, 156);
            this.dgvHistoricoUsuarios.TabIndex = 15;
            // 
            // FrmComputadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAtualizarDados);
            this.Controls.Add(this.btnAssociar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDadosComputadores);
            this.Controls.Add(this.dgvComputadores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmComputadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computadores";
            this.Load += new System.EventHandler(this.FrmComputadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputadores)).EndInit();
            this.grpDadosComputadores.ResumeLayout(false);
            this.grpDadosComputadores.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicencas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox grpDadosComputadores;
        private System.Windows.Forms.TextBox txtAtivoNovo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAtivoAntigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOCSUserId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOCSOsName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOCSIpAddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOCSName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOCSId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOCSWinProdId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOCSWinProdKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOCSWorkGroup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOCSProcessorT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOCSMemory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAssociar;
        private System.Windows.Forms.Button btnAtualizarDados;
        private System.Windows.Forms.DataGridView dgvComputadores;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvLicencas;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvHistoricoUsuarios;
        private System.Windows.Forms.TextBox txtUsuarioNovo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAlterarUsuario;
    }
}