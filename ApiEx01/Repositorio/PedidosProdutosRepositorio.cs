using AtvApi01.Data;
using AtvApi01.Models;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEx01.Repositorio
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly AtividadeDbContext _dbContext;

        public PedidosProdutosRepositorio(AtividadeDbContext atividadedbContext)
        {
            _dbContext = atividadedbContext;
        }
        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel PedidosProdutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(PedidosProdutos);
            await _dbContext.SaveChangesAsync();

            return PedidosProdutos;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosProdutosModel PedidosProdutosPorId = await BuscarPorId(id);

            if (PedidosProdutosPorId == null)
            {
                throw new Exception("PedidosProdutos não encontrado");
            }
            _dbContext.PedidosProdutos.Remove(PedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel PedidosProdutos, int id)
        {
            PedidosProdutosModel PedidosProdutosPorId = await BuscarPorId(id);

            if (PedidosProdutosPorId == null)
            {
                throw new Exception($"PedidosProdutos do Id: {id} não encontrado.");
            }

            PedidosProdutosPorId.CategoriaId = PedidosProdutos.CategoriaId;
            PedidosProdutosPorId.ProdutoId = PedidosProdutos.ProdutoId;
            PedidosProdutosPorId.PrecoUnitario = PedidosProdutos.PrecoUnitario;
            PedidosProdutosPorId.Quantidade = PedidosProdutos.Quantidade;


            await _dbContext.SaveChangesAsync();

            return PedidosProdutosPorId;
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos
               .Include(x => x.Categoria)
               .Include(y => y.Produto)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos
               .Include(x => x.Categoria)
               .Include(y => y.Produto)
                .ToListAsync();
        }
    }
}
