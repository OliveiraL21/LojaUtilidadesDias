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
    public partial class Form_Carregamento : Form
    {
        public Form_Carregamento()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 3;
            timer1.Start();
            if(panel3.Width >= this.Width)
            {
                timer1.Stop();
                Form_Principal principal = new Form_Principal();
                principal.Show();
                this.Hide();
            }
        }
    }
}
