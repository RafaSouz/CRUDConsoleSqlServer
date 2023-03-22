using CRUDConsole.Models;

namespace CRUDConsole.Repositories.RepositoriesInterfaces;

public interface ICategoriaRepositories
{
    Task<Categoria> BuscarPorId(int id);
    Task<List<Categoria>> BuscarTodos();
    Task<bool> Adicionar(Categoria novo);
    Task<Categoria> Atualizar(Categoria ajuste, int id);
    Task<bool> Remover(int id);
}
