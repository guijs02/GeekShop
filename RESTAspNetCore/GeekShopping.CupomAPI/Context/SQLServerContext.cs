using GeekShopping.CupomAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CupomAPI
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

        public DbSet<Cupom> Cupom { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cupom>().HasData(new Cupom
            {
                Id = 1,
                CupomCode = "GUIRC_2023" ,
                Desconto = 10

            });
        }

    }
}
