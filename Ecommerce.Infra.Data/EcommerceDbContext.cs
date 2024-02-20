using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= Servidor; Database=Ecommerce;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
