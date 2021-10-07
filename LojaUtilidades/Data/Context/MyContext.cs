using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<ProdutoEntity>Produtos { get; set; }
        public MyContext(DbContextOptions<MyContext> context) : base(context)
        {

        }
    }
}
