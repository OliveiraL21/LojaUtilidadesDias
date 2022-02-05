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
        public Form_Consulta_Vendas()
        {
            InitializeComponent();
            _vendaService = new VendasService();
            Path = Application.StartupPath + @"\Tela-Consultar-Vendas-.txt";
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
            form_Produtos.ShowDialog();
            Close();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();
            Close();

        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas formVenda = new Form_Vendas();
            formVenda.ShowDialog();
            Close();
        }
        private void btn_Estoque_Vendas_Click_(object sender, EventArgs e)
        {
            MessageBox.Show("A pagina de Consulta de vendas já está aberta !", "Janela ja aberta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Metodos do formulário

        private void DataGridViewFill(IEnumerable<VendaEntity> vendas)
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
                Log.Error(ex.InnerException, "\nErro ao tentar preencher o datagridview");
            }
           
        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                DatagridViewCler();
                IEnumerable<VendaEntity> vendas = _vendaService.GetVendas();
                DataGridViewFill(vendas);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex.InnerException, "\nErro ao tentar buscar as vendas no banco de dados");
            }

        }

       private void DatagridViewCler()
        { 
            dgv_Vendas_Consulta.Rows.Clear();
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                DatagridViewCler();
                VendaEntity venda = new VendaEntity();
                if (string.IsNullOrEmpty(txt_Data_Venda.Text) && string.IsNullOrEmpty(txt_Codigo.Text))
                {
                    MessageBox.Show("Digite uma data ou o código da venda para continuar com a consulta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!string.IsNullOrEmpty(txt_Data_Venda.Text) && string.IsNullOrEmpty(txt_Codigo.Text))
                {
                    //chama o metodo para buscar vendas por data
                    txt_Data_Venda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;


                    venda.Data_da_Venda = Convert.ToDateTime(txt_Data_Venda.Text);

                    var vendas = _vendaService.GetByDate(venda);
                    DataGridViewFill(vendas);
                    txt_Data_Venda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }
                else if (string.IsNullOrEmpty(txt_Data_Venda.Text) && !string.IsNullOrEmpty(txt_Codigo.Text))
                {
                    //chama o metodo para buscar vendas pelo numero da venda
                    venda.NumeroVenda = Convert.ToInt32(txt_Codigo.Text);
                    var vendas = _vendaService.GetByNumber(venda);
                    DataGridViewFill(vendas);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar buscar vendas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex.InnerException, "\nErro ao tentar buscar venda no banco");
            }
            
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            dgv_Vendas_Consulta.Rows.Clear();
        }
        #endregion
    }
}
