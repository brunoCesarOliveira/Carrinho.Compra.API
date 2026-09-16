using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<Domain.Entities.CarrinhoEntity> Cestas { get; set; }
        public DbSet<ItemCestaEntity> ItensCarrinho { get; set; }

       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CarrinhoEntity>();

            modelBuilder.Entity<ProdutoEntity>()
                .Property(x => x.Preco)
                .HasPrecision(18, 2);


            modelBuilder.Entity<ItemCestaEntity>()
               .HasOne(x => x.Cesta)
               .WithMany(x => x.Itens)
               .HasForeignKey(x => x.Id)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemCestaEntity>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.ItensCarrinho)
                .HasForeignKey(x => x.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemCestaEntity>()
                .Property(x => x.PrecoUnitario)
                .HasPrecision(18, 2);

            ProdutoSeed.Seed(modelBuilder);
        }
    }
}
