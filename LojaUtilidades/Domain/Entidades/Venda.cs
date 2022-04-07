using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Venda : BaseEntity
    {
       
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public double Valor { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }
    }
}