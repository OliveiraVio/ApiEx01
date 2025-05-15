using AtvApi01.Data;
using AtvApi01.Models;
using AtvApi01.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtvApi01.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AtividadeDbContext _dbContext;

        public UsuarioRepositorio(AtividadeDbContext atividadedbContext)
        {
            _dbContext = atividadedbContext;
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);

            if (UsuarioPorId == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            _dbContext.Usuarios.Remove(UsuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);

            if (UsuarioPorId == null)
            {
                throw new Exception($"Usuário do Id: {id} não encontrado.");
            }

            UsuarioPorId.Nome = usuario.Nome;
            UsuarioPorId.Email = usuario.Email;
            UsuarioPorId.DataNas = usuario.DataNas;
            //TarefaPorId.UsuarioId = tarefa.UsuarioId;


            await _dbContext.SaveChangesAsync();

            return UsuarioPorId;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios
                .ToListAsync();
        }
    }
}
