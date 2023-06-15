using AutoMapper;
using GeekShopping.ProductAPI.Context;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLServerContext _db;
        private IMapper _mapper;
        public ProductRepository(SQLServerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductView>> FindAll()
        {
            return _mapper.Map<List<ProductView>>(await _db.Products.ToListAsync());
        }

        public async Task<ProductView> FindById(int id)
        {
            return _mapper.Map<ProductView>(await _db.Products.FirstOrDefaultAsync(f => f.Id == id));
        }
        public async Task<ProductView> Create(ProductView pv)
        {
            Product product = _mapper.Map<Product>(pv);
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductView>(product);

        }

        public async Task<ProductView> Update(ProductView pv)
        {
            Product product = _mapper.Map<Product>(pv);
            _db.Products.Update(product);

            await _db.SaveChangesAsync();
            return _mapper.Map<ProductView>(product);

        }
        public async Task<bool> Delete(int id)
        {
            try
            {

                var product = await _db.Products.FirstOrDefaultAsync(f => f.Id == id);

                if (product is null) return false;

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {

                return false;
                throw;
            }

        }
    }
}
