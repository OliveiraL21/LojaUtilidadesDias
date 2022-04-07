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
        private readonly Filter _filter;
        public Form_Consulta_Vendas()
        {
            InitializeComponent();
            _vendaService = new VendasService();
            _filter = new Filter();
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
        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            ClearFilds();
        }
        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Metodos do formulário

        private void DataGridViewFill(IEnumerable<Venda> vendas)
        {
            try
            {
                dataGrid_Vendas.Rows.Clear();
                int index = 0;

                foreach (var Venda in vendas)
                {

                    foreach (var item in Venda.ItensVenda)
                    {
                        dataGrid_Vendas.Rows.Add();
                        dataGrid_Vendas.Rows[index].Cells[0].Value = Venda.Codigo;
                        dataGrid_Vendas.Rows[index].Cells[1].Value = item.Produto.Nome;
                        dataGrid_Vendas.Rows[index].Cells[2].Value = item.Quantidade;
                        dataGrid_Vendas.Rows[index].Cells[3].Value = Venda.Valor;
                        dataGrid_Vendas.Rows[index].Cells[4].Value = Venda.Data.ToString("dd/MM/yyyy");
                        dataGrid_Vendas.Rows[index].Cells[5].Value = Venda.Hora.ToString(@"hh\:mm");
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar preencher a tabela", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar preencher o datagridview");
            }

        }
        private int GetMonthSelected(string month)
        {
            var SelectedMonth = 0;
            switch (month)
            {
                case "Janeiro":
                    SelectedMonth = 01;
                    break;
                case "Fevereiro":
                    SelectedMonth = 02;
                    break;
                case "Março":
                    SelectedMonth = 03;
                    break;
                case "Abril":
                    SelectedMonth = 04;
                    break;
                case "Maio":
                    SelectedMonth = 05;
                    break;
                case "Junho":
                    SelectedMonth = 06;
                    break;
                case "Julho":
                    SelectedMonth = 07;
                    break;
                case "Agosto":
                    SelectedMonth = 08;
                    break;
                case "Setembro":
                    SelectedMonth = 09;
                    break;
                case "Outubro":
                    SelectedMonth = 10;
                    break;
                case "Novembro":
                    SelectedMonth = 11;
                    break;
                case "Dezembro":
                    SelectedMonth = 12;
                    break;
            }
            return SelectedMonth;
        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                DatagridViewClear();
                IEnumerable<Venda> vendas = _vendaService.GetVendas();
                DataGridViewFill(vendas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "\nErro ao tentar buscar as vendas no banco de dados");
            }

        }
        private void DatagridViewClear()
        {
            dataGrid_Vendas.Rows.Clear();
        }
        private void ClearFilds()
        {
            dataGrid_Vendas.Rows.Clear();
            txt_Codigo.Text = "";
            txt_Data.Text = "";
            txt_Produto.Text = "";
            comboBox_Mes.Text = "";
            comboBox_Mes.SelectedItem = "";
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Data.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                DatagridViewClear();
                Venda venda = new Venda();
                if (string.IsNullOrEmpty(txt_Data.Text) && string.IsNullOrEmpty(txt_Codigo.Text) && comboBox_Mes.SelectedItem == null && string.IsNullOrEmpty(txt_Produto.Text))
                {
                    _filter.Codigo = null;
                    _filter.Data = null;
                    _filter.Mes = null;
                    MessageBox.Show("Informe pelo menos um dos filtros para continuar com a consulta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (txt_Data.Text != "")
                {
                    //chama o metodo para buscar vendas por data
                    txt_Data.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    _filter.Data = Convert.ToDateTime(txt_Data.Text);

                    venda.Data = (DateTime)_filter.Data;

                    var vendas = _vendaService.GetByDate(venda);
                    DataGridViewFill(vendas);
                    txt_Data.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }
                else if (!string.IsNullOrEmpty(txt_Codigo.Text))
                {
                    //chama o metodo para buscar vendas pelo numero da venda
                    _filter.Codigo = Convert.ToInt32(txt_Codigo.Text);
                    venda.Codigo = Convert.ToInt32(_filter.Codigo);
                    var vendas = _vendaService.GetByCodigo(venda);
                    DataGridViewFill(vendas);
                }
                else if (comboBox_Mes.SelectedItem != null)
                {
                    _filter.Mes = comboBox_Mes.SelectedItem.ToString();
                    var mes = GetMonthSelected(_filter.Mes);
                    List<Venda> listVendas = new List<Venda>();
                    var vendas = _vendaService.GetVendas();
                    foreach (var Venda in vendas)
                    {
                        if (Venda.Data.Month == mes)
                        {
                            listVendas.Add(Venda);
                        }
                    }
                    if (listVendas.Count == 0 || listVendas == null)
                    {
                        MessageBox.Show("Nenhuma Venda encontrada para o mês selecionado.", "Vendas não encontradas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DataGridViewFill(listVendas);
                    }
                }
                else if (string.IsNullOrEmpty(txt_Data.Text) && string.IsNullOrEmpty(txt_Codigo.Text) && !string.IsNullOrEmpty(txt_Produto.Text))
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
        #endregion
    }
}
