using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Compra.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        readonly IRepository<CarrinhoEntity> _repository;
        private readonly AppDbContext _context;

        public CarrinhoRepository(
            IRepository<CarrinhoEntity> repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
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

        public async Task<CarrinhoEntity?> Get(Guid id, Func<IQueryable<CarrinhoEntity>, IQueryable<CarrinhoEntity>>? includes = null)
        {
            return await _repository.Get(id,includes);
        }
    }
}
