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
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(80).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
        }
    }
}
