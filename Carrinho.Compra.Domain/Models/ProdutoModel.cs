namespace Carrinho.Compra.Domain.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string DescricaoProduto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public required decimal PrecoLiquido { get; set; }
    }
}
