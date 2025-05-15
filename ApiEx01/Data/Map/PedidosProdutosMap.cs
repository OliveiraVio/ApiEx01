using AtvApi01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtvApi01.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoriaId).IsRequired();
            builder.Property(x => x.ProdutoId).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();

        }
    }
}