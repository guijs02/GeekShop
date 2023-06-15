using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductView>> FindAll();
        Task<ProductView> FindById(int id);
        Task<ProductView> Create(ProductView pv);
        Task<ProductView> Update(ProductView pv);
        Task<bool> Delete(int id);
    }
}
