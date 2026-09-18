namespace Carrinho.Compra.Domain.Entities
{
    public class ProdutoEntity: EntityBase
    {
        public string DescricaoProduto { get; set; } = string.Empty;
        public int QuantidadeEstoque { get; set; }
        public required decimal PrecoLiquido { get; set; }  
        public string ImageUrl { get; set; } = string.Empty;   
        public ICollection<ItemCarrinhoEntity> ItensCarrinho { get; set; } = new List<ItemCarrinhoEntity>();    
    }
}
