

using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;

namespace Carrinho.Compra.Service.Services
{
    public class CupomService : IService<CupomModel>
    {
        private readonly IRepository<CupomEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CupomService(
            IRepository<CupomEntity> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CupomModel?> Get(Guid id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
                return null;

            return _mapper.Map<CupomModel>(entity);
        }

        public async Task<IEnumerable<CupomModel>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<CupomModel>>(entities);
        }

        public async Task<CupomModel> Add(CupomModel model)
        {
           var entity = _mapper.Map<CupomEntity>(model);

            var result = await _repository.Add(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CupomModel>(result);
        }

        public async Task<CupomModel?> Update(CupomModel model)
        {

            var entity = _mapper.Map<CupomEntity>(model);

            var result = await _repository.Update(entity);

            if (result == null)
                return null;

            return _mapper.Map<CupomModel>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
