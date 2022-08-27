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
        public DbSet<Produto>Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;DataBase=Loja_DiasDb;Uid=root;Pwd=Lucas98971;SSL Mode=None", new MySqlServerVersion(new Version(8, 0, 30)),
            option => option.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
                ));
            
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Loja_DiasDb;Trusted_Connection=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<ItemVenda>(new ItemVendaMap().Configure);
            modelBuilder.Entity<Venda>(new VendaMap().Configure);
            
        }

       
    }
}
