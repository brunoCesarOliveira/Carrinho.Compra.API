namespace Carrinho.Compra.Domain.Interface.Service
{
    public  interface IService<TEntityModel> where TEntityModel :class 
    {
        Task<TEntityModel?> Get(Guid id);
        Task<IEnumerable<TEntityModel>> GetAll();
        Task<TEntityModel> Add(TEntityModel model);
        Task<bool> Delete(Guid Id);
        Task<TEntityModel> Update(TEntityModel model);
    }
}
