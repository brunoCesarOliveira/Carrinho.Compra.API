using Carrinho.Compra.Domain.Entities;
using System.Linq.Expressions;

namespace Carrinho.Compra.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes =null );
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);   
        Task<TEntity?> Update(TEntity entity);    
        Task<bool> Delete(Guid Id);    
    }
}
