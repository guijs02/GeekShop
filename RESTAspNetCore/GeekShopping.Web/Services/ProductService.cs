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
        public async Task<IEnumerable<ProductViewModel>> FinAllProducts()
        {
            var response = await _http.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }
        public async Task<ProductViewModel> FindProductById(int id)
        {
            var response = await _http.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {
            var response = await _http.PostAsJsonAsync(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception(ERROR_API);

        }
        public async Task<ProductViewModel> UpdateProduct(ProductViewModel product)
        {
            var response = await _http.PutAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
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
