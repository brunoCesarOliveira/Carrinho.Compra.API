using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace Carrinho.Compra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        readonly IRepository<ProdutoEntity> _repository;

        public ProdutoRepository(IRepository<ProdutoEntity> repository)
        {
            _repository = repository;
        }
      
        public async Task<ProdutoEntity?> Get(Guid id, Func<IQueryable<ProdutoEntity>, IQueryable<ProdutoEntity>>? includes = null)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<ProdutoEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ProdutoEntity> Add(ProdutoEntity entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _repository.Delete(Id);
        }

        public async Task<ProdutoEntity?> Update(ProdutoEntity entity)
        {
            return await _repository.Update(entity);
        }


    }
}
