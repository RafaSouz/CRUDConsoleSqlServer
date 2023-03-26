using CRUDConsole.Contexts;
using CRUDConsole.Models;
using CRUDConsole.Repositories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDConsole.Repositories;

public class CategoriaRepositories : ICategoriaRepositories
{
    private readonly Context _context;

    public CategoriaRepositories(Context context)
    {
        _context = context;
    }

    public async Task<Categoria> BuscarPorId(int id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Categoria>> BuscarTodos()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<bool> Adicionar(Categoria model) 
    {
        await _context.Categorias.AddAsync(model);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Categoria> Atualizar(Categoria model, int id)
    {
        Categoria categoria = await BuscarPorId(id);
        categoria.Tipo = model.Tipo;
        categoria.DataCadastro = model.DataCadastro;

        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<bool> Remover(int id)
    {
        Categoria model = await BuscarPorId(id);

        if (model == null)
        {
            throw new Exception("Não existe categoria com esse Id");
        }

        _context.Remove(model);
        await _context.SaveChangesAsync();

        return true;
    }
}
