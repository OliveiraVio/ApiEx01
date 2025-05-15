using AtvApi01.Models;

namespace AtvApi01.Repositorio.Interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<CategoriasModel>> BuscarTodasCategorias();
        Task<CategoriasModel> BuscarPorId(int id);
        Task<CategoriasModel> Adicionar(CategoriasModel categoria);
        Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id);
        Task<bool> Apagar(int id);
    }
}