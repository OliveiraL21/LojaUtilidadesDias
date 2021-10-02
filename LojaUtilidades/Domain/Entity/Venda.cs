using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Venda
    {
        public int Id { get; set; }

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

