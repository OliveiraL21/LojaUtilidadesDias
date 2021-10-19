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
            builder.ToTable("ItemDeVenda");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).IsRequired();

            builder.HasOne(i => i.Produto).WithOne(p => p.ItemVenda);
        }
    }
}
