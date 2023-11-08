using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(int userId = 1);
        Task<CartViewModel> AddItemToCart(CartViewModel cart);
        Task<CartViewModel> UpdateCart(CartViewModel cart);
        Task<bool> RemoveFromCart(int id);
        Task<bool> ApplyCoupon(CartViewModel model);
        Task<object> Checkout(CartHeaderViewModel cart);
        Task<bool> RemoveCupom(string userId);
    }
}
