namespace Carrinho.Compra.Domain.Entities
{
    public class CupomEntity :EntityBase
     {
        public Guid CodigoCupom {get;set;} 
        public decimal PercentualDesconto {get;set;} = 0;   
        public bool Ativo { get; set; }
    }
}
