namespace Inventario.TIC.Forms
{
    partial class FrmAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccess));
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.dgvAccess = new System.Windows.Forms.DataGridView();
            this.txtEnderecoAcesso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPalavraPasse = new System.Windows.Forms.TextBox();
            this.lblRevelarSenha = new System.Windows.Forms.Label();
            this.btnRevelar = new System.Windows.Forms.Button();
            this.lblSenhaRevelada = new System.Windows.Forms.Label();
            this.txtSenhaRevelada = new System.Windows.Forms.TextBox();
            this.lnkRevelarSenha = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(431, 193);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 11;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(269, 193);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(350, 193);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(188, 193);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(71, 35);
            this.txtDescricao.MaxLength = 500;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(304, 20);
            this.txtDescricao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Descrição (*)";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(22, 35);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(43, 20);
            this.txtId.TabIndex = 81;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(19, 19);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 80;
            this.lblId.Text = "ID";
            // 
            // dgvAccess
            // 
            this.dgvAccess.AllowDrop = true;
            this.dgvAccess.AllowUserToAddRows = false;
            this.dgvAccess.AllowUserToDeleteRows = false;
            this.dgvAccess.AllowUserToOrderColumns = true;
            this.dgvAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAccess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAccess.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccess.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccess.Location = new System.Drawing.Point(0, 222);
            this.dgvAccess.MultiSelect = false;
            this.dgvAccess.Name = "dgvAccess";
            this.dgvAccess.ReadOnly = true;
            this.dgvAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAccess.Size = new System.Drawing.Size(701, 240);
            this.dgvAccess.TabIndex = 79;
            this.dgvAccess.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            this.dgvAccess.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutos_ColumnHeaderMouseClick);
            // 
            // txtEnderecoAcesso
            // 
            this.txtEnderecoAcesso.Location = new System.Drawing.Point(381, 35);
            this.txtEnderecoAcesso.MaxLength = 500;
            this.txtEnderecoAcesso.Name = "txtEnderecoAcesso";
            this.txtEnderecoAcesso.Size = new System.Drawing.Size(304, 20);
            this.txtEnderecoAcesso.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Endereço de Acesso (*)";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(22, 79);
            this.txtObservacao.MaxLength = 500;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(241, 86);
            this.txtObservacao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Observações";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(269, 96);
            this.txtUsuario.MaxLength = 500;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(168, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Usuário (*)";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(269, 140);
            this.txtSenha.MaxLength = 500;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(168, 20);
            this.txtSenha.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(269, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Senha (*)";
            // 
            // txtPalavraPasse
            // 
            this.txtPalavraPasse.Location = new System.Drawing.Point(443, 96);
            this.txtPalavraPasse.MaxLength = 500;
            this.txtPalavraPasse.Name = "txtPalavraPasse";
            this.txtPalavraPasse.PasswordChar = '*';
            this.txtPalavraPasse.Size = new System.Drawing.Size(168, 20);
            this.txtPalavraPasse.TabIndex = 5;
            // 
            // lblRevelarSenha
            // 
            this.lblRevelarSenha.AutoSize = true;
            this.lblRevelarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevelarSenha.Location = new System.Drawing.Point(440, 79);
            this.lblRevelarSenha.Name = "lblRevelarSenha";
            this.lblRevelarSenha.Size = new System.Drawing.Size(224, 13);
            this.lblRevelarSenha.TabIndex = 97;
            this.lblRevelarSenha.Text = "Para revelar a senha, digite a palavra secreta ";
            // 
            // btnRevelar
            // 
            this.btnRevelar.Location = new System.Drawing.Point(617, 94);
            this.btnRevelar.Name = "btnRevelar";
            this.btnRevelar.Size = new System.Drawing.Size(41, 23);
            this.btnRevelar.TabIndex = 6;
            this.btnRevelar.Text = "...";
            this.btnRevelar.UseVisualStyleBackColor = true;
            this.btnRevelar.Click += new System.EventHandler(this.btnRevelar_Click);
            // 
            // lblSenhaRevelada
            // 
            this.lblSenhaRevelada.AutoSize = true;
            this.lblSenhaRevelada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaRevelada.Location = new System.Drawing.Point(440, 123);
            this.lblSenhaRevelada.Name = "lblSenhaRevelada";
            this.lblSenhaRevelada.Size = new System.Drawing.Size(87, 13);
            this.lblSenhaRevelada.TabIndex = 100;
            this.lblSenhaRevelada.Text = "Senha Revelada";
            // 
            // txtSenhaRevelada
            // 
            this.txtSenhaRevelada.Location = new System.Drawing.Point(443, 140);
            this.txtSenhaRevelada.MaxLength = 500;
            this.txtSenhaRevelada.Name = "txtSenhaRevelada";
            this.txtSenhaRevelada.Size = new System.Drawing.Size(168, 20);
            this.txtSenhaRevelada.TabIndex = 7;
            // 
            // lnkRevelarSenha
            // 
            this.lnkRevelarSenha.AutoSize = true;
            this.lnkRevelarSenha.Location = new System.Drawing.Point(512, 198);
            this.lnkRevelarSenha.Name = "lnkRevelarSenha";
            this.lnkRevelarSenha.Size = new System.Drawing.Size(78, 13);
            this.lnkRevelarSenha.TabIndex = 12;
            this.lnkRevelarSenha.TabStop = true;
            this.lnkRevelarSenha.Text = "Revelar Senha";
            this.lnkRevelarSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRevelarSenha_LinkClicked);
            // 
            // FrmAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 461);
            this.Controls.Add(this.lnkRevelarSenha);
            this.Controls.Add(this.lblSenhaRevelada);
            this.Controls.Add(this.txtSenhaRevelada);
            this.Controls.Add(this.btnRevelar);
            this.Controls.Add(this.lblRevelarSenha);
            this.Controls.Add(this.txtPalavraPasse);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEnderecoAcesso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvAccess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciamento de Credenciais";
            this.Load += new System.EventHandler(this.FrmAccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DataGridView dgvAccess;
        private System.Windows.Forms.TextBox txtEnderecoAcesso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPalavraPasse;
        private System.Windows.Forms.Label lblRevelarSenha;
        private System.Windows.Forms.Button btnRevelar;
        private System.Windows.Forms.Label lblSenhaRevelada;
        private System.Windows.Forms.TextBox txtSenhaRevelada;
        private System.Windows.Forms.LinkLabel lnkRevelarSenha;
    }
}