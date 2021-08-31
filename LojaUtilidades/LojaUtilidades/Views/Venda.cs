using LojaUtilidades.Control;
using LojaUtilidades.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaUtilidades.Views
{
    public partial class Venda : Form
    {
        float x;
        float y;
        float Largura;
        float Altura;
        Produto produto;
        double ValorVendaFinal = 0;
        public Venda()
        {
            InitializeComponent();
            produto = new Produto();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = txtProduto.Text;
            if (nome == "" || nome == null)
            {
                MessageBox.Show("Digite o nome do produto", "Erro Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow linha in produto.ConsultaVenda(nome).Rows)
                {
                    ListaDeProdutosVenda.Rows.Add(linha.ItemArray);

                }
                txtProduto.Text = "";
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ListaDeProdutosVenda.Rows.Clear();
            txtProduto.Text = "";
            txtValorFinal.Text = "";
            ValorVendaFinal = 0;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

            if (ListaDeProdutosVenda.Rows.Count == 0)
            {
                txtValorFinal.Text = "";
                ValorVendaFinal = 0;
            }
            else
            {
                double Valor = Convert.ToDouble(ListaDeProdutosVenda.SelectedRows[0].Cells[1].Value);
                double result = double.Parse(txtValorFinal.Text);
                int quantidade = Convert.ToInt32(ListaDeProdutosVenda.SelectedRows[0].Cells[2].Value);
                result = result - (Valor * quantidade);
                txtValorFinal.Text = result.ToString();
                ListaDeProdutosVenda.Rows.Remove(ListaDeProdutosVenda.SelectedRows[0]);



            }


        }

        private void CalcularPreco()
        {
            double preco;
            int quantidade;
            try
            {
                for (int i = 0; i < ListaDeProdutosVenda.Rows.Count; i++)
                {
                    preco = Convert.ToDouble(ListaDeProdutosVenda.Rows[i].Cells[1].Value);
                    quantidade = Convert.ToInt32(ListaDeProdutosVenda.Rows[i].Cells[2].Value);
                    ValorVendaFinal = ValorVendaFinal + (preco * quantidade);
                }
            }
            catch
            {

            }
            finally
            {
                txtValorFinal.Text = ValorVendaFinal.ToString();
            }

        }

        private void btnConfirmarVenda_Click(object sender, EventArgs e)
        {
            CalcularPreco();
            ValorVendaFinal = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            x = printDocument1.DefaultPageSettings.Bounds.X;
            y = printDocument1.DefaultPageSettings.Bounds.Y;
            Largura = printDocument1.DefaultPageSettings.Bounds.Width;
            Altura = printDocument1.DefaultPageSettings.Bounds.Height;
            printDialog1.Document = printDocument1;
  

            if (printDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Largura = printDocument1.DefaultPageSettings.Bounds.Width;
                Altura = printDocument1.DefaultPageSettings.Bounds.Height;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
               
            }
         
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // declaração das variaveis
            string Titulo = "Loja Utilidade e Cosmeticos Dias";
            string Subtitulo = "Cnpj: 29.936.014/0001-01";
            Font LetraTitulo = new Font("Calibri", 32, FontStyle.Bold, GraphicsUnit.Point);
            Font LetraSubtitulo = new Font("Calibri", 26, FontStyle.Regular, GraphicsUnit.Point);
            Brush PincelPreto = new SolidBrush(Color.Black);
            List<Produto> produtoImprimir = new List<Produto>();
            Font LetraProdutos = new Font("Arial", 16, FontStyle.Regular, GraphicsUnit.Point);
            StringFormat formatoTitulo = new StringFormat();
            formatoTitulo.Alignment = StringAlignment.Far;
            formatoTitulo.LineAlignment = StringAlignment.Far;

            //inserindo titulo e cabeçalho
            e.Graphics.DrawString(Titulo, LetraTitulo, PincelPreto, x + 100, y + 50);
            e.Graphics.DrawString(Subtitulo, LetraSubtitulo, PincelPreto, x + 100, y + 100);

            // variaveis de index
            int index = 100;
            int index2 = 300;

            //desenhando cabeçalho
            e.Graphics.DrawString("Produto".PadRight(30) + "Valor".PadRight(30) + "Quantidade", LetraProdutos, PincelPreto, x + index, y + 200);

            //Desenhando Produtos
            for (int i = 0; i < ListaDeProdutosVenda.Rows.Count - 1; i++)
            {
                if (ListaDeProdutosVenda.Rows[i] == null || ListaDeProdutosVenda.Rows[i].Cells[i].Value == null)
                {
                    MessageBox.Show("Insira um produto na tabela de vendas", "Erro Vendas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                produto.Nome = ListaDeProdutosVenda.Rows.SharedRow(i).Cells[0].Value.ToString();
                produto.Valor = Convert.ToDouble(ListaDeProdutosVenda.Rows.SharedRow(i).Cells[1].Value.ToString());
                produto.Quantidade = Convert.ToInt32(ListaDeProdutosVenda.Rows.SharedRow(i).Cells[2].Value.ToString());
                produtoImprimir.Add(produto);
                e.Graphics.DrawString(produtoImprimir[i].Nome.ToString().PadRight(30) + produtoImprimir[i].Valor.ToString("C2").PadRight(30) + produtoImprimir[i].Quantidade.ToString().PadRight(30), LetraProdutos, PincelPreto, x + index, y + index2);
                index2 += 100;

            }

            if (txtValorFinal.Text == "" || txtValorFinal.Text == null || txtValorFinal.Text == "0")
            {
                MessageBox.Show("Calcule o Valor total da venda", "Erro calculo do total da venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printPreviewDialog1.Close();
            }
            else
            {
                double total = double.Parse(txtValorFinal.Text);
                e.Graphics.DrawString("Total: " + total.ToString("C2"), LetraProdutos, PincelPreto, x + index, y + index2);
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= ListaDeProdutosVenda.Rows.Count; i++)
            {
                try
                {
                    if (ListaDeProdutosVenda.Rows[i].Cells[0].Value == null || ListaDeProdutosVenda.Rows == null || ListaDeProdutosVenda.Rows.Count == 0)
                    {
                        MessageBox.Show("Insira os produtos na tabela", "Erro tabela vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    int quantidade = Convert.ToInt32(ListaDeProdutosVenda.Rows[i].Cells[2].Value);
                    string nome = ListaDeProdutosVenda.Rows[i].Cells[0].Value.ToString();
                    produto.EditarQuantidade(nome, quantidade);
                    MessageBox.Show("Venda Finalizada com sucesso !", "Finalizar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                }
                ListaDeProdutosVenda.Rows.Clear();
                txtProduto.Text = "";
                txtValorFinal.Text = "";
            }
        }
    }
}







