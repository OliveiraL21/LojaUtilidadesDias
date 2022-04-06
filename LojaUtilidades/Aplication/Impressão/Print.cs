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
        private readonly Font letraTitulo;
        private readonly Font letraMenu;
        private readonly Font letraProdutos;
        private readonly Font letraTotal;
        private readonly Brush pincelPreto;
        private int contador;
        private int contador2;
        private int x;
        private int y;
        public Print()
        {
            letraTitulo = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
            letraMenu = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            letraProdutos = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            letraTotal = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            pincelPreto = new SolidBrush(Color.Black);
            contador = 100;
            contador2 = 100;
            x = 100;
            y = 50;
        }
        public void ImprimirVenda(Venda venda, List<Produto> produtos, double total, object sender, PrintPageEventArgs e)
        {
            string empresa = "Cosméticos e Utilidades Dias";
            string cnpj = "Cnpj: 29.936.014/0001-01";

            Graphics graphics = e.Graphics;

            graphics.DrawString(empresa, letraTitulo, pincelPreto, x + contador, y + contador2);
            contador2 += 25;
            graphics.DrawString(cnpj, letraMenu, pincelPreto, x + contador, y + contador2);
            contador2 += 25;
            graphics.DrawString($"Data da venda: {DateTime.Now.Date.ToString("dd/MM/yyyy")}", letraMenu, pincelPreto, x + contador, y + contador2);
            contador2 += 25;
            graphics.DrawString($"Hora da venda: {DateTime.Now.ToString("HH:mm")}", letraMenu, pincelPreto, x + contador, y + contador2);
            contador2 += 25;
            graphics.DrawString($"Código da Venda: {venda.NumeroVenda}", letraMenu, pincelPreto, x + contador, y + contador2);
            contador2 += 25;
            graphics.DrawLine(new Pen(pincelPreto), 200, contador2 + 50, 630, contador2 + 50);
            contador2 += 10;
            graphics.DrawString("Cupom Não Fiscal", letraMenu, pincelPreto, 350, y + contador2);
            contador2 += 25;
            graphics.DrawLine(new Pen(pincelPreto), 200, contador2 + 50, 630, contador2 + 50);
            contador2 += 10;
            graphics.DrawString("Código \t\t", letraProdutos, pincelPreto, 215, y + contador2);
            graphics.DrawString("Produto\t", letraProdutos, pincelPreto, 315, y + contador2);
            graphics.DrawString("Quantidade\t", letraProdutos, pincelPreto, 420, y + contador2);
            graphics.DrawString("Valor", letraProdutos, pincelPreto, 540, y + contador2);
            contador2 += 25;
            graphics.DrawLine(new Pen(pincelPreto), 200, contador2 + 50, 630, contador2 + 50);
            contador2 += 25;
            foreach (var produto in produtos)
            {

                graphics.DrawString(produto.Id + "\t\t", letraProdutos, pincelPreto, 220, y + contador2);
                graphics.DrawString(produto.Nome.Length > 10 ? produto.Nome.Substring(0, 10) + "..." : produto.Nome + "\t\t\t", letraProdutos, pincelPreto, 315, y + contador2);
                graphics.DrawString(produto.Quantidade + "\t\t", letraProdutos, pincelPreto, 450, y + contador2);
                graphics.DrawString(produto.Valor.ToString("C2") + "\t\t", letraProdutos, pincelPreto, 540, y + contador2);
                contador2 += 25;
            }
            contador2 += 10;
            graphics.DrawLine(new Pen(pincelPreto), 200, contador2 + 50, 630, contador2 + 50);
            contador2 += 20;
            graphics.DrawString($"TOTAL: R${total}", letraTotal, pincelPreto, x + contador, y + contador2);


        }
    }
}
