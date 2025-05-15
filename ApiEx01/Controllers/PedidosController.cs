using AtvApi01.Models;
using AtvApi01.Repositorio;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtvApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepositorio _pedidosRepositorio;

        public PedidosController(IPedidosRepositorio pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> BuscarTodosPedidos()
        {
            List<PedidosModel> pedidos = await _pedidosRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosModel>> BuscarPorId(int id)
        {
            PedidosModel pedidos = await _pedidosRepositorio.BuscarPorId(id);
            return Ok(pedidos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosModel>> Adicionar([FromBody] PedidosModel PedidoModel)
        {
            PedidosModel pedidos = await _pedidosRepositorio.Adicionar(PedidoModel);
            return Ok(pedidos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosModel>> Atualizar(int id, [FromBody] PedidosModel PedidoModel)
        {
            PedidoModel.Id = id;
            PedidosModel pedidos = await _pedidosRepositorio.Atualizar(PedidoModel, id);
            return Ok(pedidos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PedidosModel>> Apagar(int id)
        {
            bool apagado = await _pedidosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

