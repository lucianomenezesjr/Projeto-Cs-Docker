using Microsoft.EntityFrameworkCore;

namespace WebAppDocker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações específicas do modelo Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.Id); // Chave primária
                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.Preco)
                      .HasColumnType("decimal(18,2)");
                
                // Exemplo de índice
                entity.HasIndex(p => p.Nome)
                      .IsUnique()
                      .HasDatabaseName("IX_Produtos_Nome");
            });

            // Se tiver outros modelos, adicione as configurações aqui
        }
    }
}