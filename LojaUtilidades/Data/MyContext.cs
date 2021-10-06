using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyContext : DbContext
    {
       public  DbSet<Produto> Produtos { get; set; }
        public MyContext()
        {
                
        }
    }
}
