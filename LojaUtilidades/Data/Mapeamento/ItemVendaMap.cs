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
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Quantidade).IsRequired();
            builder.HasOne(i => i.Venda).WithMany(v => v.ItensVenda).HasForeignKey(i => i.VendaId);
            //builder.HasOne(i => i.Produto).WithOne();
        }
    }
}
