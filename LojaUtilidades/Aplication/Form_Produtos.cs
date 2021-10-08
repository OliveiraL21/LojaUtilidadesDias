using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Services.Produtos;
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
    public partial class Form_Produtos : Form
    {
        //private static readonly DbContextOptions<MyContext> _context = new DbContextOptions<MyContext>();
        //private static readonly MyContext context = new MyContext(_context);
        //private static readonly IProdutoRepository _repository = new ProdutoImplementation(context);
        private readonly IProdutoService _service;
        public Form_Produtos(IProdutoService service)
        {
            _service = service;
            InitializeComponent();
        }
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();
            Close();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas form_Vendas = new Form_Vendas();
            form_Vendas.ShowDialog();
            Close();
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Produtos já está aberto","Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            var nome = txt_Produto.Text;
            var valor = double.Parse(txt_Valor.Text);
            var quantidade = int.Parse(txt_Quantidade.Text);
            var produto = new ProdutoEntity()
            {
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade
            };
            try
            {
                var result = await _service.Post(produto);
                if (result != null)
                {
                    MessageBox.Show("Produto Cadastrado com Sucesso !", "Produto Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar o produto ", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar o produto {ex.Message}", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
