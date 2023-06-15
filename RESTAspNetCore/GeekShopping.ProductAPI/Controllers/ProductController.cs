using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repository)
        {
            _repo = repository;
        }
        [HttpGet]
        public async Task<ActionResult<ProductView>> FindAll()
        {
            var products = await _repo.FindAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductView>> FindById(int id)
        {
            var product = await _repo.FindById(id);
            if (product is null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductView>> Create(ProductView pv)
        {
            if (pv is null) return BadRequest();
            var product = await _repo.Create(pv);
            return Ok(product);
        }
        [HttpPut]
        public async Task<ActionResult<ProductView>> Update(ProductView pv)
        {
            if (pv is null) return BadRequest();
            var product = await _repo.Update(pv);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _repo.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
