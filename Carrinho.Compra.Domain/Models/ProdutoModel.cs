namespace Carrinho.Compra.Domain.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DescricaoProduto { get; set; } = string.Empty;
        public int QuantidadeEstoque { get; set; }
        public required decimal PrecoLiquido { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
