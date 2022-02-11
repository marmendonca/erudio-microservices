using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);

        Task<ProductModel> Save(ProductModel product);

        Task<ProductModel> Update(ProductModel product);

        Task<bool> Delete(long id);
    }
}
