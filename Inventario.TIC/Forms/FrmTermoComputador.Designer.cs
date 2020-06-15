namespace Inventario.TIC.Forms
{
    partial class FrmTermoComputador
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTermoComputador = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDataEntrega = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboGestores = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCarregadores = new System.Windows.Forms.DataGridView();
            this.txtCarregador = new System.Windows.Forms.TextBox();
            this.txtCarregadorIdReadOnly = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumSerieReadOnly = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCarregadorMarcaReadOnly = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaCarregador = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelarDevolucao = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.txtUsuarioIdReadOnly = new System.Windows.Forms.TextBox();
            this.lnkAbrirTermoEntrega = new System.Windows.Forms.LinkLabel();
            this.lnkAddTermo = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLinkTermoEntrega = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtLinkTermoDevolucao = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lnkTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.txtChapaReadOnly = new System.Windows.Forms.TextBox();
            this.lnkAbrirTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lnkRemoverTermoEntrega = new System.Windows.Forms.LinkLabel();
            this.txtCpfReadOnly = new System.Windows.Forms.TextBox();
            this.lnkRemoverTermoDevolucao = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeReadOnly = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNovaPesquisaUsuario = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoComputador)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarregadores)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1181, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTermoComputador
            // 
            this.dgvTermoComputador.AllowUserToAddRows = false;
            this.dgvTermoComputador.AllowUserToDeleteRows = false;
            this.dgvTermoComputador.AllowUserToOrderColumns = true;
            this.dgvTermoComputador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTermoComputador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTermoComputador.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTermoComputador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermoComputador.Location = new System.Drawing.Point(12, 461);
            this.dgvTermoComputador.MultiSelect = false;
            this.dgvTermoComputador.Name = "dgvTermoComputador";
            this.dgvTermoComputador.ReadOnly = true;
            this.dgvTermoComputador.Size = new System.Drawing.Size(1244, 332);
            this.dgvTermoComputador.TabIndex = 61;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.txtId);
            this.groupBox5.Controls.Add(this.txtDataEntrega);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.cboGestores);
            this.groupBox5.Location = new System.Drawing.Point(12, 375);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(353, 80);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Outros Dados";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 80;
            this.label25.Text = "Num. Termo";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 40);
            this.txtId.MaxLength = 9;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(62, 20);
            this.txtId.TabIndex = 83;
            // 
            // txtDataEntrega
            // 
            this.txtDataEntrega.Location = new System.Drawing.Point(80, 40);
            this.txtDataEntrega.Mask = "00/00/0000";
            this.txtDataEntrega.Name = "txtDataEntrega";
            this.txtDataEntrega.Size = new System.Drawing.Size(86, 20);
            this.txtDataEntrega.TabIndex = 6;
            this.txtDataEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(77, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Data Entrega (*)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(169, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Gestor (*)";
            // 
            // cboGestores
            // 
            this.cboGestores.FormattingEnabled = true;
            this.cboGestores.Location = new System.Drawing.Point(172, 39);
            this.cboGestores.Name = "cboGestores";
            this.cboGestores.Size = new System.Drawing.Size(170, 21);
            this.cboGestores.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvCarregadores);
            this.groupBox4.Controls.Add(this.txtCarregador);
            this.groupBox4.Controls.Add(this.txtCarregadorIdReadOnly);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtNumSerieReadOnly);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtCarregadorMarcaReadOnly);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.btnNovaPesquisaCarregador);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(12, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 162);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selecionar Carregador";
            // 
            // dgvCarregadores
            // 
            this.dgvCarregadores.AllowUserToAddRows = false;
            this.dgvCarregadores.AllowUserToDeleteRows = false;
            this.dgvCarregadores.AllowUserToOrderColumns = true;
            this.dgvCarregadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarregadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCarregadores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCarregadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarregadores.Location = new System.Drawing.Point(6, 68);
            this.dgvCarregadores.MultiSelect = false;
            this.dgvCarregadores.Name = "dgvCarregadores";
            this.dgvCarregadores.ReadOnly = true;
            this.dgvCarregadores.RowHeadersVisible = false;
            this.dgvCarregadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarregadores.Size = new System.Drawing.Size(321, 88);
            this.dgvCarregadores.TabIndex = 3;
            this.dgvCarregadores.Visible = false;
            // 
            // txtCarregador
            // 
            this.txtCarregador.Location = new System.Drawing.Point(6, 40);
            this.txtCarregador.MaxLength = 500;
            this.txtCarregador.Name = "txtCarregador";
            this.txtCarregador.Size = new System.Drawing.Size(219, 20);
            this.txtCarregador.TabIndex = 2;
            // 
            // txtCarregadorIdReadOnly
            // 
            this.txtCarregadorIdReadOnly.Location = new System.Drawing.Point(398, 46);
            this.txtCarregadorIdReadOnly.MaxLength = 9;
            this.txtCarregadorIdReadOnly.Name = "txtCarregadorIdReadOnly";
            this.txtCarregadorIdReadOnly.ReadOnly = true;
            this.txtCarregadorIdReadOnly.Size = new System.Drawing.Size(110, 20);
            this.txtCarregadorIdReadOnly.TabIndex = 81;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(342, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "ID";
            // 
            // txtNumSerieReadOnly
            // 
            this.txtNumSerieReadOnly.Location = new System.Drawing.Point(398, 98);
            this.txtNumSerieReadOnly.MaxLength = 9;
            this.txtNumSerieReadOnly.Name = "txtNumSerieReadOnly";
            this.txtNumSerieReadOnly.ReadOnly = true;
            this.txtNumSerieReadOnly.Size = new System.Drawing.Size(110, 20);
            this.txtNumSerieReadOnly.TabIndex = 56;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(342, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "N. Série";
            // 
            // txtCarregadorMarcaReadOnly
            // 
            this.txtCarregadorMarcaReadOnly.Location = new System.Drawing.Point(398, 72);
            this.txtCarregadorMarcaReadOnly.MaxLength = 9;
            this.txtCarregadorMarcaReadOnly.Name = "txtCarregadorMarcaReadOnly";
            this.txtCarregadorMarcaReadOnly.ReadOnly = true;
            this.txtCarregadorMarcaReadOnly.Size = new System.Drawing.Size(110, 20);
            this.txtCarregadorMarcaReadOnly.TabIndex = 54;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(342, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Marca";
            // 
            // btnNovaPesquisaCarregador
            // 
            this.btnNovaPesquisaCarregador.Location = new System.Drawing.Point(232, 37);
            this.btnNovaPesquisaCarregador.Name = "btnNovaPesquisaCarregador";
            this.btnNovaPesquisaCarregador.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaCarregador.TabIndex = 52;
            this.btnNovaPesquisaCarregador.Text = "Nova Pesquisa";
            this.btnNovaPesquisaCarregador.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Carregador (*)";
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
            this.groupBox2.Size = new System.Drawing.Size(528, 150);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuários";
            // 
            // btnCancelarDevolucao
            // 
            this.btnCancelarDevolucao.Location = new System.Drawing.Point(1107, 405);
            this.btnCancelarDevolucao.Name = "btnCancelarDevolucao";
            this.btnCancelarDevolucao.Size = new System.Drawing.Size(121, 23);
            this.btnCancelarDevolucao.TabIndex = 116;
            this.btnCancelarDevolucao.Text = "Cancelar Devolução";
            this.btnCancelarDevolucao.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(1031, 405);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(70, 23);
            this.btnDevolver.TabIndex = 115;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // txtUsuarioIdReadOnly
            // 
            this.txtUsuarioIdReadOnly.Location = new System.Drawing.Point(386, 41);
            this.txtUsuarioIdReadOnly.MaxLength = 9;
            this.txtUsuarioIdReadOnly.Name = "txtUsuarioIdReadOnly";
            this.txtUsuarioIdReadOnly.ReadOnly = true;
            this.txtUsuarioIdReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtUsuarioIdReadOnly.TabIndex = 81;
            // 
            // lnkAbrirTermoEntrega
            // 
            this.lnkAbrirTermoEntrega.AutoSize = true;
            this.lnkAbrirTermoEntrega.Location = new System.Drawing.Point(398, 399);
            this.lnkAbrirTermoEntrega.Name = "lnkAbrirTermoEntrega";
            this.lnkAbrirTermoEntrega.Size = new System.Drawing.Size(176, 13);
            this.lnkAbrirTermoEntrega.TabIndex = 100;
            this.lnkAbrirTermoEntrega.TabStop = true;
            this.lnkAbrirTermoEntrega.Text = "Link do Termo de Entrega Assinado";
            // 
            // lnkAddTermo
            // 
            this.lnkAddTermo.AutoSize = true;
            this.lnkAddTermo.Location = new System.Drawing.Point(657, 405);
            this.lnkAddTermo.Name = "lnkAddTermo";
            this.lnkAddTermo.Size = new System.Drawing.Size(51, 13);
            this.lnkAddTermo.TabIndex = 98;
            this.lnkAddTermo.TabStop = true;
            this.lnkAddTermo.Text = "Adicionar";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(330, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "ID";
            // 
            // txtLinkTermoEntrega
            // 
            this.txtLinkTermoEntrega.Location = new System.Drawing.Point(401, 414);
            this.txtLinkTermoEntrega.MaxLength = 15;
            this.txtLinkTermoEntrega.Name = "txtLinkTermoEntrega";
            this.txtLinkTermoEntrega.ReadOnly = true;
            this.txtLinkTermoEntrega.Size = new System.Drawing.Size(252, 20);
            this.txtLinkTermoEntrega.TabIndex = 99;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(17, 41);
            this.txtUsuario.MaxLength = 500;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtUsuario.TabIndex = 10;
            // 
            // txtLinkTermoDevolucao
            // 
            this.txtLinkTermoDevolucao.Location = new System.Drawing.Point(720, 415);
            this.txtLinkTermoDevolucao.MaxLength = 15;
            this.txtLinkTermoDevolucao.Name = "txtLinkTermoDevolucao";
            this.txtLinkTermoDevolucao.ReadOnly = true;
            this.txtLinkTermoDevolucao.Size = new System.Drawing.Size(247, 20);
            this.txtLinkTermoDevolucao.TabIndex = 101;
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
            this.dgvUsuarios.Location = new System.Drawing.Point(17, 70);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(307, 69);
            this.dgvUsuarios.TabIndex = 11;
            this.dgvUsuarios.Visible = false;
            // 
            // lnkTermoDevolucao
            // 
            this.lnkTermoDevolucao.AutoSize = true;
            this.lnkTermoDevolucao.Location = new System.Drawing.Point(972, 404);
            this.lnkTermoDevolucao.Name = "lnkTermoDevolucao";
            this.lnkTermoDevolucao.Size = new System.Drawing.Size(51, 13);
            this.lnkTermoDevolucao.TabIndex = 102;
            this.lnkTermoDevolucao.TabStop = true;
            this.lnkTermoDevolucao.Text = "Adicionar";
            // 
            // txtChapaReadOnly
            // 
            this.txtChapaReadOnly.Location = new System.Drawing.Point(386, 119);
            this.txtChapaReadOnly.MaxLength = 9;
            this.txtChapaReadOnly.Name = "txtChapaReadOnly";
            this.txtChapaReadOnly.ReadOnly = true;
            this.txtChapaReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtChapaReadOnly.TabIndex = 58;
            // 
            // lnkAbrirTermoDevolucao
            // 
            this.lnkAbrirTermoDevolucao.AutoSize = true;
            this.lnkAbrirTermoDevolucao.Location = new System.Drawing.Point(717, 399);
            this.lnkAbrirTermoDevolucao.Name = "lnkAbrirTermoDevolucao";
            this.lnkAbrirTermoDevolucao.Size = new System.Drawing.Size(191, 13);
            this.lnkAbrirTermoDevolucao.TabIndex = 103;
            this.lnkAbrirTermoDevolucao.TabStop = true;
            this.lnkAbrirTermoDevolucao.Text = "Link do Termo de Devolução Assinado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Chapa";
            // 
            // lnkRemoverTermoEntrega
            // 
            this.lnkRemoverTermoEntrega.AutoSize = true;
            this.lnkRemoverTermoEntrega.Location = new System.Drawing.Point(658, 422);
            this.lnkRemoverTermoEntrega.Name = "lnkRemoverTermoEntrega";
            this.lnkRemoverTermoEntrega.Size = new System.Drawing.Size(50, 13);
            this.lnkRemoverTermoEntrega.TabIndex = 104;
            this.lnkRemoverTermoEntrega.TabStop = true;
            this.lnkRemoverTermoEntrega.Text = "Remover";
            // 
            // txtCpfReadOnly
            // 
            this.txtCpfReadOnly.Location = new System.Drawing.Point(386, 93);
            this.txtCpfReadOnly.MaxLength = 9;
            this.txtCpfReadOnly.Name = "txtCpfReadOnly";
            this.txtCpfReadOnly.ReadOnly = true;
            this.txtCpfReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtCpfReadOnly.TabIndex = 56;
            // 
            // lnkRemoverTermoDevolucao
            // 
            this.lnkRemoverTermoDevolucao.AutoSize = true;
            this.lnkRemoverTermoDevolucao.Location = new System.Drawing.Point(973, 421);
            this.lnkRemoverTermoDevolucao.Name = "lnkRemoverTermoDevolucao";
            this.lnkRemoverTermoDevolucao.Size = new System.Drawing.Size(50, 13);
            this.lnkRemoverTermoDevolucao.TabIndex = 105;
            this.lnkRemoverTermoDevolucao.TabStop = true;
            this.lnkRemoverTermoDevolucao.Text = "Remover";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "CPF";
            // 
            // txtNomeReadOnly
            // 
            this.txtNomeReadOnly.Location = new System.Drawing.Point(386, 67);
            this.txtNomeReadOnly.MaxLength = 9;
            this.txtNomeReadOnly.Name = "txtNomeReadOnly";
            this.txtNomeReadOnly.ReadOnly = true;
            this.txtNomeReadOnly.Size = new System.Drawing.Size(131, 20);
            this.txtNomeReadOnly.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Nome";
            // 
            // btnNovaPesquisaUsuario
            // 
            this.btnNovaPesquisaUsuario.Location = new System.Drawing.Point(229, 38);
            this.btnNovaPesquisaUsuario.Name = "btnNovaPesquisaUsuario";
            this.btnNovaPesquisaUsuario.Size = new System.Drawing.Size(95, 25);
            this.btnNovaPesquisaUsuario.TabIndex = 52;
            this.btnNovaPesquisaUsuario.Text = "Nova Pesquisa";
            this.btnNovaPesquisaUsuario.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Usuário (*)";
            // 
            // FrmTermoComputador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 805);
            this.Controls.Add(this.btnCancelarDevolucao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lnkAbrirTermoEntrega);
            this.Controls.Add(this.lnkAddTermo);
            this.Controls.Add(this.dgvTermoComputador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLinkTermoEntrega);
            this.Controls.Add(this.lnkRemoverTermoDevolucao);
            this.Controls.Add(this.lnkRemoverTermoEntrega);
            this.Controls.Add(this.txtLinkTermoDevolucao);
            this.Controls.Add(this.lnkAbrirTermoDevolucao);
            this.Controls.Add(this.lnkTermoDevolucao);
            this.Name = "FrmTermoComputador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termo de Computadores";
            this.Load += new System.EventHandler(this.FrmTermoComputador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermoComputador)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarregadores)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvTermoComputador;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox txtDataEntrega;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboGestores;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvCarregadores;
        private System.Windows.Forms.TextBox txtCarregador;
        private System.Windows.Forms.TextBox txtCarregadorIdReadOnly;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNumSerieReadOnly;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCarregadorMarcaReadOnly;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnNovaPesquisaCarregador;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUsuarioIdReadOnly;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtChapaReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCpfReadOnly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeReadOnly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNovaPesquisaUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelarDevolucao;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.LinkLabel lnkAbrirTermoEntrega;
        private System.Windows.Forms.LinkLabel lnkAddTermo;
        private System.Windows.Forms.TextBox txtLinkTermoEntrega;
        private System.Windows.Forms.TextBox txtLinkTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkAbrirTermoDevolucao;
        private System.Windows.Forms.LinkLabel lnkRemoverTermoEntrega;
        private System.Windows.Forms.LinkLabel lnkRemoverTermoDevolucao;
    }
}