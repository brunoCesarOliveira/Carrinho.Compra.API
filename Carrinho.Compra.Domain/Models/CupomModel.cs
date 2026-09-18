namespace Carrinho.Compra.Domain.Models
{
    public class CupomModel
    {
        public Guid Id { get; set; }
        public Guid CodigoCupom { get; set; }
        public decimal PercentualDesconto { get; set; } = 0;
        public bool Ativo { get; set; }
    }
}
