using Data.Context;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
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
    public partial class Form_Estoque : Form
    {
        private readonly IProdutoService _service;
        
        
        public Form_Estoque()
        {
            InitializeComponent();
            _service = new ProdutoService();
        }
        #region front-end
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
            Form_Produtos form_Produtos = new Form_Produtos();
            form_Produtos.ShowDialog();
            Close();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas form_Vendas = new Form_Vendas();
            form_Vendas.ShowDialog();
            Close();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Estoque já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private async void btn_Consultar_Click(object sender, EventArgs e)
        {
            var nome = txt_Produto.Text;
            try
            {
                var result = await _service.SelectByName(nome);
                
                
                if (result != null)
                {
                    dgv_Estoque.Rows.Clear();
                    dgv_Estoque.Rows[0].Cells[0].Value = result.Id;
                    dgv_Estoque.Rows[0].Cells[1].Value = result.Nome;
                    dgv_Estoque.Rows[0].Cells[2].Value = result.Valor;
                    dgv_Estoque.Rows[0].Cells[3].Value = result.Quantidade;
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao encontrar o produto  {ex.Message}", "Erro de busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_Deletar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dgv_Estoque.SelectedRows[0].Cells[0].Value.ToString());
            try
            {
                var result = await _service.Delete(id);
                if(result == true)
                {
                    MessageBox.Show("Produto deletado com sucesso !", "Produto Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir {ex.Message}", "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Estoque_DoubleClick(object sender, EventArgs e)
        {
            txt_Id.Text = dgv_Estoque.SelectedRows[0].Cells[0].Value.ToString();
            txt_Produto.Text = dgv_Estoque.SelectedRows[0].Cells[1].Value.ToString();
            txt_Valor.Text = dgv_Estoque.SelectedRows[0].Cells[2].Value.ToString();
            txt_Quantidade.Text = dgv_Estoque.SelectedRows[0].Cells[3].Value.ToString();
        }

        private async void btn_Editar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txt_Id.Text);
            var nome = txt_Produto.Text;
            var valor = double.Parse(txt_Valor.Text);
            var quantidade = int.Parse(txt_Quantidade.Text);
            var produto = new ProdutoEntity()
            {
                Id = id,
                Nome = nome,
                Valor = valor,
                Quantidade = quantidade
            };

            try
            {
                var result = await _service.Put(produto);
                if(result != null)
                {
                    MessageBox.Show("Produto editado com sucesso !", "Produto editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar editar o produto {ex.Message}", "Erro ao editar o produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Form_Estoque_Load(object sender, EventArgs e)
        {
            try
            {
                
                var result = await _service.GetAll();
                if(result == null)
                {
                    MessageBox.Show("Erro ao baixar a lista de produtos ", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int i = 0;
                   
                    foreach (var produto in result)
                    {
                        dgv_Estoque.Rows.Add();
                        dgv_Estoque.Rows[i].Cells[0].Value = produto.Id;
                        dgv_Estoque.Rows[i ].Cells[1].Value = produto.Nome;
                        dgv_Estoque.Rows[i].Cells[2].Value = produto.Valor;
                        dgv_Estoque.Rows[i].Cells[3].Value = produto.Quantidade;

                        i++;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao baixar a lista de produtos {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_Atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                {
                    MessageBox.Show("Erro ao baixar a lista de produtos ", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int i = 0;
                    dgv_Estoque.Rows.Clear();
                    foreach (var produto in result)
                    {
                        dgv_Estoque.Rows.Add();
                        dgv_Estoque.Rows[i].Cells[0].Value = produto.Id;
                        dgv_Estoque.Rows[i].Cells[1].Value = produto.Nome;
                        dgv_Estoque.Rows[i].Cells[2].Value = produto.Valor;
                        dgv_Estoque.Rows[i].Cells[3].Value = produto.Quantidade;

                        i++;
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao baixar a lista de produtos {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
