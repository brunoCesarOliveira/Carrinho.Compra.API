using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;

namespace Carrinho.Compra.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        readonly IRepository<CarrinhoEntity> _repository;

        public CarrinhoRepository(IRepository<CarrinhoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<CarrinhoEntity?> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<CarrinhoEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<CarrinhoEntity> Add(CarrinhoEntity entity)
        {
           return await _repository.Add(entity);
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _repository.Delete(Id);
        }
    
        public async Task<CarrinhoEntity?> Update(CarrinhoEntity entity)
        {
            return await _repository.Update(entity);
        }

    }
}
