using AtvApi01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtvApi01.Data.Map
{
    public class CategoriasMap : IEntityTypeConfiguration<CategoriasModel>
    {
        public void Configure(EntityTypeBuilder<CategoriasModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
