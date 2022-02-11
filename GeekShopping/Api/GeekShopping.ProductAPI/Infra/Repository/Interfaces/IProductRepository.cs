using GeekShopping.ProductAPI.Models.Dtos;

namespace GeekShopping.ProductAPI.Infra.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAllAsync();

        Task<ProductDto> FindById(long id);

        Task<ProductDto> Save(ProductDto productDto);

        Task<ProductDto> Update(ProductDto productDto);

        Task<bool> Delete(long id);
    }
}
