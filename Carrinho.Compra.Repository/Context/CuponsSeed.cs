using Carrinho.Compra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrinho.Compra.Repository.Context
{
    public static class CuponsSeed
    {
        public static void SeedCupons( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CupomEntity>().HasData(
                new CupomEntity
                {
                    Id = Guid.NewGuid(),
                    CodigoCupom = Guid.NewGuid(),
                    PercentualDesconto = 10,
                    Ativo = true
                },
                new CupomEntity
                {
                    Id = Guid.NewGuid(),
                    CodigoCupom = Guid.NewGuid(),
                    PercentualDesconto = 15,
                    Ativo = true
                }
                
            );
        }

    }
}
