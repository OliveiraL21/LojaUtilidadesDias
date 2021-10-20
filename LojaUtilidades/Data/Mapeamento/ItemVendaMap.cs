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
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVendaEntity>
    {
        public void Configure(EntityTypeBuilder<ItemVendaEntity> builder)
        {
            builder.ToTable("Item-Venda");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Quantidade).IsRequired();
            builder.HasOne(i => i.Produto).WithOne(p => p.ItemVenda).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.Venda).WithMany(v => v.ItensVenda).HasForeignKey(i => i.VendaId);
        }
    }
}
