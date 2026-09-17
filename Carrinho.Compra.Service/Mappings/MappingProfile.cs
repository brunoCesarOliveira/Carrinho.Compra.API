using AutoMapper;
using Carrinho.Compra.Domain.Entities;
using Carrinho.Compra.Domain.Models;


namespace Carrinho.Compra.Domain.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoEntity, ProdutoModel>().ReverseMap();
            CreateMap<CarrinhoEntity, CarrinhoModel>().ReverseMap();          
            CreateMap<CupomEntity, CupomModel>().ReverseMap();
            CreateMap<ItemCarrinhoEntity, ItemCarrinhoModel>();

            CreateMap<ItemCarrinhoModel, ItemCarrinhoEntity>()
                .ForMember(dest => dest.Produto, opt => opt.Ignore())
                .ForMember(dest => dest.Carrinho, opt => opt.Ignore());

        

        }
    }
}
