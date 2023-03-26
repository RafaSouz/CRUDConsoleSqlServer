using CRUDConsole.Models;
using CRUDConsoleSqlServer.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CRUDConsoleSqlServer.Maps;

namespace CRUDConsole.Contexts;

public class Context : DbContext, IDesignTimeDbContextFactory<Context>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public Context() { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public static string conexao = "Server=DESKTOP-85AEEOL\\SQLEXPRESS;Database=Mercado;TrustServerCertificate=True;User Id = sa; Password=1234";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
    }
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlServer(conexao);

        return new Context(optionsBuilder.Options);
    }
}
