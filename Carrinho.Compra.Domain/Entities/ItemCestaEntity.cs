namespace Carrinho.Compra.Domain.Entities
{
    public class ItemCestaEntity :EntityBase
    { 
        public Guid ProdutoId { get; set; }  
        public int Quantidade { get; set; } 
        public decimal PrecoUnitario { get; set; }  
        public CarrinhoEntity Cesta { get; set; } = null!; 
        public ProdutoEntity Produto { get; set; } = null!;   
    }
}