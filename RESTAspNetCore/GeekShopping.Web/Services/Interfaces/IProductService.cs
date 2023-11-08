﻿using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> FinAllProducts();
        Task<ProductViewModel> FindProductById(int id);
        Task<ProductViewModel> CreateProduct(ProductViewModel product);
        Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProduct(int id);
    }
}
