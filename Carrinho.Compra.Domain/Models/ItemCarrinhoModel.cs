namespace Carrinho.Compra.Domain.Models
{
    public class ItemCarrinhoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public ProdutoModel? Produto { get; set; } 

    }
}



