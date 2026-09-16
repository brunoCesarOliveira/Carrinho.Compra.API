using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository.Context
{
    public static class ProdutoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProdutoEntity>().HasData(

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Notebook Dell Inspiron",
                        Preco = 3500.00m,
                        Descricao = "Notebook Dell para trabalho e estudos",
                        ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Smartphone Samsung Galaxy",
                        Preco = 1899.90m,
                        Descricao = "Smartphone Samsung Galaxy",
                        ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Apple AirPods",
                        Preco = 999.90m,
                        Descricao = "Fone de ouvido sem fio",
                        ImageUrl = "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Teclado Mecânico",
                        Preco = 299.90m,
                        Descricao = "Teclado mecânico para computador",

                        ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Mouse Gamer",
                        Preco = 159.90m,
                        Descricao = "Mouse gamer com alta precisão",
                        ImageUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Monitor 24 Polegadas",
                        Preco = 899.90m,
                        Descricao = "Monitor Full HD de 24 polegadas",
                        ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Smart TV 50 Polegadas",
                        Preco = 2499.90m,
                        Descricao = "Smart TV 4K",
                        ImageUrl = "https://images.unsplash.com/photo-1593359677879-a4bb92f829d1"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Câmera Digital",
                        Preco = 2199.90m,
                        Descricao = "Câmera digital profissional",
                        ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32"
                    },

                    new ProdutoEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Console Gamer",
                        Preco = 3999.90m,
                        Descricao = "Console para jogos",
                        ImageUrl = "https://images.unsplash.com/photo-1606813907291-d86efa9b94db"
                    },

                    new ProdutoEntity
                    {

                        Id = Guid.NewGuid(),
                        Nome = "Headset Gamer",
                        Preco = 349.90m,
                        Descricao = "Headset gamer com microfone",
                        ImageUrl = "https://images.unsplash.com/photo-1599669454699-248893623440"
                    });
        }
    }
}
