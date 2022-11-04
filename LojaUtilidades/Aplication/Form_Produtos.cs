using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        int datagridRowIndex = 0;
        private readonly IProdutoService _ProdutoService;
        private readonly string Path;
        public Form_Produtos()
        {
            InitializeComponent();
            _ProdutoService = new ProdutoService();
            Path = Application.StartupPath + @"\Logs\Tela-Cadastro-Produtos-.txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(Path, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            
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

        private void btn_Estoque_Vendas_MouseHover(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.DarkMagenta;
        }

        private void btn_Estoque_Vendas_MouseLeave(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.FromArgb(41, 0, 39);
        }


        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.Show();
          
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas form_Vendas = new Form_Vendas();
            form_Vendas.Show();
            
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Produtos já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas form_Consulta_Venda = new Form_Consulta_Vendas();
            form_Consulta_Venda.Show();
        }
        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Metodos do formulário
        private void DatagridFill(Produto produto)
        {
            dataGrid_Produtos.Rows.Add();
            dataGrid_Produtos.Rows[datagridRowIndex].Cells[0].Value = produto.Id;
            dataGrid_Produtos.Rows[datagridRowIndex].Cells[1].Value = produto.Nome;
            dataGrid_Produtos.Rows[datagridRowIndex].Cells[2].Value = produto.Valor;
            dataGrid_Produtos.Rows[datagridRowIndex].Cells[3].Value = produto.Quantidade;
            datagridRowIndex++;
        }
        private  void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto(txt_Produto.Text, double.Parse(txt_Valor.Text), int.Parse(txt_Quantidade.Text));
                var result =  _ProdutoService.Insert(produto);

                if (result != null)
                {
                    MessageBox.Show("Produto Cadastrado com Sucesso !", "Produto Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DatagridFill(result);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar o produto", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao cadastrar o produto");
            }
            finally
            {
                txt_Codigo.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }
        private  void btn_Editar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Produto produto = new Produto(txt_Produto.Text, double.Parse(txt_Valor.Text), int.Parse(txt_Quantidade.Text));
                var result =  _ProdutoService.Update(produto);
                if (result != null)
                {
                    MessageBox.Show("Produto editado com sucesso !", "Produto editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DatagridFill(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar editar o produto", "Erro ao editar o produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar editar o produto");
            }
            finally
            {
                txt_Codigo.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }
        private  void btn_Deletar_Click(object sender, EventArgs e)
        {
            
            try
            {
                var produto = dataGrid_Produtos.SelectedRows[0].Cells[1].Value.ToString();
                dataGrid_Produtos.Rows.Remove(dataGrid_Produtos.SelectedRows[0]);
                datagridRowIndex = dataGrid_Produtos.Rows.Count;
             
                var result =  _ProdutoService.DeleteByName(produto);
                
                MessageBox.Show("Produto deletado com sucesso", "Produto Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erro ao deletar o produto", "Erro ao Deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(exception, "\nErro ao tentar deletar o produto");
            }
            finally
            {
                txt_Codigo.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }
        private void dgv_Produtos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_Codigo.Text = dataGrid_Produtos.SelectedRows[0].Cells[0].Value.ToString();
                txt_Produto.Text = dataGrid_Produtos.SelectedRows[0].Cells[1].Value.ToString();
                txt_Valor.Text = dataGrid_Produtos.SelectedRows[0].Cells[2].Value.ToString();
                txt_Quantidade.Text = dataGrid_Produtos.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar ao transferir dados para os campos", "Erro ao Deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar transferir dados da gridview para os campos");
            }
            
        }
        #endregion

       
    }
}
