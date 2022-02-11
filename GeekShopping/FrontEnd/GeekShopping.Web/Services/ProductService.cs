using GeekShopping.Web.Integrations;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/Product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> Save(ProductModel product)
        {
            var response = await _httpClient.PostAsJson(BasePath, product);

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> Update(ProductModel product)
        {
            var response = await _httpClient.PutAsJson(BasePath, product);

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");

            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");

            return await response.ReadContentAs<bool>();
        }
    }
}
