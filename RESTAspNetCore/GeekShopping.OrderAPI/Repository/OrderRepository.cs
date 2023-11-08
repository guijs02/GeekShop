using GeekShopping.CartAPI.Repository.Intrefaces;
using GeekShopping.OrderAPI;
using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<SQLServerContext> _context;
        public OrderRepository(DbContextOptions<SQLServerContext> context)
        {
            _context = context;
        }
        public async Task<bool> AddOrder(OrderHeader header)
        {
            await using var _db = new SQLServerContext(_context);
            _db.Headers.Add(header);
            _db.SaveChanges();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid)
        {
            await using var _db = new SQLServerContext(_context);
            var header = await _db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if(header is not null)
            {
                header.PaymentStatus = paid;
                _db.SaveChanges();
            }
        }
    }
}
