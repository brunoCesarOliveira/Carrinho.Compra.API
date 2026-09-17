using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository.Context
{
    public static class ProdutoSeed
    {
        public static void SeedProdutos(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProdutoEntity>().HasData(

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Notebook Dell Inspiron",
                        PrecoLiquido= 3500.00m,
                        QuantidadeEstoque = 100,
                        ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Smartphone Samsung Galaxy",
                        PrecoLiquido = 1899.90m,
                        QuantidadeEstoque = 50,
                        ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Apple AirPods",
                        PrecoLiquido = 999.90m,
                        QuantidadeEstoque = 150,
                        ImageUrl = "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Teclado Mecânico",
                        PrecoLiquido = 299.90m,
                        QuantidadeEstoque = 60,
                        ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Mouse Gamer",
                        PrecoLiquido = 159.90m,
                        QuantidadeEstoque = 200,
                        ImageUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Monitor 24 Polegadas",
                        PrecoLiquido = 899.90m,
                        QuantidadeEstoque = 30,
                        ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Smart TV 50 Polegadas",
                        PrecoLiquido = 2499.90m,
                        QuantidadeEstoque= 255,
                        ImageUrl = "https://images.unsplash.com/photo-1593359677879-a4bb92f829d1"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Câmera Digital",
                        PrecoLiquido = 2199.90m,
                        QuantidadeEstoque = 30,
                        ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Console Gamer",
                        PrecoLiquido = 3999.90m,
                        QuantidadeEstoque = 50,
                        ImageUrl = "https://images.unsplash.com/photo-1606813907291-d86efa9b94db"
                    },

                    new ProdutoEntity
                    {

                        Id = Guid.NewGuid(),
                        DescricaoProduto = "Headset Gamer",
                        PrecoLiquido = 349.90m,
                        QuantidadeEstoque = 60,
                        ImageUrl = "https://images.unsplash.com/photo-1599669454699-248893623440"
                    });
        }
    }
}
