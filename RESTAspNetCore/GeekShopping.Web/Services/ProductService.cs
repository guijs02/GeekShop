using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private const string BasePath = "api/Product";
        private const string ERROR_API = "Something went wrong calling API";
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public async Task<IEnumerable<ProductModel>> FinAllProducts()
        {
            var response = await _http.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }
        public async Task<ProductModel> FindProductById(int id)
        {
            var response = await _http.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _http.PostAsJsonAsync(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception(ERROR_API);

        }
        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _http.PutAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception(ERROR_API);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var response = await _http.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception(ERROR_API);
        }


    }
}
