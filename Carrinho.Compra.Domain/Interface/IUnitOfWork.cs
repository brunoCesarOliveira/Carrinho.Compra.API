using Carrinho.Compra.Domain.Interface.Repository;

namespace Carrinho.Compra.Domain.Interface
{
    public interface IUnitOfWork :IDisposable
    {     
        Task<bool> CommitAsync();
    }

}
