using AtvApi01.Models;
using AtvApi01.Repositorio;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtvApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _produtosRepositorio;

        public ProdutosController(IProdutosRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodasProdutos()
        {
            List<ProdutosModel> produtos = await _produtosRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int id)
        {
            ProdutosModel produtos = await _produtosRepositorio.BuscarPorId(id);
            return Ok(produtos);
        }

        [HttpPost]

        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel ProdutoModel)
        {
            ProdutosModel produtos = await _produtosRepositorio.Adicionar(ProdutoModel);
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel ProdutoModel)
        {
            ProdutoModel.Id = id;
            ProdutosModel produtos = await _produtosRepositorio.Atualizar(ProdutoModel, id);
            return Ok(produtos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _produtosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}