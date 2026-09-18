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
            CreateMap<ItemCarrinhoEntity, ItemCarrinhoModel>().ReverseMap();
            CreateMap<CarrinhoModel, CarrinhoEntity>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ItemCarrinhoModel, ItemCarrinhoEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CarrinhoId, opt => opt.Ignore())
                .ForMember(dest => dest.Carrinho, opt => opt.Ignore())
                .ForMember(dest => dest.Produto, opt => opt.Ignore());

        }
    }
}
