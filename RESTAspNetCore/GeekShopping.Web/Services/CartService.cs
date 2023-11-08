using AutoMapper;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _http;
        private const string BasePath = "api/Cart";
        private const string ERROR_API = "Something went wrong calling API";

        public CartService(HttpClient http)
        {
            _http = http;
        }
        public async Task<CartViewModel> AddItemToCart(CartViewModel cart)
        {
            //var content = new StringContent(
            //JsonSerializer.Serialize(cart),
            //Encoding.UTF8,
            //"application/json");

            var response = await _http.PostAsJsonAsync($"{BasePath}/add-cart", cart);
            
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else
                throw new Exception(ERROR_API);
        }

        public async Task<bool> ApplyCoupon(CartViewModel model)
        {
            var response = await _http.PostAsJson($"{BasePath}/apply-cupom", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception(ERROR_API);
        }

        public async Task<bool> RemoveCupom(string userId)
        {
            var response = await _http.DeleteAsync($"{BasePath}/remove-cupom/{userId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception(ERROR_API);
        }

        public async Task<object> Checkout(CartHeaderViewModel cart)
        {
            cart.CupomCode = "GUIRC_2023";
            var response = await _http.PostAsJson($"{BasePath}/checkout", cart);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartHeaderViewModel>();

            }else if (response.StatusCode.ToString().Equals("PreconditionFailed"))
            {
                return "Cupom Price has changed, please confirm!";
            }
            throw new Exception(ERROR_API);
        }

        public async Task<CartViewModel> FindCartByUserId(int id)
        {
            var response = await _http.GetAsync($"{BasePath}/find-cart/{id}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<bool> RemoveFromCart(int id)
        {
            var response = await _http.DeleteAsync($"{BasePath}/remove-cart/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception(ERROR_API);
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart)
        {
            var response = await _http.PutAsJson($"{BasePath}/update-cart",cart);
            return await response.ReadContentAs<CartViewModel>();
        }
    }
}
