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

    public async Task<bool> Adicionar(Produto novo)
    {
        await _context.Produtos.AddAsync(novo);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Produto> Atualizar(Produto ajuste, int id)
    {
        Produto prod = await BuscarPorId(id);

        prod.Preco = ajuste.Preco;
        prod.Nome = ajuste.Nome;
        prod.Quantidade = ajuste.Quantidade;
        prod.Categoria = ajuste.Categoria;

        await _context.SaveChangesAsync();

        return ajuste;
    }
    public async Task<bool> Remover(int id)
    {
        Produto prod = await BuscarPorId(id);

        if (prod == null)
        {
            throw new Exception("Não existe produto com esse id");
        }

        _context.Produtos.Remove(prod);
        await _context.SaveChangesAsync();

        return true;
    }
}
