using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CarrinhoEntity> Carrinhos { get; set; }
        public DbSet<ItemCarrinhoEntity> ItensCarrinho { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .Property("Id")
                                .ValueGeneratedNever();
                }
            }
            ;


            modelBuilder.Entity<CarrinhoEntity>()
                        .HasMany(c => c.Itens)
                        .WithOne(i => i.Carrinho)
                        .HasForeignKey(i => i.CarrinhoId)
                        .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CarrinhoEntity>()
                        .HasOne(c => c.Cupom)
                        .WithMany()
                        .HasForeignKey(c => c.CupomId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ItemCarrinhoEntity>()
                        .HasOne(i => i.Produto)
                        .WithMany(p => p.ItensCarrinho)
                        .HasForeignKey(i => i.ProdutoId)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProdutoEntity>()
                        .Property(p => p.PrecoLiquido)
                        .HasPrecision(18, 2);

            ProdutoSeed.SeedProdutos(modelBuilder);
            CuponsSeed.SeedCupons(modelBuilder);
        }
    }
}
