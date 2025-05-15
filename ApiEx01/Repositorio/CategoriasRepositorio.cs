using AtvApi01.Data;
using AtvApi01.Models;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiEx01.Repositorio
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly AtividadeDbContext _dbContext;

        public CategoriasRepositorio(AtividadeDbContext atividadedbContext)
        {
            _dbContext = atividadedbContext;
        }
        public async Task<CategoriasModel> Adicionar(CategoriasModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriasModel CategoriasPorId = await BuscarPorId(id);

            if (CategoriasPorId == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            _dbContext.Categorias.Remove(CategoriasPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id)
        {
            CategoriasModel CategoriasPorId = await BuscarPorId(id);

            if (CategoriasPorId == null)
            {
                throw new Exception($"Categoria do Id: {id} não encontrada.");
            }

            CategoriasPorId.Nome = categoria.Nome;
            CategoriasPorId.Status = categoria.Status;

            await _dbContext.SaveChangesAsync();

            return CategoriasPorId;
        }

        public async Task<CategoriasModel> BuscarPorId(int id)
        {
            return await _dbContext.Categorias
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias
               .ToListAsync();
        }
    }
}



