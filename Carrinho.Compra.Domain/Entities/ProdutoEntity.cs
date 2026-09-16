namespace Carrinho.Compra.Domain.Entities
{
    public class ProdutoEntity :EntityBase
    {
        public string Nome { get; set; }    =string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get;set; }
        public int Estoque { get; set; }
        public string ImageUrl { get; set; } = string.Empty;   
        public ICollection<ItemCestaEntity> ItensCarrinho { get; set; } = new List<ItemCestaEntity>();    
    }
}
