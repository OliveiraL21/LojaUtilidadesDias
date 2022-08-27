using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Venda : BaseEntity
    {
        public int Codigo { get; set; }
        public DateTime Data_da_Venda { get; set; }
        public TimeSpan Hora_Venda { get; set; }
        public double Valor { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }

        public Venda()
        {

        }
        public Venda( DateTime data, TimeSpan hora, double valor)
        {
            this.Data_da_Venda = data;
            this.Hora_Venda = hora;   
            this.Valor = valor;
        }
    }


}