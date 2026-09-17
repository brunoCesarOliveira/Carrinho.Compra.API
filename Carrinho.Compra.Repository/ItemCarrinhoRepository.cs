using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace Carrinho.Compra.Repository
{
    public class ItemCarrinhoRepository :IItemCarrinhoRepository
    {
        readonly IRepository<ItemCarrinhoEntity> _repository;

        public ItemCarrinhoRepository(IRepository<ItemCarrinhoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ItemCarrinhoEntity?> Get(Guid id, Func<IQueryable<ItemCarrinhoEntity>, IQueryable<ItemCarrinhoEntity>>? includes = null)
        {
            return await _repository.Get(id);
        }
        

        public async Task<IEnumerable<ItemCarrinhoEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ItemCarrinhoEntity> Add(ItemCarrinhoEntity entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Delete(Guid Id)
        {
           return  await _repository.Delete(Id);
        }

        public async Task<ItemCarrinhoEntity?> Update(ItemCarrinhoEntity entity)
        {
           return await _repository.Update(entity);
        }

    
    }
}
