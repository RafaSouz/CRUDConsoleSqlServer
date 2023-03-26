using CRUDConsole.Contexts;
using CRUDConsole.Models;
using Microsoft.EntityFrameworkCore;
using CRUDConsole.Repositories.RepositoriesInterfaces;

namespace CRUDConsole.Repositories;

public class ProdutoRepositories : IProdutoRepositories
{

    private readonly Context _context;

    public ProdutoRepositories(Context context)
    {
        _context = context;
    }

    public async Task<Produto> BuscarPorId(int id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Produto>> BuscarTodos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<bool> Adicionar(Produto model)
    {
        await _context.Produtos.AddAsync(model);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Produto> Atualizar(Produto model, int id)
    {
        Produto produto = await BuscarPorId(id);

        produto.Preco = model.Preco;
        produto.Nome = model.Nome;
        produto.Quantidade = model.Quantidade;

        if(model.Categoria != null)
        {
            produto.Categoria = model.Categoria;
        }

        await _context.SaveChangesAsync();

        return model;
    }
    public async Task<bool> Remover(int id)
    {
        Produto model = await BuscarPorId(id);

        if (model == null)
        {
            throw new Exception("Não existe produto com esse id");
        }

        _context.Produtos.Remove(model);
        await _context.SaveChangesAsync();

        return true;
    }
}
