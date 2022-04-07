using Aplication.Impressão;
using Data.Context;
using Data.Repositorios;
using Domain.Entidades;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Produtos;
using Domain.Interfaces.Services.Venda;
using Serilog;
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
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;
        private readonly IITemVendaService _itemService;
        private readonly MyContext _context;
        private  Venda _venda;
        private readonly string Path;

        public Form_Vendas()
        {
            InitializeComponent();
            _produtoService = new ProdutoService();
            _vendaService = new VendasService();
            _itemService = new ItemsVendasService();
            _context = new MyContext();
            _venda = new Venda();
            Path = Application.StartupPath + @"\Logs\Tela-de-Vendas-.txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(Path, rollingInterval: RollingInterval.Day)
                .CreateLogger();
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
            form_Produtos.Show();
           
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
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.Show();

        }

        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas consulta_Vendas = new Form_Consulta_Vendas();
            consulta_Vendas.Show();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O formulário de Vendas já está aberto", "Formulario já aberto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Funções Gerais
        private List<Produto> GetProdutoGrid()
        {

            try
            {
                List<Produto> produtos = new List<Produto>();
                for (int contador = 0; contador < dgv_Vendas.Rows.Count; contador++)
                {
                    var produto = new Produto()
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error ao tentar carregar a lista de produtos para impresão", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex.InnerException, "\nErro ao tentear carregar a lista de produtos para impressão");
                throw;
            }

        }
        private double CalcularTotal()
        {
            int quantidade = 0;
            double valor = 0;
            double total = 0;
            for (int x = 0; x < dgv_Vendas.Rows.Count; x++)
            {
                valor = Convert.ToDouble(dgv_Vendas.Rows[x].Cells[2].Value.ToString());
                quantidade = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value.ToString());
                total += (valor * quantidade);
            }
            return total;
        }
        private double CalcularTotal(double desconto)
        {
            int quantidade = 0;
            double valor = 0;
            double valorDesconto = 0;
            double total = 0;
            for (int x = 0; x < dgv_Vendas.Rows.Count; x++)
            {
                valor = Convert.ToDouble(dgv_Vendas.Rows[x].Cells[2].Value.ToString());
                quantidade = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value.ToString());
                total += (valor * quantidade);
            }
            valorDesconto = total * (desconto / 100);
            return total - valorDesconto;
        }
        private void LimparCampos()
        {
            txt_Produto.Text = "";
            txt_Quantidade.Text = "";
            txt_Desconto.Text = "";
            txt_Total.Text = "";
            dgv_Vendas.Rows.Clear();
            i = 0;
        }
        #endregion
        #region Metodos do formulário
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

                dgv_Vendas.Rows.Add();
                dgv_Vendas.Rows[i].Cells[0].Value = result.Id;
                dgv_Vendas.Rows[i].Cells[1].Value = result.Nome;
                dgv_Vendas.Rows[i].Cells[2].Value = result.Valor.ToString();
                dgv_Vendas.Rows[i].Cells[3].Value = quantidade;
                i++;



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar produtos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar buscar pordutos e adicionar na grid de vendas");
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
                double total = 0;
                if (checkBox_Desconto.Checked)
                {
                    total = CalcularTotal(Convert.ToDouble(txt_Desconto.Text));
                }
                else
                {

                    total = CalcularTotal();
                }

                txt_Total.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ao tentar calcular valor total da venda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar calcular o valor total da venda");

            }

        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ao tentar Limpar a tabela de vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar limpar a tabela de vendas");
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar produto da tabela", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar deletar produto da tabela");
            }
        }

        private async void btn_Finalizar_Venda_Click(object sender, EventArgs e)
        {
            List<ItemVenda> listItens = new List<ItemVenda>();
            if (txt_Total.Text == "")
            {
                MessageBox.Show("Calcule o valor total da venda !", "Venda error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    Venda vendaObj = new Venda()
                    {
                        Data = DateTime.Now.Date,
                        Valor = double.Parse(txt_Total.Text.Trim('R', '$')),
                        Hora = DateTime.Now.TimeOfDay,
                    };

                    var venda = await _vendaService.Insert(vendaObj);

                    for (int x = 0; x < dgv_Vendas.Rows.Count; x++)
                    {
                        var result = await _produtoService.GetProduto(Convert.ToInt32(dgv_Vendas.Rows[x].Cells[0].Value));
                        int quantidadeDgv = Convert.ToInt32(dgv_Vendas.Rows[x].Cells[3].Value);
                        var quantidade = result.Quantidade - quantidadeDgv;
                        result.Quantidade = quantidade;
                        await _produtoService.Update(result);


                        listItens.Add(new ItemVenda()
                        {
                            ProdutoId = result.Id,
                            Produto = result,
                            VendaId = venda.Id,
                            Venda = venda,
                            Quantidade = quantidadeDgv
                        });
                    }
                    _venda = venda;
                    _context.ItensVendas.AttachRange(listItens);
                    _context.ItensVendas.AddRange(listItens);
                    _context.SaveChanges();

                    
                    if(MessageBox.Show($"Venda Finalizada com Sucesso\n deseja imprimir o comprovante da venda ?", "Venda Finalizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        btn_Imprimir_Click(sender, e);
                    }
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao finalizar a venda!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(ex, "\nErro ao finalizar a venda!");

                }
                finally
                {
                    LimparCampos();
                }
            }

        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int largura = printDocument1.DefaultPageSettings.Bounds.Width;
                int altura = printDocument1.DefaultPageSettings.Bounds.Width;


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
                List<Produto> produtos;
                Print print = new Print();
                produtos = GetProdutoGrid();
                var total = txt_Total.Text.Trim('R').Trim('$');
                print.ImprimirVenda(_venda, produtos, Convert.ToDouble(total), sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar Imprimir os dados da venda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar imprimir os dados da venda");
            }


        }
        private void checkBox_Desconto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Desconto.Checked)
            {
                label_Desconto.Visible = true;
                txt_Desconto.Visible = true;
                label_Porcentagem.Visible = true;
            }
            else
            {
                label_Desconto.Visible = false;
                txt_Desconto.Visible = false;
                label_Porcentagem.Visible = false;
                txt_Desconto.Text = "";
            }

        }
        #endregion

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
