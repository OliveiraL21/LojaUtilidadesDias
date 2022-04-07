using Data.Context;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
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
    public partial class Form_Estoque : Form
    {
        private readonly IProdutoService _service;
        private readonly string Path;
        public Form_Estoque()
        {
            InitializeComponent();
            _service = new ProdutoService();
            Path = Application.StartupPath + @"\Logs\Tela-Estoque-de-Produtos-.txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(Path, rollingInterval: RollingInterval.Day)
                .CreateLogger();
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

        private void btn_Estoque_Vendas_MouseHover(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.DarkMagenta;
        }

        private void btn_Estoque_Vendas_MouseLeave(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.FromArgb(41, 0, 39);
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            Form_Produtos form_Produtos = new Form_Produtos();
            form_Produtos.Show();
            
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas form_Vendas = new Form_Vendas();
            form_Vendas.Show();
           
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Estoque já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas form_Consulta_Vendas = new Form_Consulta_Vendas();
            form_Consulta_Vendas.Show();
            
        }
        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Metodos do formulário
        private async void UpdateDatagridView()
        {
            try
            {
                var result = await _service.GetAll();
                int i = 0;
                dataGrid_Estoque.Rows.Clear();
                foreach (var produto in result)
                {
                    dataGrid_Estoque.Rows.Add();
                    dataGrid_Estoque.Rows[i].Cells[0].Value = produto.Id;
                    dataGrid_Estoque.Rows[i].Cells[1].Value = produto.Nome;
                    dataGrid_Estoque.Rows[i].Cells[2].Value = produto.Valor;
                    dataGrid_Estoque.Rows[i].Cells[3].Value = produto.Quantidade;

                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao baixar a lista de produtos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar atualizar itens na gridView");
            }
            finally
            {
                txt_Codigo.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }
        private async void btn_Consultar_Click(object sender, EventArgs e)
        {
            var produto = txt_Produto.Text;
            try
            {
                var result = await _service.SelectByName(produto);


                if (result != null)
                {
                    dataGrid_Estoque.Rows.Clear();
                    dataGrid_Estoque.Rows[0].Cells[0].Value = result.Id;
                    dataGrid_Estoque.Rows[0].Cells[1].Value = result.Nome;
                    dataGrid_Estoque.Rows[0].Cells[2].Value = result.Valor;
                    dataGrid_Estoque.Rows[0].Cells[3].Value = result.Quantidade;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao encontrar o produto", "Erro de busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar encontrar o produto");
            }
            txt_Codigo.Text = "";
            txt_Produto.Text = "";
            txt_Valor.Text = "";
            txt_Quantidade.Text = "";
        }

        private async void btn_Deletar_Click(object sender, EventArgs e)
        {

            try
            {
                var id = int.Parse(dataGrid_Estoque.SelectedRows[0].Cells[0].Value.ToString());
                var result = await _service.Delete(id);
                if (result == true)
                {
                    MessageBox.Show("Produto deletado com sucesso !", "Produto Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdateDatagridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir um produto do Estoque ", "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar excluir um produto do estoque");
            }
            finally
            {
                txt_Codigo.Text = "";
                txt_Produto.Text = "";
                txt_Valor.Text = "";
                txt_Quantidade.Text = "";
            }
        }

        private void dgv_Estoque_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_Codigo.Text = dataGrid_Estoque.SelectedRows[0].Cells[0].Value.ToString();
                txt_Produto.Text = dataGrid_Estoque.SelectedRows[0].Cells[1].Value.ToString();
                txt_Valor.Text = dataGrid_Estoque.SelectedRows[0].Cells[2].Value.ToString();
                txt_Quantidade.Text = dataGrid_Estoque.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar capturar os dados do produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar capturar dados dos produtos na grid para os campos na tela");
            }
        }

        private async void btn_Editar_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txt_Codigo.Text);
            var nome = txt_Produto.Text;
            var valor = double.Parse(txt_Valor.Text);
            var quantidade = int.Parse(txt_Quantidade.Text);
            var produto = new Produto()
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
                }
                UpdateDatagridView();
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

        private async void Form_Estoque_Load(object sender, EventArgs e)
        {
            try
            {

                var result = await _service.GetAll();

                int i = 0;

                foreach (var produto in result)
                {
                    dataGrid_Estoque.Rows.Add();
                    dataGrid_Estoque.Rows[i].Cells[0].Value = produto.Id;
                    dataGrid_Estoque.Rows[i].Cells[1].Value = produto.Nome;
                    dataGrid_Estoque.Rows[i].Cells[2].Value = produto.Valor;
                    dataGrid_Estoque.Rows[i].Cells[3].Value = produto.Quantidade;

                    i++;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao baixar a lista de produtos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar baixar a lista de produtos");
            }
        }

        private void btn_Atualizar_Click(object sender, EventArgs e)
        {
            UpdateDatagridView();
        }
        #endregion
    }
}
