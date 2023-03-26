using CRUDConsole.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsoleSqlServer.Maps;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();

        builder.Property(x => x.DataCadastro).HasColumnType("datetime").IsRequired();

        builder.HasMany(x => x.Produtos).WithOne();
    }
}
