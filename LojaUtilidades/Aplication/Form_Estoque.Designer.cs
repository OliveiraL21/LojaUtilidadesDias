﻿
namespace Aplication
{
    partial class Form_Estoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Estoque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_Estoque = new System.Windows.Forms.Button();
            this.btn_Vendas = new System.Windows.Forms.Button();
            this.btn_Produto = new System.Windows.Forms.Button();
            this.dgv_Produtos = new System.Windows.Forms.DataGridView();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Deletar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.label_Quantidade = new System.Windows.Forms.Label();
            this.label_Valor = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.txt_Produto = new System.Windows.Forms.TextBox();
            this.label_Produto = new System.Windows.Forms.Label();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produtos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(39)))));
            this.panel_Menu.Controls.Add(this.pictureBox1);
            this.panel_Menu.Controls.Add(this.btn_Sair);
            this.panel_Menu.Controls.Add(this.btn_Estoque);
            this.panel_Menu.Controls.Add(this.btn_Vendas);
            this.panel_Menu.Controls.Add(this.btn_Produto);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(200, 709);
            this.panel_Menu.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 175);
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
            this.btn_Sair.Location = new System.Drawing.Point(0, 639);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(197, 70);
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
            this.btn_Estoque.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Estoque.ForeColor = System.Drawing.Color.White;
            this.btn_Estoque.Image = ((System.Drawing.Image)(resources.GetObject("btn_Estoque.Image")));
            this.btn_Estoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Estoque.Location = new System.Drawing.Point(0, 385);
            this.btn_Estoque.Name = "btn_Estoque";
            this.btn_Estoque.Size = new System.Drawing.Size(197, 70);
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
            this.btn_Vendas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Vendas.ForeColor = System.Drawing.Color.White;
            this.btn_Vendas.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vendas.Image")));
            this.btn_Vendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Vendas.Location = new System.Drawing.Point(3, 295);
            this.btn_Vendas.Name = "btn_Vendas";
            this.btn_Vendas.Size = new System.Drawing.Size(197, 70);
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
            this.btn_Produto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Produto.ForeColor = System.Drawing.Color.White;
            this.btn_Produto.Image = ((System.Drawing.Image)(resources.GetObject("btn_Produto.Image")));
            this.btn_Produto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Produto.Location = new System.Drawing.Point(0, 198);
            this.btn_Produto.Name = "btn_Produto";
            this.btn_Produto.Size = new System.Drawing.Size(197, 70);
            this.btn_Produto.TabIndex = 1;
            this.btn_Produto.Text = "Produtos";
            this.btn_Produto.UseVisualStyleBackColor = true;
            this.btn_Produto.Click += new System.EventHandler(this.btn_Produto_Click);
            this.btn_Produto.MouseLeave += new System.EventHandler(this.btn_Produto_MouseLeave);
            this.btn_Produto.MouseHover += new System.EventHandler(this.btn_Produto_MouseHover);
            // 
            // dgv_Produtos
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Produtos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_Produtos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Produtos.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgv_Produtos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produtos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_Produtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Produtos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.Valor,
            this.Quantidade});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Produtos.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_Produtos.GridColor = System.Drawing.Color.Black;
            this.dgv_Produtos.Location = new System.Drawing.Point(572, 53);
            this.dgv_Produtos.Name = "dgv_Produtos";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produtos.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgv_Produtos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Produtos.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_Produtos.RowTemplate.Height = 25;
            this.dgv_Produtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Produtos.Size = new System.Drawing.Size(650, 644);
            this.dgv_Produtos.TabIndex = 13;
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 47);
            this.panel1.TabIndex = 14;
            // 
            // btn_Deletar
            // 
            this.btn_Deletar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Deletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Deletar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Deletar.ForeColor = System.Drawing.Color.White;
            this.btn_Deletar.Location = new System.Drawing.Point(218, 528);
            this.btn_Deletar.Name = "btn_Deletar";
            this.btn_Deletar.Size = new System.Drawing.Size(123, 50);
            this.btn_Deletar.TabIndex = 23;
            this.btn_Deletar.Text = "Deletar";
            this.btn_Deletar.UseVisualStyleBackColor = false;
            // 
            // btn_Editar
            // 
            this.btn_Editar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Editar.ForeColor = System.Drawing.Color.White;
            this.btn_Editar.Location = new System.Drawing.Point(372, 446);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(123, 50);
            this.btn_Editar.TabIndex = 22;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = false;
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cadastrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_Cadastrar.Location = new System.Drawing.Point(218, 446);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(123, 50);
            this.btn_Cadastrar.TabIndex = 21;
            this.btn_Cadastrar.Text = "Cadastrar";
            this.btn_Cadastrar.UseVisualStyleBackColor = false;
            // 
            // label_Quantidade
            // 
            this.label_Quantidade.AutoSize = true;
            this.label_Quantidade.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Quantidade.Location = new System.Drawing.Point(218, 330);
            this.label_Quantidade.Name = "label_Quantidade";
            this.label_Quantidade.Size = new System.Drawing.Size(123, 23);
            this.label_Quantidade.TabIndex = 20;
            this.label_Quantidade.Text = "Quantidade";
            // 
            // label_Valor
            // 
            this.label_Valor.AutoSize = true;
            this.label_Valor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Valor.Location = new System.Drawing.Point(218, 225);
            this.label_Valor.Name = "label_Valor";
            this.label_Valor.Size = new System.Drawing.Size(59, 23);
            this.label_Valor.TabIndex = 19;
            this.label_Valor.Text = "Valor";
            // 
            // txt_Valor
            // 
            this.txt_Valor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Valor.Location = new System.Drawing.Point(218, 251);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(128, 31);
            this.txt_Valor.TabIndex = 18;
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Quantidade.Location = new System.Drawing.Point(218, 361);
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(128, 31);
            this.txt_Quantidade.TabIndex = 17;
            // 
            // txt_Produto
            // 
            this.txt_Produto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Produto.Location = new System.Drawing.Point(218, 156);
            this.txt_Produto.Name = "txt_Produto";
            this.txt_Produto.Size = new System.Drawing.Size(326, 31);
            this.txt_Produto.TabIndex = 16;
            // 
            // label_Produto
            // 
            this.label_Produto.AutoSize = true;
            this.label_Produto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Produto.Location = new System.Drawing.Point(218, 130);
            this.label_Produto.Name = "label_Produto";
            this.label_Produto.Size = new System.Drawing.Size(81, 23);
            this.label_Produto.TabIndex = 15;
            this.label_Produto.Text = "Produto";
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Consultar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Consultar.ForeColor = System.Drawing.Color.White;
            this.btn_Consultar.Location = new System.Drawing.Point(372, 528);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(123, 50);
            this.btn_Consultar.TabIndex = 24;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = false;
            // 
            // Form_Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 709);
            this.Controls.Add(this.btn_Consultar);
            this.Controls.Add(this.btn_Deletar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Cadastrar);
            this.Controls.Add(this.label_Quantidade);
            this.Controls.Add(this.label_Valor);
            this.Controls.Add(this.txt_Valor);
            this.Controls.Add(this.txt_Quantidade);
            this.Controls.Add(this.txt_Produto);
            this.Controls.Add(this.label_Produto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Produtos);
            this.Controls.Add(this.panel_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Estoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Estoque";
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produtos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Button btn_Estoque;
        private System.Windows.Forms.Button btn_Vendas;
        private System.Windows.Forms.Button btn_Produto;
        private System.Windows.Forms.DataGridView dgv_Produtos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Deletar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cadastrar;
        private System.Windows.Forms.Label label_Quantidade;
        private System.Windows.Forms.Label label_Valor;
        private System.Windows.Forms.TextBox txt_Valor;
        private System.Windows.Forms.TextBox txt_Quantidade;
        private System.Windows.Forms.TextBox txt_Produto;
        private System.Windows.Forms.Label label_Produto;
        private System.Windows.Forms.Button btn_Consultar;
    }
}