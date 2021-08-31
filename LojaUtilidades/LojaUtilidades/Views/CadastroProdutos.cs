using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaUtilidades.Control;
using LojaUtilidades.Model;

namespace LojaUtilidades.Views
{
    public partial class CadastroProdutos : Form
    {
        private Produto produto = new Produto();
        public CadastroProdutos()
        {
            InitializeComponent();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtProdutoCadastrar.Text == "" || txtProdutoCadastrar.Text == null)
            {
                MessageBox.Show("Digite o nome do produto", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtValor.Text == "" || txtValor == null)
            {
                MessageBox.Show("Digite o valor dos produtos", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtQuantidade.Text == "" || txtQuantidade == null)
            {
                MessageBox.Show("Digite a quantidade dos produtos", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var nome = txtProdutoCadastrar.Text;
                var valor = double.Parse(txtValor.Text);
                var quantidade = int.Parse(txtQuantidade.Text);

                produto.Cadastrar(nome, valor, quantidade);
                MessageBox.Show(produto.Menssagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdutoCadastrar.Text = "";
                txtValor.Text = "";
                txtQuantidade.Text = "";
                ListaGrid.Rows.Clear();

                DataTable dt = new DataTable();
                foreach (DataRow linha in produto.Consultar().Rows)
                {
                    ListaGrid.Rows.Add(linha.ItemArray);
                }
            }

        }

        

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            ListaGrid.Rows.Clear();
            foreach (DataRow linha in produto.Consultar().Rows)
            {
                ListaGrid.Rows.Add(linha.ItemArray);
            }

        }


        private void btnDeletar_Click(object sender, EventArgs e)
        {

            int id = (int)ListaGrid.SelectedRows[0].Cells[0].Value;

            produto.Deletar(id);
            MessageBox.Show(produto.Menssagem);
            ListaGrid.Rows.Clear();

            DataTable dt = new DataTable();
            foreach (DataRow linha in produto.Consultar().Rows)
            {
                ListaGrid.Rows.Add(linha.ItemArray);
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtProdutoCadastrar.Text == "" || txtProdutoCadastrar.Text == null)
            {
                MessageBox.Show("Digite o nome do produto", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtValor.Text == "" || txtValor == null)
            {
                MessageBox.Show("Digite o valor dos produtos", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtQuantidade.Text == "" || txtQuantidade == null)
            {
                MessageBox.Show("Digite a quantidade dos produtos", "Campo obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = (int)ListaGrid.SelectedRows[0].Cells[0].Value;
                string nome = txtProdutoCadastrar.Text;
                double valor = double.Parse(txtValor.Text);
                int quantidade = int.Parse(txtQuantidade.Text);
                produto.Editar(id, nome, valor, quantidade);

                txtProdutoCadastrar.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";

                ListaGrid.Rows.Clear();

                DataTable dt = new DataTable();
                foreach (DataRow linha in produto.Consultar().Rows)
                {
                    ListaGrid.Rows.Add(linha.ItemArray);
                }
            }
            
        }

        private void ListaGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtProdutoCadastrar.Text = ListaGrid.SelectedRows[0].Cells[1].Value.ToString();
            txtValor.Text = ListaGrid.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantidade.Text = ListaGrid.SelectedRows[0].Cells[3].Value.ToString();
        }


    }
}
