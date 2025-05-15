using AtvApi01.Data.Map;
using AtvApi01.Models;
using Microsoft.EntityFrameworkCore;

namespace AtvApi01.Data
{
    public class AtividadeDbContext : DbContext
    {
        public AtividadeDbContext(DbContextOptions<AtividadeDbContext> options) : base(options)
        {
        }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<CategoriasModel> Categorias { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
