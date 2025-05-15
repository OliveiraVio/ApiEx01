using AtvApi01.Models;
using AtvApi01.Repositorio;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtvApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
        {
            _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModel>>> BuscarTodosPedidosProdutos()
        {
            List<PedidosProdutosModel> pedidosProdutos = await _pedidosProdutosRepositorio.BuscarTodosPedidosProdutos();
            return Ok(pedidosProdutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> BuscarPorId(int id)
        {
            PedidosProdutosModel pedidosProdutos = await _pedidosProdutosRepositorio.BuscarPorId(id);
            return Ok(pedidosProdutos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosProdutosModel>> Adicionar([FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            PedidosProdutosModel pedidosProdutos = await _pedidosProdutosRepositorio.Adicionar(pedidosProdutosModel);
            return Ok(pedidosProdutos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> Atualizar(int id, [FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            pedidosProdutosModel.Id = id;
            PedidosProdutosModel tarefa = await _pedidosProdutosRepositorio.Atualizar(pedidosProdutosModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidosProdutosModel>> Apagar(int id)
        {
            bool apagado = await _pedidosProdutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
