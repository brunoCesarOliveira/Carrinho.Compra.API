namespace Carrinho.Compra.Domain.Interface.Service
{
    public  interface IService<TModel> where TModel : class
    {
        Task<TModel?> Get(Guid id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> Add(TModel model);
        Task<bool> Delete(Guid id);
        Task<TModel> Update(TModel model);
    }
}
