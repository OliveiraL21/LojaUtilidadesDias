using Data.Mapeamento;
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
        public DbSet<VendaEntity> Vendas { get; set; }
        public DbSet<ItemVendaEntity> ItensVendas { get; set; }
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;DataBase=Loja_DiasDb;Uid=root;Pwd=lucas123; SSL Mode=None", new MySqlServerVersion(new Version(8, 0, 28)),
            option => option.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(20),
                errorNumbersToAdd: null
                ));
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Loja_DiasDb;Trusted_Connection=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>(new ProdutoMap().Configure);
            modelBuilder.Entity<ItemVendaEntity>(new ItemVendaMap().Configure);
            modelBuilder.Entity<VendaEntity>(new VendaMap().Configure);
        }

       
    }
}
