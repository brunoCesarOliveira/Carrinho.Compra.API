namespace Carrinho.Compra.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);   
        Task<TEntity?> Update(TEntity entity);    
        Task<bool> Delete(Guid Id);    
    }
}
