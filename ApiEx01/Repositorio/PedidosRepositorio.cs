using AtvApi01.Data;
using AtvApi01.Models;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtvApi01.Repositorio
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly AtividadeDbContext _dbContext;

        public PedidosRepositorio(AtividadeDbContext atividadedbContext)
        {
            _dbContext = atividadedbContext;
        }
        public async Task<PedidosModel> Adicionar(PedidosModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosModel PedidosPorId = await BuscarPorId(id);

            if (PedidosPorId == null)
            {
                throw new Exception("Pedido não encontrado");
            }
            _dbContext.Pedidos.Remove(PedidosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedido, int id)
        {
            PedidosModel PedidosPorId = await BuscarPorId(id);

            if (PedidosPorId == null)
            {
                throw new Exception($"Pedido do Id: {id} não encontrado.");
            }


            PedidosPorId.EnderecoEntrega = pedido.EnderecoEntrega;
            PedidosPorId.UsuarioId = pedido.UsuarioId;
            PedidosPorId.Status = pedido.Status;
            PedidosPorId.MetodoPagamento = pedido.MetodoPagamento;
            //TarefaPorId.UsuarioId = tarefa.UsuarioId;


            await _dbContext.SaveChangesAsync();

            return PedidosPorId;
        }

        public async Task<PedidosModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos
     .ToListAsync();
        }
    }
}
