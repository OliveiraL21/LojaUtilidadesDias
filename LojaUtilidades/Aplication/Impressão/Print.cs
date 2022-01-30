using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Impressão
{
    public class Print : PrintDocument
    {
        public Font letraTitulo = new Font(FontFamily.GenericSansSerif,14,FontStyle.Bold);
        public Font letraMenu = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
        public Font fontProdutos = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        public Brush pincelPreto = new SolidBrush(Color.Black);
        public int contador = 100;
        public int contador2 = 100;
        public int x = 0;
        public int y = 0;
        public void ImprimirVenda(List<ProdutoEntity> produtos, object sender, PrintPageEventArgs e)
        {
            string empresa = "Cosméticos e Utilidades Dias";
            string cnpj = "Cnpj: 29.936.014/0001-01";

            Graphics graphics = e.Graphics;

            graphics.DrawString(empresa, letraTitulo, pincelPreto, x + (contador - 50), y + contador2);

            contador2 += 50;
            graphics.DrawString(cnpj, letraMenu, pincelPreto, x + contador, y + contador2);
        }
    }
}
