using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CRUDConsole.Models;

public class Produto
{
    [Key()]
    public int Id { get; set; }

    public string Nome { get; set; }

    public double Preco { get; set; }

    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

    public int? Quantidade { get; set; }


    public Produto()
    {
    }    

    public Produto(string nome, double preco, int quantidade) 
    {
        Nome = nome;    
        Preco = preco;
        Quantidade = quantidade;

    }

    public override string ToString()
    {
        return "Id: " + Id + " Nome: " + Nome + " Preco " +
            Preco.ToString("F2", CultureInfo.InvariantCulture) +
            " Quantidade: " + Quantidade;
    }
}
