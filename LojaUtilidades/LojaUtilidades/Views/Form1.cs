using LojaUtilidades.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LojaUtilidades
{
    public partial class FormHome : Form
    {
        private CadastroProdutos cadastro;
        private ConsultarProdutos consulta;
        private Venda venda;
        public FormHome()
        {
            InitializeComponent();
            cadastro = new CadastroProdutos();
            consulta = new ConsultarProdutos();
            venda = new Venda();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro.ShowDialog();
            
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
            
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            venda.ShowDialog();
            

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
            
        }

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem certeza que deseja Sair do Sistema ? ", "Deseja sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.No)
            {
                Application.Restart();
                
                
            }
        }
    }
}
