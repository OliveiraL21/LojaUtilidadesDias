using LojaUtilidades.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaUtilidades.Views
{
    public partial class ConsultarProdutos : Form
    {
        Produto produto;
        public ConsultarProdutos()
        {
            InitializeComponent();
            produto = new Produto();
        }

        private void ConsultarProdutos_Load(object sender, EventArgs e)
        {

            ListaDeProdutosConsulta.Rows.Clear();
            DataTable dt = new DataTable();
            foreach (DataRow linha in produto.Consultar().Rows)
            {
                ListaDeProdutosConsulta.Rows.Add(linha.ItemArray);
            }
        }

        private void ListaDeProdutosConsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProduto.Text = ListaDeProdutosConsulta.SelectedRows[0].Cells[0].Value.ToString();
            txtProdutoConsultar.Text = ListaDeProdutosConsulta.SelectedRows[0].Cells[1].Value.ToString();
            txtValor.Text = ListaDeProdutosConsulta.SelectedRows[0].Cells[2].Value.ToString();
            txtQuantidade.Text = ListaDeProdutosConsulta.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                int id;
                string nome;
                double valor = 0;
                int quantidade = 0;

                if (txtProdutoConsultar.Text == "" || txtProdutoConsultar.Text == null)
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
                    id = (int)ListaDeProdutosConsulta.SelectedRows[0].Cells[0].Value;
                    nome = txtProdutoConsultar.Text;
                    valor = double.Parse(txtValor.Text);
                    quantidade = int.Parse(txtQuantidade.Text);


                    produto.Editar(id, nome, valor, quantidade);

                    txtIdProduto.Text = "";
                    txtProdutoConsultar.Text = "";
                    txtQuantidade.Text = "";
                    txtValor.Text = "";
                    ListaDeProdutosConsulta.Rows.Clear();

                    DataTable dt = new DataTable();
                    foreach (DataRow linha in produto.Consultar().Rows)
                    {
                        ListaDeProdutosConsulta.Rows.Add(linha.ItemArray);
                    }

                }



            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ListaDeProdutosConsulta.Rows.Clear();
            try
            {
                //produto.Consultar();
                DataTable dt = new DataTable();
                foreach (DataRow linha in produto.Consultar().Rows)
                {
                    ListaDeProdutosConsulta.Rows.Add(linha.ItemArray);
                }
                MessageBox.Show("Tabela Atualizada com Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Atualizar a tabela, Erro: {ex}");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            string nome = txtProdutoConsultar.Text;
            if (nome == "" || nome == null)
            {
                MessageBox.Show("Digite o nome do produto", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataRow linha in produto.ConsultarProdutoPorNome(nome).Rows)
                {
                    ListaDeProdutosConsulta.Rows.Clear();
                    ListaDeProdutosConsulta.Rows.Add(linha.ItemArray);
                }
            }


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int id = (int)ListaDeProdutosConsulta.SelectedRows[0].Cells[0].Value;

            produto.Deletar(id);
            MessageBox.Show(produto.Menssagem);
        }
    }
}
