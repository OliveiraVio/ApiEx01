using AtvApi01.Models;
using AtvApi01.Repositorio;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtvApi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;

        public CategoriasController(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodasCategorias()
        {
            List<CategoriasModel> categorias = await _categoriasRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasModel>> BuscarPorId(int id)
        {
            CategoriasModel categorias = await _categoriasRepositorio.BuscarPorId(id);
            return Ok(categorias);
        }

        [HttpPost]

        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel categoriaModel)
        {
            CategoriasModel categorias = await _categoriasRepositorio.Adicionar(categoriaModel);
            return Ok(categorias);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriasModel>> Atualizar(int id, [FromBody] CategoriasModel categoriaModel)
        {
            categoriaModel.Id = id;
            CategoriasModel categorias = await _categoriasRepositorio.Atualizar(categoriaModel, id);
            return Ok(categorias);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CategoriasModel>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
