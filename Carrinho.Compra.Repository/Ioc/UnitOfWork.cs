using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Repository.Context;

namespace Carrinho.Compra.Repository.Ioc
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly Dictionary<Type, object> _repositories = new ();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;          
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(type, repository);

            return (IRepository<TEntity>)_repositories[type];  
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }     

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
