using Domain.Entidades;
using Domain.Interfaces.Services.Venda;
using Serilog;
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
    public partial class Form_Consulta_Vendas : Form
    {
        private readonly IVendaService _vendaService;
        private readonly string Path;
        private FilterEntity _filter;
        public Form_Consulta_Vendas()
        {
            InitializeComponent();
            _vendaService = new VendasService();
            _filter = new FilterEntity();
            Path = Application.StartupPath + @"\Logs\Tela-Consultar-Vendas-.txt";
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
            Form_Produtos form_Produtos = new();
            form_Produtos.Show();
            
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.Show();
            

        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas formVenda = new Form_Vendas();
            formVenda.Show();
            
        }
        private void btn_Estoque_Vendas_Click_(object sender, EventArgs e)
        {
            MessageBox.Show("A pagina de Consulta de vendas já está aberta !", "Janela ja aberta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Metodos do formulário

        private void DataGridViewFill(IEnumerable<Venda> vendas)
        {
            try
            {
                dgv_Vendas_Consulta.Rows.Clear();
                int index = 0;

                foreach (var Venda in vendas)
                {

                    foreach (var item in Venda.ItensVenda)
                    {
                        dgv_Vendas_Consulta.Rows.Add();
                        dgv_Vendas_Consulta.Rows[index].Cells[0].Value = Venda.NumeroVenda;
                        dgv_Vendas_Consulta.Rows[index].Cells[1].Value = item.Produto.Nome;
                        dgv_Vendas_Consulta.Rows[index].Cells[2].Value = item.Quantidade;
                        dgv_Vendas_Consulta.Rows[index].Cells[3].Value = Venda.Valor;
                        dgv_Vendas_Consulta.Rows[index].Cells[4].Value = Venda.Data_da_Venda.ToString("dd/MM/yyyy");
                        dgv_Vendas_Consulta.Rows[index].Cells[5].Value = Venda.Hora_Venda.ToString(@"hh\:mm");
                        index++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar preencher a tabela", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar preencher o datagridview");
            }
           
        }
        private int SetMonth(string month)
        {
            var mes = 0;
            switch (month)
            {
                case "Janeiro":
                     mes = 01;
                    break;
                case "Fevereiro":
                    mes = 02;
                    break;
                case "Março":
                    mes = 03;
                    break;
                case "Abril":
                    mes = 04;
                    break;
                case "Maio":
                    mes = 05;
                    break;
                case "Junho":
                    mes = 06;
                    break;
                case "Julho":
                    mes = 07;
                    break;
                case "Agosto":
                    mes = 08;
                    break;
                case "Setembro":
                    mes = 09;
                    break;
                case "Outubro":
                    mes = 10;
                    break;
                case "Novembro":
                    mes = 11;
                    break;
                case "Dezembro":
                    mes = 12;
                    break;
            }
            return mes;
        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                DatagridViewClear();
                IEnumerable<Venda> vendas = _vendaService.GetVendas();
                DataGridViewFill(vendas);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar buscar as vendas no banco de dados");
            }

        }
        private void DatagridViewClear()
        {
            dgv_Vendas_Consulta.Rows.Clear();
        }
       private void LimparCampos()
        { 
            dgv_Vendas_Consulta.Rows.Clear();
            txt_Codigo.Text = "";
            txt_Data_Venda.Text = "";
            txt_Produto.Text = "";
            comboBox1.Text = "";
            comboBox1.SelectedItem = "";
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Data_Venda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                DatagridViewClear();
                Venda venda = new Venda();
                if (string.IsNullOrEmpty(txt_Data_Venda.Text) && string.IsNullOrEmpty(txt_Codigo.Text) && comboBox1.SelectedItem == null && string.IsNullOrEmpty(txt_Produto.Text))
                {
                    _filter.CodigoVenda = null;
                    _filter.DataDaVenda = null;
                    _filter.Mes = null;
                    MessageBox.Show("Informe pelo menos um dos filtros para continuar com a consulta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             

                if (txt_Data_Venda.Text != "")
                {
                    //chama o metodo para buscar vendas por data
                    txt_Data_Venda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    _filter.DataDaVenda = Convert.ToDateTime(txt_Data_Venda.Text);

                    venda.Data_da_Venda = (DateTime)_filter.DataDaVenda;

                    var vendas = _vendaService.GetByDate(venda);
                    DataGridViewFill(vendas);
                    txt_Data_Venda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }
                else if (!string.IsNullOrEmpty(txt_Codigo.Text))
                {
                    //chama o metodo para buscar vendas pelo numero da venda
                    _filter.CodigoVenda = Convert.ToInt32(txt_Codigo.Text);
                    venda.NumeroVenda = Convert.ToInt32(_filter.CodigoVenda);
                    var vendas = _vendaService.GetByNumber(venda);
                    DataGridViewFill(vendas);
                }
                else if(comboBox1.SelectedItem != null)
                {
                    _filter.Mes = comboBox1.SelectedItem.ToString();
                    var mes = SetMonth(_filter.Mes);
                    List<Venda> lstVendas = new List<Venda>();
                    var vendas = _vendaService.GetVendas();
                    foreach(var item in vendas)
                    {
                        if(item.Data_da_Venda.Month == mes)
                        {
                            lstVendas.Add(item);
                        }
                    }
                    if(lstVendas.Count == 0 || lstVendas == null)
                    {
                        MessageBox.Show("Nenhuma Venda encontrada para o mês selecionado.", "Vendas não encontradas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DataGridViewFill(lstVendas);
                    }
                }
                else if (string.IsNullOrEmpty(txt_Data_Venda.Text) && string.IsNullOrEmpty(txt_Codigo.Text) && !string.IsNullOrEmpty(txt_Produto.Text))
                {
                    //chmada o metodo para buscar vendas pelo nome do produto
                    var vendas = _vendaService.GetByProductName(txt_Produto.Text);
                    DataGridViewFill(vendas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar buscar venda no banco");
            }
            
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            

        }
        #endregion

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
