﻿using Aplication.Impressão;
using Data.Context;
using Data.Repositorios;
using Domain.Entidades;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Produtos;
using Domain.Interfaces.Services.Venda;
using Service.Services.ItensVendas;
using Service.Services.Produtos;
using Service.Services.Venda;
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
        private int i = 0;
        private int X = 0;
        private int Y = 0;
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;
        private readonly IITemVendaService _itemService;
        private readonly MyContext _context;
        public Form_Vendas()
        {
            InitializeComponent();
            _produtoService = new ProdutoService();
            _vendaService = new VendasService();
            _itemService = new ItemsVendasService();
            _context = new MyContext();
        }
        #region Front-End
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
            Close();
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();
           
        }

        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas consulta_Vendas = new Form_Consulta_Vendas();
            consulta_Vendas.ShowDialog();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Vendas já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private List<ProdutoEntity> GetProdutoGrid()
        {
            try
            {
                List<ProdutoEntity> produtos = new List<ProdutoEntity>();

                for (int contador = 0; contador < dgv_Vendas.Rows.Count; contador++)
                {
                    var produto = new ProdutoEntity()
                    {
                        Id = Convert.ToInt32(dgv_Vendas.Rows[contador].Cells[0].Value),
                        Nome = dgv_Vendas.Rows[contador].Cells[1].Value.ToString(),
                        Valor = Convert.ToDouble(dgv_Vendas.Rows[contador].Cells[2].Value),
                        Quantidade = Convert.ToInt32(dgv_Vendas.Rows[contador].Cells[3].Value)
                    };
                    produtos.Add(produto);
                }
                return produtos;
            }
            catch
            {
                throw;
            }
        }
        private async void btn_Consultar_Click(object sender, EventArgs e)
        {
         
            try
            {

                if (string.IsNullOrEmpty(txt_Produto.Text))
                {
                    MessageBox.Show("digite o nome de um produto !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (string.IsNullOrEmpty(txt_Quantidade.Text))
                {
                    MessageBox.Show("Digite quantos produtos serão vendidos !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var nome = txt_Produto.Text;
                var quantidade = int.Parse(txt_Quantidade.Text);


                var result = await _produtoService.SelectByName(nome);
                if(result != null)
                {
                    dgv_Vendas.Rows.Add();
                    dgv_Vendas.Rows[i].Cells[0].Value = result.Id;
                    dgv_Vendas.Rows[i].Cells[1].Value = result.Nome;
                    dgv_Vendas.Rows[i].Cells[2].Value = result.Valor.ToString();
                    dgv_Vendas.Rows[i].Cells[3].Value = quantidade;
                    i++;

                }
                else
                {
                    MessageBox.Show("Produto não encontrado !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Produto não encontrado ! {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txt_Produto.Text = "";
                txt_Quantidade.Text = "";
                
            }
        }

        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                int quantidade;
                double valor;
                double Total = 0;
                for (int x = 0; x < dgv_Vendas.Rows.Count; x++)
                {
                    valor = Convert.ToDouble(dgv_Vendas.Rows[x].Cells[2].Value.ToString());
                    quantidade = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value.ToString());
                    Total += (valor * quantidade);
                }
                txt_Total.Text = Total.ToString("C2");
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Vendas.Rows.Clear();
                txt_Total.Text = "";
                i = 0;
            }
            catch
            {
                throw;
            }
           
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Total.Text))
                {
                    var total = Convert.ToDouble(txt_Total.Text.Trim('R', '$'));
                    var itemExcluido = Convert.ToDouble(dgv_Vendas.SelectedRows[0].Cells[2].Value.ToString());
                    var itemExcluidoQtd = Convert.ToInt32(dgv_Vendas.SelectedRows[0].Cells[3].Value.ToString());
                    var valorFinal = total - (itemExcluido * itemExcluidoQtd);
                    txt_Total.Text = valorFinal.ToString("C2");
                    i = dgv_Vendas.SelectedRows[0].Index;
                    dgv_Vendas.Rows.Remove(dgv_Vendas.SelectedRows[0]);
                }
                else if (string.IsNullOrEmpty(txt_Total.Text))
                {
                    MessageBox.Show("Por favor calcule o valor total da venda antes !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
        }

        private async void btn_Finalizar_Venda_Click(object sender, EventArgs e)
        {
            List<ItemVendaEntity> listItens = new List<ItemVendaEntity>();
            if (txt_Total.Text == "")
            {
                MessageBox.Show("Calcule o valor total da venda !", "Venda error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                VendaEntity vendaObj = new VendaEntity()
                {

                    Data_da_Venda = DateTime.Now.Date,
                    Valor = double.Parse(txt_Total.Text.Trim('R', '$')),
                    Hora_Venda = DateTime.Now.TimeOfDay,
                };

                var venda = await _vendaService.PostAsync(vendaObj);
                try
                {

                    for (int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
                    {
                        var result = await _produtoService.Get(Convert.ToInt32(dgv_Vendas.Rows[x].Cells[0].Value));
                        int quantidadeDgv = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value);
                        var quantidade = result.Quantidade - quantidadeDgv;
                        result.Quantidade = quantidade;
                        await _produtoService.Put(result);


                        listItens.Add(new ItemVendaEntity()
                        {
                            ProdutoId = result.Id,
                            Produto = result,
                            VendaId = venda.Id,
                            Venda = venda,
                            Quantidade = quantidadeDgv
                        });
                    }
                    _context.ItensVendas.AttachRange(listItens);
                    _context.ItensVendas.AddRange(listItens);
                    _context.SaveChanges();

                    MessageBox.Show($"Venda Finalizada com Sucesso ! ", "Venda Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao finalizar a venda {ex.InnerException.Message} !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    txt_Produto.Text = "";
                    txt_Quantidade.Text = "";
                    txt_Total.Text = "";
                    dgv_Vendas.Rows.Clear();
                    i = 0;


                }
            }
           
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int largura = printDocument1.DefaultPageSettings.Bounds.Width;
                int altura = printDocument1.DefaultPageSettings.Bounds.Width;

                X = printDocument1.DefaultPageSettings.Bounds.X;
                Y = printDocument1.DefaultPageSettings.Bounds.Y;
                printDialog1.Document = printDocument1;


                if (printDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    largura = printDocument1.DefaultPageSettings.Bounds.Width;
                    altura = printDocument1.DefaultPageSettings.Bounds.Height;
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();

                }
            }
            catch
            {
                throw;
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                List<ProdutoEntity> produtos = new List<ProdutoEntity>();
                Print print = new Print();
                produtos = GetProdutoGrid();
                var total = txt_Total.Text.Trim('R').Trim('$');
                print.ImprimirVenda(produtos, Convert.ToDouble(total), sender, e);
            }
            catch
            {
                throw;
            }
         
            
        }

        private void Form_Vendas_Load(object sender, EventArgs e)
        {

        }
    }
}
