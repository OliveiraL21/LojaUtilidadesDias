using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class VendaEntity : BaseEntity
    {
       
        public int NumeroVenda { get; set; }
        public DateTime Data_da_Venda { get; set; }
        public TimeSpan Hora_Venda { get; set; }
        public double Valor { get; set; }
        public List<ItemVendaEntity> ItensVenda { get; set; }
    }
}