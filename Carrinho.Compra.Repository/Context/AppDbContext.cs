using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CarrinhoEntity> Carrinhos { get; set; }
        public DbSet<ItemCarrinhoEntity> ItensCarrinho { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CarrinhoEntity>();

            modelBuilder.Entity<ProdutoEntity>()
                .Property(x => x.PrecoLiquido)
                .HasPrecision(18, 2);


            modelBuilder.Entity<ItemCarrinhoEntity>()
               .HasOne(x => x.Carrinho)
               .WithMany(x => x.Itens)
               .HasForeignKey(x => x.Id)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.ItensCarrinho)
                .HasForeignKey(x => x.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
         

            ProdutoSeed.SeedProdutos(modelBuilder);
            CuponsSeed.SeedCupons(modelBuilder);
        }
    }
}
