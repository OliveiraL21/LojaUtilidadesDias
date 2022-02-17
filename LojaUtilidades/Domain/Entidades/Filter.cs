using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class FilterEntity
    {
        public int? CodigoVenda { get; set; }
        public DateTime? DataDaVenda { get; set; }
        public string? Mes { get; set; }
    }
}
