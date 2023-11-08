using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Repository.Intrefaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly SQLServerContext _db;
        private IMapper _mapper;
        public CartRepository(SQLServerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var header = await _db.CartHeaders.FirstOrDefaultAsync(c => c.Id.ToString() == userId);

            if (header is not null)
            {
                header.CupomCode = couponCode;
                _db.CartHeaders.Update(header);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
 
        public async Task<bool> ClearCart(string userId = "")
        {
            var cartHeader = await _db.CartHeaders.FirstOrDefaultAsync();

            if (cartHeader is not null)
            {
                _db.CartDetails.RemoveRange(_db.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));
                _db.CartHeaders.Remove(cartHeader);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartVO> FindCartByUserId(int userId)
        {
            Cart cart = new()
            {
                CartHeader = await _db.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId) ?? new CartHeader()
            };

            cart.CartDetails = _db.CartDetails
                                    .Include(c => c.Product);

            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                var cartDetail = await _db.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = _db.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _db.CartDetails.Remove(cartDetail);

                if (total == 1)
                {
                    var cartHeaderToRemove = await _db.CartHeaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    _db.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO vo)
        {
            try
            {

                Cart cart = _mapper.Map<Cart>(vo);
                var product = await _db.Products.FirstOrDefaultAsync(f => f.Id == vo.CartDetails.FirstOrDefault().Product.Id);

                if (product is null)
                {
                    _db.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                    await _db.SaveChangesAsync();
                }
                var cartHeader = await _db.CartHeaders.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);

                if (cartHeader is null)
                {
                    _db.CartHeaders.Add(cart.CartHeader);
                    await _db.SaveChangesAsync();
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _db.SaveChangesAsync();

                }
                else
                {
                    var cartDetail = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                        p => p.Product.Id == vo.CartDetails.FirstOrDefault().ProductId &&
                        p.CartHeaderId == cartHeader.Id);

                    if (cartDetail is null)
                    {
                        cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                        cart.CartDetails.FirstOrDefault().Product = null;
                        _db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                        await _db.SaveChangesAsync();

                    }
                    else
                    {
                        cart.CartDetails.FirstOrDefault().Product = null;
                        cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                        cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                        cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                        _db.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                        await _db.SaveChangesAsync();

                    }
                }

                return _mapper.Map<CartVO>(cart);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<bool> RemoveCupom(string userId)
        {
            var header = await _db.CartHeaders
                  .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
            if (header != null)
            {
                header.CupomCode = "";
                _db.CartHeaders.Update(header);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
