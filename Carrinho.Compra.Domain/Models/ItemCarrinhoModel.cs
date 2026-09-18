using Carrinho.Compra.Domain.Entities;

namespace Carrinho.Compra.Domain.Models
{
    public class ItemCarrinhoModel
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid CarrinhoId { get; set; }           
        public int Quantidade { get; set; }
        public virtual ProdutoModel? Produto { get; set; }      
        public virtual CarrinhoModel? Carrinho { get; set; }    

    }
}



