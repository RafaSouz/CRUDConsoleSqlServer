using CRUDConsole.Models;

namespace CRUDConsole.Repositories.RepositoriesInterfaces;

internal interface IProdutoRepositories
{
    Task<Produto> BuscarPorId(int id);
    Task<List<Produto>> BuscarTodos();
    Task<bool> Adicionar(Produto novo);
    Task<Produto> Atualizar(Produto ajuste, int id);
    Task<bool> Remover(int id);

}
