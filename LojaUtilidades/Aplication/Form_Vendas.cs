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
        private int largura = 0;
        private int altura = 0;
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;
        private readonly IITemVendaService _itemService;
        public Form_Vendas()
        {
            InitializeComponent();
            _produtoService = new ProdutoService();
            _vendaService = new VendasService();
            _itemService = new ItemsVendasService();
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
        #endregion

        private async void btn_Consultar_Click(object sender, EventArgs e)
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
            try
            {
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
            int quantidade;
            double valor;
            double Total = 0;
            for(int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
            {
                valor = Convert.ToDouble(dgv_Vendas.Rows[x].Cells[2].Value.ToString());
                quantidade = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value.ToString());
                Total += (valor * quantidade);
            }
            txt_Total.Text = Total.ToString("C2");
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            dgv_Vendas.Rows.Clear();
            txt_Total.Text = "";
            i = 0;
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
           
            if(!string.IsNullOrEmpty(txt_Total.Text))
            {
                var total = Convert.ToDouble(txt_Total.Text.Trim('R', '$'));
                var itemExcluido = Convert.ToDouble(dgv_Vendas.SelectedRows[0].Cells[2].Value.ToString());
                var itemExcluidoQtd = Convert.ToInt32(dgv_Vendas.SelectedRows[0].Cells[3].Value.ToString());
                var valorFinal = total - (itemExcluido * itemExcluidoQtd);
                txt_Total.Text = valorFinal.ToString("C2");
                dgv_Vendas.Rows.Remove(dgv_Vendas.SelectedRows[0]);
            }
            else if(string.IsNullOrEmpty(txt_Total.Text))
            {
                MessageBox.Show("Por favor calcule o valor total da venda antes !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_Finalizar_Venda_Click(object sender, EventArgs e)
        {
            var itemVenda = new ItemVendaEntity();
            Random rd = new Random();
            if (txt_Total.Text == "")
            {
                MessageBox.Show("Calcule o valor total da venda !", "Venda error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            VendaEntity vendaObj = new VendaEntity()
            {
                Id = rd.Next(1000), 
                Data_da_Venda = DateTime.Now,
                Valor = double.Parse(txt_Total.Text.Trim('R', '$')),
                Hora_Venda = DateTime.Now.TimeOfDay,
            };

            await _vendaService.PostAsync(vendaObj);
            try
            {
                
                for(int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
                {
                    var result = await _produtoService.Get(Convert.ToInt32(dgv_Vendas.Rows[x].Cells[0].Value));
                    int quantidadeDgv = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value);
                    var quantidade = result.Quantidade - quantidadeDgv;
                    result.Quantidade = quantidade;
                    await _produtoService.Put(result);

                    itemVenda.Id = rd.Next(1000);
                    itemVenda.ProdutoId = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[0].Value);
                    itemVenda.Quantidade = quantidadeDgv;
                    itemVenda.VendaId = vendaObj.Id;
                    await _itemService.Post(itemVenda);




                }
                
                MessageBox.Show($"Venda Finalizada com Sucesso ! ", "Venda Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar a venda {ex.Message} !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
             X = printDocument1.DefaultPageSettings.Bounds.X;
             Y = printDocument1.DefaultPageSettings.Bounds.Y;
             largura = printDocument1.DefaultPageSettings.Bounds.Width;
             altura = printDocument1.DefaultPageSettings.Bounds.Height;
            printDialog1.Document = printDocument1;


            if (printDialog1.ShowDialog() != DialogResult.Cancel)
            {
                largura = printDocument1.DefaultPageSettings.Bounds.Width;
                altura = printDocument1.DefaultPageSettings.Bounds.Height;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region declaração de variaveis
            ProdutoEntity produto = new ProdutoEntity();
            // VARIAEIS DO TITULO
            string Titulo = "Loja Utilidade e Cosmeticos Dias";
            string Subtitulo = "Cnpj: 29.936.014/0001-01";
            Font LetraTitulo = new Font("Calibri", 32, FontStyle.Bold, GraphicsUnit.Point);
            Font LetraSubtitulo = new Font("Calibri", 26, FontStyle.Regular, GraphicsUnit.Point);
            Brush PincelPreto = new SolidBrush(Color.Black);

            //// VARIAVEIS PARA IMPRIMIR OS PRODUTOS
            List<ProdutoEntity> produtoImprimir = new List<ProdutoEntity>();
            Font LetraProdutos = new Font("Arial", 16, FontStyle.Regular, GraphicsUnit.Point);
            StringFormat formatoTitulo = new StringFormat();
            formatoTitulo.Alignment = StringAlignment.Far;
            formatoTitulo.LineAlignment = StringAlignment.Far;
            int index = 60;
            int index2 = 300;
            #endregion

            #region inserindo titulo e subtitulo na pagina
            e.Graphics.DrawString(Titulo, LetraTitulo, PincelPreto, X + 100, Y + 50);
            e.Graphics.DrawString(Subtitulo, LetraSubtitulo, PincelPreto, X + 100, Y + 100);
            #endregion


            #region Desenhando cabeçalho
            e.Graphics.DrawString("Produto".PadRight(35) + "Valor".PadRight(30) + "Quantidade", LetraProdutos, PincelPreto, X + index, Y + 200);
            #endregion

            #region Desenhando os produtos
            for (int contador = 0; contador <= dgv_Vendas.Rows.Count - 2; contador++)
            {
                if (dgv_Vendas.Rows[contador] == null)
                {
                    MessageBox.Show("Insira um produto na tabela de vendas", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //ATRIBUINDO A UM OBJ OS DADOS DA GRID
                produto.Nome = dgv_Vendas.Rows[contador].Cells[1].Value.ToString();
                produto.Valor = Convert.ToDouble(dgv_Vendas.Rows.SharedRow(contador).Cells[2].Value.ToString());
                produto.Quantidade = Convert.ToInt32(dgv_Vendas.Rows.SharedRow(contador).Cells[3].Value.ToString());
                produtoImprimir.Add(produto);


                e.Graphics.DrawString(produtoImprimir[contador].Nome.ToString().PadRight(40) + produtoImprimir[contador].Valor.ToString("C2").PadRight(40) + produtoImprimir[contador].Quantidade.ToString().PadRight(25), LetraProdutos, PincelPreto, X + index, Y + index2);
                index2 += 90;

            }

            if (string.IsNullOrEmpty(txt_Total.Text) || txt_Total.Text == "0")
            {
                MessageBox.Show("Calcule o Valor total da venda", "Erro calculo do total da venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printPreviewDialog1.Close();
            }
            else
            {
                double total = double.Parse(txt_Total.Text.Trim('R', '$'));
                e.Graphics.DrawString("Total: " + total.ToString("C2"), LetraProdutos, PincelPreto, X + index, Y + index2);
            }
            #endregion


        }
    }
}
