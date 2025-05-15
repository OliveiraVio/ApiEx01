using AtvApi01.Data;
using AtvApi01.Models;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtvApi01.Repositorio
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly AtividadeDbContext _dbContext;

        public ProdutosRepositorio(AtividadeDbContext atividadedbContext)
        {
            _dbContext = atividadedbContext;
        }
        public async Task<ProdutosModel> Adicionar(ProdutosModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutosModel ProdutosPorId = await BuscarPorId(id);

            if (ProdutosPorId == null)
            {
                throw new Exception("Produto não encontrado");
            }
            _dbContext.Produtos.Remove(ProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produto, int id)
        {
            ProdutosModel ProdutosPorId = await BuscarPorId(id);

            if (ProdutosPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não encontrado.");
            }


            ProdutosPorId.PrecoUnitario = produto.PrecoUnitario;
            ProdutosPorId.Nome = produto.Nome;
            ProdutosPorId.Descricao = produto.Descricao;
            //TarefaPorId.UsuarioId = tarefa.UsuarioId;


            await _dbContext.SaveChangesAsync();

            return ProdutosPorId;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos
    .ToListAsync();
        }
    }
}
