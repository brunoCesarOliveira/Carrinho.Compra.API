using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;

namespace Carrinho.Compra.Repository
{
    public class ItemCestaRepository :IItemCestaRepository
    {
        readonly IRepository<ItemCestaEntity> _repository;

        public ItemCestaRepository(IRepository<ItemCestaEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ItemCestaEntity?> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<ItemCestaEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ItemCestaEntity> Add(ItemCestaEntity entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Delete(Guid Id)
        {
           return  await _repository.Delete(Id);
        }

        public async Task<ItemCestaEntity?> Update(ItemCestaEntity entity)
        {
           return await _repository.Update(entity);
        }     
       
    }
}
