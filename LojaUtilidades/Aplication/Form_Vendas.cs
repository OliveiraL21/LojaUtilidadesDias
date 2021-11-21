using Data.Context;
using Data.Repositorios;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
using Domain.Interfaces.Services.Venda;
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
        public int i = 0;
        public int X = 0;
        public int Y = 0;
        public int largura = 0;
        public int altura = 0;
        public double Total = 0;
        private readonly ItemVendaEntity item;
        private readonly VendaEntity venda;
        private readonly IProdutoService _service;
        private readonly IVendaService _vendaService;
        public Form_Vendas()
        {
            InitializeComponent();
            _service = new ProdutoService();
            _vendaService = new VendasService();
            item = new ItemVendaEntity();
            venda = new VendaEntity();
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
                MessageBox.Show("digite o nome de um produto e/ou sua quantidade de venda!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var nome = txt_Produto.Text;
            var quantidade = int.Parse(txt_Quantidade.Text);
            try
            {
                var result = await _service.SelectByName(nome);
                if(result != null)
                {
                    dgv_Vendas.Rows.Add();
                    dgv_Vendas.Rows[i].Cells[0].Value = result.Id;
                    dgv_Vendas.Rows[i].Cells[1].Value = result.Nome;
                    dgv_Vendas.Rows[i].Cells[2].Value = result.Valor.ToString();
                    dgv_Vendas.Rows[i].Cells[3].Value = quantidade;
                    i++;


                    item.Quantidade = quantidade;
                    item.Produto = result;
                    item.ProdutoId = result.Id;


                   venda.Data_da_Venda = DateTime.Today;
                   venda.Hora_Venda = DateTime.Today.TimeOfDay;
                   venda.ItemVendaId = item.Id;
                   venda.ItensVenda.Append(item);

               
                    
                   
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
            for(int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
            {
                valor = Convert.ToDouble(dgv_Vendas.Rows[x].Cells[2].Value.ToString());
                quantidade = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value.ToString());
                Total = Total + (valor * quantidade);
            }
            txt_Total.Text = Total.ToString();
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            dgv_Vendas.Rows.Clear();
            txt_Total.Text = "";
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
           
            if(!string.IsNullOrEmpty(txt_Total.Text))
            {
                var total = Convert.ToDouble(txt_Total.Text);
                var itemExcluido = Convert.ToDouble(dgv_Vendas.SelectedRows[0].Cells[2].Value.ToString());
                var itemExcluidoQtd = Convert.ToInt32(dgv_Vendas.SelectedRows[0].Cells[3].Value.ToString());
                var valorFinal = total - (itemExcluido * itemExcluidoQtd);
                txt_Total.Text = valorFinal.ToString();
                dgv_Vendas.Rows.Remove(dgv_Vendas.SelectedRows[0]);
            }
            else if(string.IsNullOrEmpty(txt_Total.Text))
            {
                MessageBox.Show("Por favor calcule o valor total da venda antes !", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_Finalizar_Venda_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                for(int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
                {
                    var result = await _service.Get(Convert.ToInt32(dgv_Vendas.Rows[x].Cells[0].Value));
                    var quantidade = result.Quantidade - Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value);
                    result.Quantidade = quantidade;
                    await _service.Put(result);
                }
                venda.Valor = double.Parse(txt_Total.Text);
                var vendaResult = await _vendaService.PostAsync(venda);
                MessageBox.Show($"Venda Finalizada com Sucesso ! {vendaResult.Hora_Venda.ToString()} {vendaResult.ItensVenda.ToList().ToString()}", "Venda Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ProdutoEntity produto = new ProdutoEntity();
            // declaração das variaveis
            string Titulo = "Loja Utilidade e Cosmeticos Dias";
            string Subtitulo = "Cnpj: 29.936.014/0001-01";
            Font LetraTitulo = new Font("Calibri", 32, FontStyle.Bold, GraphicsUnit.Point);
            Font LetraSubtitulo = new Font("Calibri", 26, FontStyle.Regular, GraphicsUnit.Point);
            Brush PincelPreto = new SolidBrush(Color.Black);


            List<ProdutoEntity> produtoImprimir = new List<ProdutoEntity>();
            Font LetraProdutos = new Font("Arial", 16, FontStyle.Regular, GraphicsUnit.Point);
            StringFormat formatoTitulo = new StringFormat();
            formatoTitulo.Alignment = StringAlignment.Far;
            formatoTitulo.LineAlignment = StringAlignment.Far;

            //inserindo titulo e cabeçalho
            e.Graphics.DrawString(Titulo, LetraTitulo, PincelPreto, X + 100, Y + 50);
            e.Graphics.DrawString(Subtitulo, LetraSubtitulo, PincelPreto, X + 100, Y + 100);

            // variaveis de index
            int index = 100;
            int index2 = 300;

            //desenhando cabeçalho
            e.Graphics.DrawString("Produto".PadRight(30) + "Valor".PadRight(30) + "Quantidade", LetraProdutos, PincelPreto, X + index, Y + 200);

            //Desenhando Produtos
            for (int x = 0; x < dgv_Vendas.Rows.Count - 1; x++)
            {
                if (dgv_Vendas.Rows[x] == null || dgv_Vendas.Rows[x].Cells[x].Value == null)
                {
                    MessageBox.Show("Insira um produto na tabela de vendas", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //ATRIBUINDO A UM OBJ OS DADOS DA GRID
                produto.Nome = dgv_Vendas.Rows.SharedRow(x).Cells[1].Value.ToString();
                produto.Valor = Convert.ToDouble(dgv_Vendas.Rows.SharedRow(x).Cells[2].Value.ToString());
                produto.Quantidade = Convert.ToInt32(dgv_Vendas.Rows.SharedRow(x).Cells[3].Value.ToString());
                produtoImprimir.Add(produto);


                e.Graphics.DrawString(produtoImprimir[x].Nome.ToString().PadRight(30) + produtoImprimir[x].Valor.ToString("C2").PadRight(30) + produtoImprimir[x].Quantidade.ToString().PadRight(30), LetraProdutos, PincelPreto, X + index, Y + index2);
                index2 += 100;

            }

            if (string.IsNullOrEmpty(txt_Total.Text) || txt_Total.Text == "0")
            {
                MessageBox.Show("Calcule o Valor total da venda", "Erro calculo do total da venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printPreviewDialog1.Close();
            }
            else
            {
                double total = double.Parse(txt_Total.Text);
                e.Graphics.DrawString("Total: " + total.ToString("C2"), LetraProdutos, PincelPreto, X + index, Y + index2);
            }
        }
    }
}
