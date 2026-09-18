using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Carrinho.Compra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

       

        public async Task<TEntity?> Get(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes =null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
                query = includes(query);
            
            return await query.FirstOrDefaultAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity?> Update(TEntity entity)
        {
            var entityExists = await _dbSet.FindAsync(_context.Entry(entity).Property("Id").CurrentValue);
            if (entityExists == null)
                return null;

            _context.Entry(entityExists).CurrentValues.SetValues(entity);

            return entityExists;

        }

        public async Task<bool> Delete(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return true;

        }

    
    }
}
