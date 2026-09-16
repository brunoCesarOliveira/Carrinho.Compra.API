using Carrinho.Compra.Domain.Interface.Repository;

namespace Carrinho.Compra.Domain.Interface
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<bool> CommitAsync();
    }

}
