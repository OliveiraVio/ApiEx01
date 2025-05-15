using AtvApi01.Models;

namespace AtvApi01.Repositorio.Interfaces
{
    public interface IPedidosProdutosRepositorio
    {
        Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos();
        Task<PedidosProdutosModel> BuscarPorId(int id);
        Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel PedidosProdutos);
        Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel PedidosProdutos, int id);
        Task<bool> Apagar(int id);
    }
}