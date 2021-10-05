using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
