using GeekShopping.CartAPI.Data.ValueObjects;

namespace GeekShopping.CartAPI.Repository.Intrefaces
{
    public interface ICartRepository
    {
        Task<CartVO> FindCartByUserId(int userId);
        Task<CartVO> SaveOrUpdateCart(CartVO userId);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCupom(string userId);
    }
}
