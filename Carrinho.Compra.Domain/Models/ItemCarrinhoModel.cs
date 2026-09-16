namespace Carrinho.Compra.Domain.Models
{
    public class ItemCarrinhoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ProdutoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}



