using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Models;


namespace Carrinho.Compra.Domain.mappings
{

    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoEntity, ProdutoModel>().ReverseMap();
            CreateMap<CarrinhoEntity,CarrinhoModel>().ReverseMap();    
            CreateMap<ItemCestaEntity, ItemCarrinhoModel>().ReverseMap();    
        }
    }
}
