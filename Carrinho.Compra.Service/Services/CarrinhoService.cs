

using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Carrinho.Compra.Repository;
using Microsoft.EntityFrameworkCore;


namespace Carrinho.Compra.Service.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IRepository<CarrinhoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProdutoEntity> _produto;
        public CarrinhoService(
            IRepository<CarrinhoEntity> repository,
            IItemCarrinhoRepository itemCarrinhoRepository,
            IUnitOfWork unitOfWork,
            IRepository<ProdutoEntity> produto,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _produto = produto;
        }

        public async Task<CarrinhoModel?> Get(Guid id)
        {
            var entity = await _repository.Get(id, query =>
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
            if (!await VerificandoEstoque(model))
                return null!;

            var entity = _mapper.Map<CarrinhoEntity>(model);

            entity.DataCriacao = DateTime.UtcNow;

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
            if (!await VerificandoEstoque(model))
                return null!;

            var carrinho = await _repository.Get(model.Id, query => query.Include(x => x.Itens));
            if (carrinho == null)
                return null;

            var itensPorProduto = carrinho.Itens.ToLookup(i => i.ProdutoId);

            foreach (var itemRecibo in model.Itens)
            {
                var itemExistente = itensPorProduto[itemRecibo.ProdutoId].FirstOrDefault();

                if (itemExistente != null)
                {
                    itemExistente.Quantidade += itemRecibo.Quantidade;

                }
                else
                {
                    // Produto ainda não existe
                    carrinho.Itens.Add(new ItemCarrinhoEntity
                    {
                        ProdutoId = itemRecibo.ProdutoId,
                        Quantidade = itemRecibo.Quantidade,
                        CarrinhoId = carrinho.Id,
                    });
                    ;
                }
                carrinho.Subtotal = model.Subtotal;
                carrinho.Total = model.Total;
                carrinho.CupomId = model.CupomId;


            }

            await _unitOfWork.CommitAsync();
            return _mapper.Map<CarrinhoModel>(carrinho);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        private async Task<bool> VerificandoEstoque(CarrinhoModel model)
        {
            var produtoId = model.Itens.Select(x => x.ProdutoId).FirstOrDefault();
            var produto = await _produto.Get(produtoId, null);
            var quantidadeEnvidada = model.Itens.Select(x => x.Quantidade).FirstOrDefault();

            if (produto != null)
            {
                if (quantidadeEnvidada > produto.QuantidadeEstoque)
                    return false;
            }
            produto.QuantidadeEstoque -= quantidadeEnvidada;

            await _produto.Update(produto);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task FinalizarCompra(Guid carrinhoId)
        {
        
            var carrinho = await _repository.Get(carrinhoId, null);

            if (carrinho == null)
                throw new Exception("Carrinho não encontrado.");

            carrinho.Ativo = false;
            carrinho.DataCriacao = DateTime.UtcNow;

            await _repository.Update(carrinho);
            await _unitOfWork.CommitAsync();

        }
    }

}