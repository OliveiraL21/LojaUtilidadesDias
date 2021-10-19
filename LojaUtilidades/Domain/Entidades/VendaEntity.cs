using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
   public class VendaEntity : BaseEntity
    {
        public DateTime Data_Venda { get; set; }
        public double Valor { get; set; }
        public int ItemVendaId { get; set; }
        public IEnumerable<ItemVendaEntity> ItensVendas { get; set; }

    }
}
