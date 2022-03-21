using Data.Context;
using Data.Implementation;
using Domain.Interfaces.Services.Produtos;
using Domain.Repository;
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
    public partial class Form_Principal : Form
    {
        private readonly string path;
        public Form_Principal()
        { 
            InitializeComponent();
            path = Application.StartupPath + @"\Logs\Tela-Principal-.txt";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(path,rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region cores-Houver-btn-menu
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
        #endregion

       

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            Form_Produtos form_Produtos = new Form_Produtos();
            form_Produtos.ShowDialog();
        }

        private void btn_Vendas_Click(object sender, EventArgs e)
        {
            Form_Vendas form_Vendas = new Form_Vendas();
            form_Vendas.ShowDialog();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            Form_Estoque form_Estoque = new Form_Estoque();
            form_Estoque.ShowDialog();
        }

        private void btn_Estoque_Vendas_Click(object sender, EventArgs e)
        {
            Form_Consulta_Vendas form_estoque_vendas = new Form_Consulta_Vendas();
            form_estoque_vendas.ShowDialog();
        }

        private void btn_Estoque_Vendas_MouseHover(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.DarkMagenta;
        }

        private void btn_Estoque_Vendas_MouseLeave(object sender, EventArgs e)
        {
            btn_Estoque_Vendas.BackColor = Color.FromArgb(41, 0, 39);
        }
    }
}
