using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ItemVendaEntity : BaseEntity
    {
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoEntity Produto { get; set; }
    }
}
