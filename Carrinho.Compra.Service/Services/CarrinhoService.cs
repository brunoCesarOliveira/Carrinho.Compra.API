

using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Carrinho.Compra.Service.Services
{
    public class CarrinhoService : IService<CarrinhoModel>
    {
        private readonly IRepository<CarrinhoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarrinhoService(
                IRepository<CarrinhoEntity> repository,
                IUnitOfWork unitOfWork,
                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CarrinhoModel?> Get(Guid id)
        {
            var entity = await _repository.Get(id ,query =>
                                             query.Include(x => x.Itens)
                                                  .ThenInclude(x => x.Produto)
                                                  .Include(x => x.Cupom));

            if (entity == null)
                return null;

            return _mapper.Map<CarrinhoModel>(entity);
        }

        public async Task<IEnumerable<CarrinhoModel>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<CarrinhoModel>>(entities);
        }

        public async Task<CarrinhoModel> Add(CarrinhoModel model)
        {
            var entity = _mapper.Map<CarrinhoEntity>(model);

            foreach (var item in entity.Itens)
            {
                item.CarrinhoId = entity.Id;
            }

            var result = await _repository.Add(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CarrinhoModel>(result);
        }

        public async Task<CarrinhoModel?> Update(CarrinhoModel model)
        {

            var entity = _mapper.Map<CarrinhoEntity>(model);

            var result = await _repository.Update(entity);

            if (result == null)
                return null;

            return _mapper.Map<CarrinhoModel>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

    }
}