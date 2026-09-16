namespace Carrinho.Compra.Domain.Models
{
    public class CarrinhoModel
    {
        public Guid Id  { get; set; } = Guid.NewGuid();  
        public DateTime DataCriacao { get; set; }   
        public decimal Subtotal { get; set; }   
        public decimal Total { get; set; }  
        public List<ItemCarrinhoModel> Itens { get; set; } = new List<ItemCarrinhoModel>();
    }
}
