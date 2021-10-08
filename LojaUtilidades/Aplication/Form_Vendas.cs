﻿using Domain.Interfaces.Services.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplication
{
    public partial class Form_Vendas : Form
    {
        private readonly IProdutoService _service;
        public Form_Vendas()
        {
            InitializeComponent();
        }

        private void btn_Produto_MouseHover(object sender, EventArgs e)
        {
            btn_Produto.BackColor = Color.DarkMagenta;
        }

        private void btn_Produto_MouseLeave(object sender, EventArgs e)
        {
            btn_Produto.BackColor = Color.FromArgb(41, 0, 39);
        }

        private void btn_Vendas_MouseHover(object sender, EventArgs e)
        {
            btn_Vendas.BackColor = Color.DarkMagenta;
        }

        private void btn_Vendas_MouseLeave(object sender, EventArgs e)
        {
            btn_Vendas.BackColor = Color.FromArgb(41, 0, 39);
        }

        private void btn_Estoque_MouseHover(object sender, EventArgs e)
        {
            btn_Estoque.BackColor = Color.DarkMagenta;
        }

        private void btn_Estoque_MouseLeave(object sender, EventArgs e)
        {
            btn_Estoque.BackColor = Color.FromArgb(41, 0, 39);
        }

        private void btn_Sair_MouseHover(object sender, EventArgs e)
        {
            btn_Sair.BackColor = Color.DarkMagenta;
        }

        private void btn_Sair_MouseLeave(object sender, EventArgs e)
        {
            btn_Sair.BackColor = Color.FromArgb(41, 0, 39);
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            Form_Produtos form_Produtos = new();
            form_Produtos.ShowDialog();
            Close();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            Close();
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();
           
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Vendas já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}