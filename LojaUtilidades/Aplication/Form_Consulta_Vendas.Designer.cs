﻿
namespace Aplication
{
    partial class Form_Consulta_Vendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Consulta_Vendas));
            this.dataGrid_Vendas = new System.Windows.Forms.DataGridView();
            this.Cod_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Da_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Minimizar = new System.Windows.Forms.Button();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.Data_Da_Venda = new System.Windows.Forms.Label();
            this.lbl_Produto = new System.Windows.Forms.Label();
            this.txt_Data = new System.Windows.Forms.MaskedTextBox();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.btn_Estoque_Vendas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_Estoque = new System.Windows.Forms.Button();
            this.btn_Vendas = new System.Windows.Forms.Button();
            this.btn_Produto = new System.Windows.Forms.Button();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.txt_Produto = new System.Windows.Forms.TextBox();
            this.label_Produto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Mes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Vendas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_Vendas
            // 
            this.dataGrid_Vendas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrid_Vendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGrid_Vendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_Vendas.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dataGrid_Vendas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_Vendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGrid_Vendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Vendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Venda,
            this.Produto,
            this.Quantidade,
            this.Total,
            this.dataGridViewTextBoxColumn1,
            this.Hora_Da_Venda});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_Vendas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGrid_Vendas.GridColor = System.Drawing.Color.Black;
            this.dataGrid_Vendas.Location = new System.Drawing.Point(151, 214);
            this.dataGrid_Vendas.Name = "dataGrid_Vendas";
            this.dataGrid_Vendas.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_Vendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGrid_Vendas.RowHeadersWidth = 51;
            this.dataGrid_Vendas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrid_Vendas.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGrid_Vendas.RowTemplate.Height = 25;
            this.dataGrid_Vendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_Vendas.Size = new System.Drawing.Size(709, 314);
            this.dataGrid_Vendas.TabIndex = 13;
            // 
            // Cod_Venda
            // 
            this.Cod_Venda.HeaderText = "Cod_Venda";
            this.Cod_Venda.MinimumWidth = 6;
            this.Cod_Venda.Name = "Cod_Venda";
            this.Cod_Venda.ReadOnly = true;
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.MinimumWidth = 6;
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.MinimumWidth = 6;
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Data da Venda";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Hora_Da_Venda
            // 
            this.Hora_Da_Venda.HeaderText = "Horário";
            this.Hora_Da_Venda.MinimumWidth = 6;
            this.Hora_Da_Venda.Name = "Hora_Da_Venda";
            this.Hora_Da_Venda.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_Minimizar);
            this.panel1.Controls.Add(this.btn_Limpar);
            this.panel1.Controls.Add(this.btn_Consultar);
            this.panel1.Location = new System.Drawing.Point(137, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 55);
            this.panel1.TabIndex = 22;
            // 
            // btn_Minimizar
            // 
            this.btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimizar.Image = global::Utilidades_e_Cosmeticos_Dias.Properties.Resources.minimizar;
            this.btn_Minimizar.Location = new System.Drawing.Point(756, 13);
            this.btn_Minimizar.Name = "btn_Minimizar";
            this.btn_Minimizar.Size = new System.Drawing.Size(31, 31);
            this.btn_Minimizar.TabIndex = 33;
            this.btn_Minimizar.UseVisualStyleBackColor = true;
            this.btn_Minimizar.Click += new System.EventHandler(this.btn_Minimizar_Click);
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.FlatAppearance.BorderSize = 0;
            this.btn_Limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Limpar.ForeColor = System.Drawing.Color.White;
            this.btn_Limpar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpar.Image")));
            this.btn_Limpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Limpar.Location = new System.Drawing.Point(151, 2);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(154, 52);
            this.btn_Limpar.TabIndex = 12;
            this.btn_Limpar.Text = "Limpar Lista";
            this.btn_Limpar.UseVisualStyleBackColor = true;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.FlatAppearance.BorderSize = 0;
            this.btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Consultar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Consultar.ForeColor = System.Drawing.Color.White;
            this.btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Consultar.Image")));
            this.btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Consultar.Location = new System.Drawing.Point(14, 2);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(152, 53);
            this.btn_Consultar.TabIndex = 9;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // Data_Da_Venda
            // 
            this.Data_Da_Venda.AutoSize = true;
            this.Data_Da_Venda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Data_Da_Venda.Location = new System.Drawing.Point(142, 128);
            this.Data_Da_Venda.Name = "Data_Da_Venda";
            this.Data_Da_Venda.Size = new System.Drawing.Size(107, 16);
            this.Data_Da_Venda.TabIndex = 23;
            this.Data_Da_Venda.Text = "Data da Venda";
            // 
            // lbl_Produto
            // 
            this.lbl_Produto.AutoSize = true;
            this.lbl_Produto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Produto.Location = new System.Drawing.Point(142, 87);
            this.lbl_Produto.Name = "lbl_Produto";
            this.lbl_Produto.Size = new System.Drawing.Size(124, 16);
            this.lbl_Produto.TabIndex = 24;
            this.lbl_Produto.Text = "Código da Venda";
            // 
            // txt_Data
            // 
            this.txt_Data.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Data.Location = new System.Drawing.Point(255, 122);
            this.txt_Data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Data.Mask = "00/00/0000";
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.Size = new System.Drawing.Size(134, 29);
            this.txt_Data.TabIndex = 25;
            this.txt_Data.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txt_Data.ValidatingType = typeof(System.DateTime);
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Codigo.Location = new System.Drawing.Point(272, 80);
            this.txt_Codigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(75, 29);
            this.txt_Codigo.TabIndex = 26;
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(39)))));
            this.panel_Menu.Controls.Add(this.btn_Estoque_Vendas);
            this.panel_Menu.Controls.Add(this.pictureBox1);
            this.panel_Menu.Controls.Add(this.btn_Sair);
            this.panel_Menu.Controls.Add(this.btn_Estoque);
            this.panel_Menu.Controls.Add(this.btn_Vendas);
            this.panel_Menu.Controls.Add(this.btn_Produto);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(142, 592);
            this.panel_Menu.TabIndex = 27;
            // 
            // btn_Estoque_Vendas
            // 
            this.btn_Estoque_Vendas.FlatAppearance.BorderSize = 0;
            this.btn_Estoque_Vendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Estoque_Vendas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Estoque_Vendas.ForeColor = System.Drawing.Color.White;
            this.btn_Estoque_Vendas.Image = ((System.Drawing.Image)(resources.GetObject("btn_Estoque_Vendas.Image")));
            this.btn_Estoque_Vendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Estoque_Vendas.Location = new System.Drawing.Point(2, 372);
            this.btn_Estoque_Vendas.Name = "btn_Estoque_Vendas";
            this.btn_Estoque_Vendas.Size = new System.Drawing.Size(138, 52);
            this.btn_Estoque_Vendas.TabIndex = 5;
            this.btn_Estoque_Vendas.Text = "     Consultar    Vendas";
            this.btn_Estoque_Vendas.UseVisualStyleBackColor = true;
            this.btn_Estoque_Vendas.Click += new System.EventHandler(this.btn_Estoque_Vendas_Click_);
            this.btn_Estoque_Vendas.MouseLeave += new System.EventHandler(this.btn_Estoque_Vendas_MouseLeave);
            this.btn_Estoque_Vendas.MouseHover += new System.EventHandler(this.btn_Estoque_Vendas_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Sair
            // 
            this.btn_Sair.FlatAppearance.BorderSize = 0;
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sair.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Sair.ForeColor = System.Drawing.Color.White;
            this.btn_Sair.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sair.Image")));
            this.btn_Sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sair.Location = new System.Drawing.Point(3, 537);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(138, 52);
            this.btn_Sair.TabIndex = 4;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            this.btn_Sair.MouseLeave += new System.EventHandler(this.btn_Sair_MouseLeave);
            this.btn_Sair.MouseHover += new System.EventHandler(this.btn_Sair_MouseHover);
            // 
            // btn_Estoque
            // 
            this.btn_Estoque.FlatAppearance.BorderSize = 0;
            this.btn_Estoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Estoque.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Estoque.ForeColor = System.Drawing.Color.White;
            this.btn_Estoque.Image = ((System.Drawing.Image)(resources.GetObject("btn_Estoque.Image")));
            this.btn_Estoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Estoque.Location = new System.Drawing.Point(-1, 289);
            this.btn_Estoque.Name = "btn_Estoque";
            this.btn_Estoque.Size = new System.Drawing.Size(138, 52);
            this.btn_Estoque.TabIndex = 3;
            this.btn_Estoque.Text = "Estoque";
            this.btn_Estoque.UseVisualStyleBackColor = true;
            this.btn_Estoque.Click += new System.EventHandler(this.btn_Estoque_Click);
            this.btn_Estoque.MouseLeave += new System.EventHandler(this.btn_Estoque_MouseLeave);
            this.btn_Estoque.MouseHover += new System.EventHandler(this.btn_Estoque_MouseHover);
            // 
            // btn_Vendas
            // 
            this.btn_Vendas.FlatAppearance.BorderSize = 0;
            this.btn_Vendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Vendas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Vendas.ForeColor = System.Drawing.Color.White;
            this.btn_Vendas.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vendas.Image")));
            this.btn_Vendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Vendas.Location = new System.Drawing.Point(-1, 214);
            this.btn_Vendas.Name = "btn_Vendas";
            this.btn_Vendas.Size = new System.Drawing.Size(138, 52);
            this.btn_Vendas.TabIndex = 2;
            this.btn_Vendas.Text = "Vendas";
            this.btn_Vendas.UseVisualStyleBackColor = true;
            this.btn_Vendas.Click += new System.EventHandler(this.btn_Vendas_Click);
            this.btn_Vendas.MouseLeave += new System.EventHandler(this.btn_Vendas_MouseLeave);
            this.btn_Vendas.MouseHover += new System.EventHandler(this.btn_Vendas_MouseHover);
            // 
            // btn_Produto
            // 
            this.btn_Produto.FlatAppearance.BorderSize = 0;
            this.btn_Produto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Produto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Produto.ForeColor = System.Drawing.Color.White;
            this.btn_Produto.Image = ((System.Drawing.Image)(resources.GetObject("btn_Produto.Image")));
            this.btn_Produto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Produto.Location = new System.Drawing.Point(-1, 131);
            this.btn_Produto.Name = "btn_Produto";
            this.btn_Produto.Size = new System.Drawing.Size(138, 52);
            this.btn_Produto.TabIndex = 1;
            this.btn_Produto.Text = "Produtos";
            this.btn_Produto.UseVisualStyleBackColor = true;
            this.btn_Produto.Click += new System.EventHandler(this.btn_Produto_Click);
            this.btn_Produto.MouseLeave += new System.EventHandler(this.btn_Produto_MouseLeave);
            this.btn_Produto.MouseHover += new System.EventHandler(this.btn_Produto_MouseHover);
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enviar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Enviar.ForeColor = System.Drawing.Color.White;
            this.btn_Enviar.Location = new System.Drawing.Point(255, 171);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(92, 35);
            this.btn_Enviar.TabIndex = 28;
            this.btn_Enviar.Text = "Enviar";
            this.btn_Enviar.UseVisualStyleBackColor = false;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // txt_Produto
            // 
            this.txt_Produto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Produto.Location = new System.Drawing.Point(415, 80);
            this.txt_Produto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Produto.Name = "txt_Produto";
            this.txt_Produto.Size = new System.Drawing.Size(224, 29);
            this.txt_Produto.TabIndex = 29;
            // 
            // label_Produto
            // 
            this.label_Produto.AutoSize = true;
            this.label_Produto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Produto.Location = new System.Drawing.Point(353, 87);
            this.label_Produto.Name = "label_Produto";
            this.label_Produto.Size = new System.Drawing.Size(56, 16);
            this.label_Produto.TabIndex = 30;
            this.label_Produto.Text = "Produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(395, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mês";
            // 
            // comboBox_Mes
            // 
            this.comboBox_Mes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_Mes.ForeColor = System.Drawing.Color.Black;
            this.comboBox_Mes.FormattingEnabled = true;
            this.comboBox_Mes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.comboBox_Mes.Location = new System.Drawing.Point(434, 125);
            this.comboBox_Mes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Mes.Name = "comboBox_Mes";
            this.comboBox_Mes.Size = new System.Drawing.Size(134, 29);
            this.comboBox_Mes.TabIndex = 32;
            // 
            // Form_Consulta_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 592);
            this.Controls.Add(this.comboBox_Mes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Produto);
            this.Controls.Add(this.txt_Produto);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.txt_Codigo);
            this.Controls.Add(this.txt_Data);
            this.Controls.Add(this.lbl_Produto);
            this.Controls.Add(this.Data_Da_Venda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid_Vendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Consulta_Vendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Consulta_Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Vendas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGrid_Vendas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.Label Data_Da_Venda;
        private System.Windows.Forms.Label lbl_Produto;
        private System.Windows.Forms.MaskedTextBox txt_Data;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button btn_Estoque_Vendas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Button btn_Estoque;
        private System.Windows.Forms.Button btn_Vendas;
        private System.Windows.Forms.Button btn_Produto;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Da_Venda;
        private System.Windows.Forms.TextBox txt_Produto;
        private System.Windows.Forms.Label label_Produto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Mes;
        private System.Windows.Forms.Button btn_Minimizar;
    }
}