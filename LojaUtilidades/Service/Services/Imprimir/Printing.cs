using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Imprimir
{
    public  class Printing : Print
    {
        public static void ImprimirCabecalho()
        {
            EventArgs e;
            string Titulo = "Loja Utilidade e Cosmeticos Dias";
            string Subtitulo = "Cnpj: 29.936.014/0001-01";
            Font LetraTitulo = new Font("Calibri", 32, FontStyle.Bold, GraphicsUnit.Point);
            Font LetraSubtitulo = new Font("Calibri", 26, FontStyle.Regular, GraphicsUnit.Point);
            Brush PincelPreto = new SolidBrush(Color.Black);

            

        }
        public static void Imprimir(List<VendaEntity>vendas)
        {
            
        }
    }
}
