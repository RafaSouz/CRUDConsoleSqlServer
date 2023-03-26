using CRUDConsole.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDConsoleSqlServer.Maps;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();

        builder.Property(x => x.Preco).HasColumnType("decimal(30,2)").IsRequired();

        builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();

        builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId);
    }
}