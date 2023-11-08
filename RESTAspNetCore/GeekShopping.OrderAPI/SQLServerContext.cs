using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI;
public class SQLServerContext : DbContext
{
    public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
    public DbSet<OrderDetail> Details { get; set; }
    public DbSet<OrderHeader> Headers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}