using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infra.Data.Features
{
    public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Codigo);

            builder.Property(p => p.Nome).HasColumnType("nvarchar").HasMaxLength(70).IsRequired();
            builder.Property(p => p.Preco).HasColumnType("float");
        }
    }
}