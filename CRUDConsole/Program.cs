using CRUDConsole.Contexts;
using CRUDConsole.Models;
using CRUDConsole.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Program;

class TestClass
{
    static async Task Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlServer(Context.conexao);
        var context = new Context(optionsBuilder.Options);

        var cControler = new CategoriaRepositories(context);

        Console.WriteLine("Lista atual de categorias: ");
        var cListaInicial = await cControler.BuscarTodos();
        foreach (var item in cListaInicial)
        {
            Console.WriteLine(item);
        }

        var pControler = new ProdutoRepositories(context);

        Console.WriteLine();
        Console.WriteLine("Lista atual de produtos: ");
        var pListaInicial = await pControler.BuscarTodos();
        foreach (var item in pListaInicial)
        {
            Console.WriteLine(item);
            Console.Write("Categoria: ");
            Console.WriteLine(await cControler.BuscarPorId(item.CategoriaId));
            Console.WriteLine();
        }

        Console.WriteLine("Digite a quantidade de categorias que irá registrar: ");
        var indicador = int.Parse(Console.ReadLine());

        for (int i = 0; i < indicador; i++)
        {
            Console.WriteLine("Digite o tipo:");
            string tipo = Console.ReadLine();
            Console.WriteLine("Digite a data de cadastro no padrão dd-mm-yyyy");
            DateTime cadastro = DateTime.Parse(Console.ReadLine());

            Categoria categoria = new Categoria(tipo, cadastro);

            await cControler.Adicionar(categoria);

        }

        Console.WriteLine();

        var listaCategorias = await cControler.BuscarTodos();
        foreach (var item in listaCategorias)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        Console.WriteLine("Quer alterar alguma categoria? S/N");

        if (char.Parse(Console.ReadLine()) == 'S')
        {
            Console.WriteLine("Digite o Id da categoria a ser alterada: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo tipo: ");
            string tipo = Console.ReadLine();

            Console.WriteLine("Digite a nova data cadastro: ");
            DateTime cadastro = DateTime.Parse(Console.ReadLine());

            await cControler.Atualizar(new Categoria(tipo, cadastro), id);
        }

        Console.WriteLine("Categorias após atualização: ");
        listaCategorias = await cControler.BuscarTodos();
        foreach (var item in listaCategorias)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Quer remover alguma categoria? S/N");

        if (char.Parse(Console.ReadLine()) == 'S')
        {
            Console.WriteLine("Digite o id da categoria: ");

            await cControler.Remover(int.Parse(Console.ReadLine()));
        }

        int acao = 10;

        while (acao != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Digite 1 para adicionar um produto, 2 para ver um produto,");
            Console.WriteLine("3 para ver todos os produtos, 4 para editar um produto,");
            Console.WriteLine("5 para remover um produto e 0 para sair");
            Console.WriteLine();

            Console.WriteLine("Categorias disponíveis: ");

            listaCategorias = await cControler.BuscarTodos();
            foreach (var item in listaCategorias)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            acao = int.Parse(Console.ReadLine());

            if (acao == 1 || acao == 4)
            {
                Console.WriteLine("Digite o nome:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o preco:");
                double preco = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);


                Console.WriteLine("Digite a quantidade:");
                int quantidade = int.Parse(Console.ReadLine());

                if (acao == 1)
                {
                    Console.WriteLine("Digite o id da categoria:");
                    int idCategoria = int.Parse(Console.ReadLine());

                    Produto produto = new Produto(nome, preco, quantidade);

                    produto.Categoria = await cControler.BuscarPorId(idCategoria);

                    await pControler.Adicionar(produto);

                }

                else
                {
                    Console.WriteLine("Digite o id do produto que quer alterar:");
                    int id = int.Parse(Console.ReadLine());

                    Produto produto = new Produto(nome, preco, quantidade);

                    Console.WriteLine("Irá alterar a categoria? S/N");
                    char decisao = char.Parse(Console.ReadLine());

                    if (decisao == 'S')
                    {
                        Console.WriteLine("Digite a nova categoria:");
                        int idCategoria = int.Parse(Console.ReadLine());

                        produto.Categoria = await cControler.BuscarPorId(idCategoria);
                    }
                    else
                        produto.Categoria = null;

                    await pControler.Atualizar(produto, id);

                }

            }

            if (acao == 2 || acao == 5)
            {
                Console.WriteLine("Digite o id do produto:");
                int id = int.Parse(Console.ReadLine());

                if (acao == 2)
                {
                    var produto = await pControler.BuscarPorId(id);
                    Console.WriteLine(produto);
                    Console.Write("Categoria: ");
                    Console.WriteLine(await cControler.BuscarPorId(produto.CategoriaId));
                }
                else
                {
                    await pControler.Remover(id);
                }
            }

            if (acao == 3)
            {
                Console.WriteLine("Buscando lista de produtos: ");
                var lista = await pControler.BuscarTodos();
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                    Console.Write("Categoria: ");
                    Console.WriteLine(await cControler.BuscarPorId(item.CategoriaId));
                    Console.WriteLine();
                }
            }
        }
    }
}