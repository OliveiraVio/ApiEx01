using AtvApi01.Models;

namespace AtvApi01.Repositorio.Interfaces
{
    public interface IProdutosRepositorio
    {
        Task<List<ProdutosModel>> BuscarTodosProdutos();
        Task<ProdutosModel> BuscarPorId(int id);
        Task<ProdutosModel> Adicionar(ProdutosModel produto);
        Task<ProdutosModel> Atualizar(ProdutosModel produto, int id);
        Task<bool> Apagar(int id);
    }
}
