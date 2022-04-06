using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Filter
    {
        //Representa o codigo de uma venda
        public int? Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string Mes { get; set; }
    }
}
