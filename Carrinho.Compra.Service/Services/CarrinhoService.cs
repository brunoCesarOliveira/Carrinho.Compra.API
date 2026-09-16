using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;

namespace Carrinho.Compra.Service.Services
{
    public class CarrinhoService : IService<CarrinhoModel>
    {
        public IRepository<Domain.Entities.CarrinhoEntity> _repository;
        public IMapper _mapper;

        public CarrinhoService(IRepository<Domain.Entities.CarrinhoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarrinhoModel?> Get(Guid Id)
        {
            var entity = await _repository.Get(Id);
            if (entity == null)
                return null;
            
            return _mapper.Map<CarrinhoModel>(entity);
        }

        public async Task<IEnumerable<CarrinhoModel>> GetAll()
        {
            var cesta = await _repository.GetAll();

            if (cesta == null)
                return new List<CarrinhoModel>();

            return _mapper.Map<IEnumerable<CarrinhoModel>>(cesta);
        }

        public async Task<CarrinhoModel> Add(CarrinhoModel cestaModel)
        {
            var carrinho = _mapper.Map<CarrinhoEntity>(cestaModel);
            var model = await _repository.Add(carrinho);

            return _mapper.Map<CarrinhoModel>(model);
        }

        public async Task<bool> Delete(Guid Id)
        {
            var cesta = await Delete(Id);

            if (!cesta)
                return false;
            return true;



        }

        public async Task<CarrinhoModel> Update(CarrinhoModel model)
        {
            var cestaModel = _mapper.Map<CarrinhoEntity>(model);
            var cesta = await _repository.Update(cestaModel);

            return _mapper.Map<CarrinhoModel>(cesta);

        }

    }
}
