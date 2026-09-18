using Carrinho.Compra.Domain.Entities;
namespace Carrinho.Compra.Domain.Interface.Repository
{
    public interface IItemCarrinhoRepository
    {
        Task<ItemCarrinhoEntity> Add(ItemCarrinhoEntity entity);
    }
}
