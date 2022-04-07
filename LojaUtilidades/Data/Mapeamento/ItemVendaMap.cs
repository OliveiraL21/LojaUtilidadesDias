using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapeamento
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVenda");
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Quantidade).IsRequired();
            builder.HasOne(it => it.Venda).WithMany(v => v.ItensVenda).HasForeignKey(i => i.VendaId);
            builder.HasOne(it => it.Produto).WithOne(p => p.ItemVenda);
        }
    }
}
