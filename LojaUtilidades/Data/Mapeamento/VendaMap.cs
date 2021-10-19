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
    public class VendaMap : IEntityTypeConfiguration<VendaEntity>
    {
        public void Configure(EntityTypeBuilder<VendaEntity> builder)
        {
            builder.ToTable("Venda");
            builder.HasKey(v => v.Id);

            builder.Property();
        }
    }
}
