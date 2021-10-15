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
        int i = 0;
        private readonly IProdutoService _service;
        public Form_Produtos()
        {
            InitializeComponent();
            _service = new ProdutoService();
        }
        #region Front-End
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
#endregion
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
                    MessageBox.Show("Produto Cadastrado com Sucesso !", "Produto Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgv_Produtos.Rows.Add();
                    dgv_Produtos.Rows[i].Cells[0].Value = result.Id;
                    dgv_Produtos.Rows[i].Cells[1].Value = result.Nome;
                    dgv_Produtos.Rows[i].Cells[2].Value = result.Valor;
                    dgv_Produtos.Rows[i].Cells[3].Value = result.Quantidade;
                    i++;
                    
                    
                    
                    
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
            finally
            {
                txt_Id.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
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
                if (result != null)
                {
                    MessageBox.Show("Produto editado com sucesso !", "Produto editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var consulta = await _service.Get(result.Id);
                    dgv_Produtos.Rows[i].Cells[0].Value = consulta.Id;
                    dgv_Produtos.Rows[i].Cells[1].Value = consulta.Nome;
                    dgv_Produtos.Rows[i].Cells[2].Value = consulta.Valor;
                    dgv_Produtos.Rows[i].Cells[3].Value = consulta.Quantidade;
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar editar o produto {ex.Message}", "Erro ao editar o produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txt_Id.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }



        private async void btn_Deletar_Click(object sender, EventArgs e)
        {
            var nome = txt_Produto.Text;
            try
            {
                var result = await _service.DeleteByName(nome);
                MessageBox.Show("Produto deletado com sucesso", "Produto Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar o produto {ex.Message}", "Erro ao Deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                var list = await _service.GetAll();
                if (list == null)
                {
                    MessageBox.Show("Erro ao baixar a lista de produtos ", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int i = 0;
                    dgv_Produtos.Rows.Clear();
                    foreach (var produto in list)
                    {
                        dgv_Produtos.Rows.Add();
                        dgv_Produtos.Rows[i].Cells[0].Value = produto.Id;
                        dgv_Produtos.Rows[i].Cells[1].Value = produto.Nome;
                        dgv_Produtos.Rows[i].Cells[2].Value = produto.Valor;
                        dgv_Produtos.Rows[i].Cells[3].Value = produto.Quantidade;

                        i++;
                    }
                    txt_Id.Text = "";
                    txt_Produto.Text = "";
                    txt_Valor.Text = "";
                    txt_Quantidade.Text = "";
                }
            }
        }
        private void dgv_Produtos_DoubleClick(object sender, EventArgs e)
        {
            txt_Id.Text = dgv_Produtos.SelectedRows[0].Cells[0].Value.ToString();
            txt_Produto.Text = dgv_Produtos.SelectedRows[0].Cells[1].Value.ToString();
            txt_Valor.Text = dgv_Produtos.SelectedRows[0].Cells[2].Value.ToString();
            txt_Quantidade.Text = dgv_Produtos.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
