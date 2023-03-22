using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CRUDConsole.Models;

public class Categoria
{
    [Key()]
    public int Id { get; set; }

    public string Tipo { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual List<Produto> Produtos { get; set; }

    public Categoria() { }
    public Categoria(string tipo, DateTime dataCadastro)
    {
        Tipo = tipo;
        DataCadastro = dataCadastro;
    }

    public override string ToString()
    {
        return "Id: " + Id + ", Tipo: " + Tipo.ToString() + 
            ", DataCadastro: " + DataCadastro.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    }
}
