using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Venda : BaseEntity
    {

        private DateTime _dataVenda;

        public DateTime DataVenda
        {
            get { return _dataVenda; }
            set { _dataVenda = DateTime.Now; }
        }

        public int ProdutoId { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }


    }

}

