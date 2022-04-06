using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public virtual ItemVenda ItemVenda { get; set; }
        public Produto()
        {

        }
        public Produto(string nome, double valor, int quantidade)
        {

        }

    }
}
