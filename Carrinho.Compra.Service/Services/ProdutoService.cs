

using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.VisualBasic;

namespace Carrinho.Compra.Service.Services
{
    public class ProdutoService : IService<ProdutoModel>
    {
        private readonly IRepository<ProdutoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(
            IRepository<ProdutoEntity> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoModel?> Get(Guid id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
                return null;
            
            return _mapper.Map<ProdutoModel>(entity);
        }

        public async Task<IEnumerable<ProdutoModel>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ProdutoModel>>(entities);
        }

        public async Task<ProdutoModel> Add(ProdutoModel model)
        {
            var entity = _mapper.Map<ProdutoEntity>(model);

            var result = await _repository.Add(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ProdutoModel>(result);
        }

        public async Task<ProdutoModel?> Update(ProdutoModel model)
        {

            var entity = _mapper.Map<ProdutoEntity>(model);

            var result = await _repository.Update(entity);

            if (result == null)
                return null;

            return _mapper.Map<ProdutoModel>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
