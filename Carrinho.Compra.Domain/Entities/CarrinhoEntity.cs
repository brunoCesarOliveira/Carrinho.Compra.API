namespace Carrinho.Compra.Domain.Entities
{
    public class CarrinhoEntity : EntityBase
    {
        public DateTime DataCriacao { get; set; }
        public ICollection<ItemCestaEntity> Itens { get; set; } = new List<ItemCestaEntity>();
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
