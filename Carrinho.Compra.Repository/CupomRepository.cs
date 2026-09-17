using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace Carrinho.Compra.Repository
{
    public class CupomRepository : ICupomRepository
    {
        readonly IRepository<CupomEntity> _repository;

        public CupomRepository(IRepository<CupomEntity> repository)
        {
            _repository = repository;
        }

        public async Task<CupomEntity?> Get(Guid id, Func<IQueryable<CupomEntity>, IQueryable<CupomEntity>>? includes = null)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<CupomEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<CupomEntity> Add(CupomEntity entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _repository.Delete(Id);
        }

        public async Task<CupomEntity?> Update(CupomEntity entity)
        {
            return await _repository.Update(entity);
        }

    }


}