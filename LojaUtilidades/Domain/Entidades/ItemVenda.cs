using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ItemVenda : BaseEntity
    {
        public int Quantidade {get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        public ItemVenda()
        {

        }

        public ItemVenda(int quantidade, Produto produto, Venda venda)
        {
            this.Quantidade = quantidade;
            this.Produto = produto;
            this.Venda = venda;
        }
    }


}
