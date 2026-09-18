using Carrinho.Compra.Domain.Entities;

public class CarrinhoEntity : EntityBase
{
    public CarrinhoEntity()
    {
        Itens = new List<ItemCarrinhoEntity>();
        DataCriacao = DateTime.UtcNow;
    }

    public DateTime DataCriacao { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Total { get; set; }

    public Guid? CupomId { get; set; }

    public CupomEntity? Cupom { get; set; }

    public ICollection<ItemCarrinhoEntity> Itens { get; set; }
}
        