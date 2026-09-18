using Carrinho.Compra.Domain.Entities;
namespace Carrinho.Compra.Domain.Entities
{
    public class ItemCarrinhoEntity : EntityBase
    {

        public ItemCarrinhoEntity()
        {
        }
        public Guid ProdutoId { get; set; }

        public Guid CarrinhoId { get; set; }

        public int Quantidade { get; set; }

        public CarrinhoEntity Carrinho { get; set; } = null!;

        public ProdutoEntity Produto { get; set; } = null!;
    }
}