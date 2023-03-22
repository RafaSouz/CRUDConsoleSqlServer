using CRUDConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDConsole.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public static string conexao = "Server=DESKTOP-85AEEOL\\SQLEXPRESS;Database=Mercado;TrustServerCertificate=True;User Id = sa; Password=1234";
}
