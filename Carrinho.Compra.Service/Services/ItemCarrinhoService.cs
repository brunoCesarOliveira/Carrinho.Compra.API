

using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Carrinho.Compra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Carrinho.Compra.Service.Services
{
    public class ItemCarrinhoService
    {
        
        private IRepository<ItemCarrinhoEntity> _repository;
        public ItemCarrinhoService(IRepository<ItemCarrinhoEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> RemoverItemProduto(Guid itemProdutoId) 
        {

            return await _repository.Delete(itemProdutoId);
        }
    }
}