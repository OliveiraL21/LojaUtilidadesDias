using Domain.Entidades;
using Domain.Interfaces.Services.Venda;
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
        public Form_Consulta_Vendas()
        {
            InitializeComponent();
            _vendaService = new VendasService();
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
            Close();
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();

        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas formVenda = new Form_Vendas();
            formVenda.ShowDialog();
        }
        #endregion

        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas form_estoque_vendas = new Form_Consulta_Vendas();
            form_estoque_vendas.ShowDialog();
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            var venda = new VendaEntity()
            {
                Data_da_Venda = Convert.ToDateTime(txt_Data_Venda.Text)

            };

           var vendas =  _vendaService.GetByDate(venda);

            int index = 0;

            foreach (var Venda in vendas)
            {
               
                foreach (var item in Venda.ItensVenda)
                {
                    dgv_Vendas_Consulta.Rows.Add();
                    dgv_Vendas_Consulta.Rows[index].Cells[0].Value = item.ProdutoId;
                    dgv_Vendas_Consulta.Rows[index].Cells[1].Value = item.Produto.Nome;
                    dgv_Vendas_Consulta.Rows[index].Cells[2].Value = item.Quantidade;
                    dgv_Vendas_Consulta.Rows[index].Cells[3].Value = Venda.Valor;
                    dgv_Vendas_Consulta.Rows[index].Cells[4].Value = Venda.Id;
                    dgv_Vendas_Consulta.Rows[index].Cells[5].Value = Venda.Data_da_Venda.ToString("dd/MM/yyyy");
                    dgv_Vendas_Consulta.Rows[index].Cells[6].Value = Venda.Hora_Venda.ToString(@"hh\:mm");
                    index++;
                }
                

            }

        }

        private void btn_Estoque_Vendas_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("A pagina de vendas estoque já está aberta !","Janela ja aberta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
    }
}
