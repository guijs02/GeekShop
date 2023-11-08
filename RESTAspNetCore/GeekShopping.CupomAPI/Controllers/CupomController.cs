using AutoMapper;
using GeekShopping.CupomAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CupomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository _repository;
        public CupomController(ICupomRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{cupomCode}")]
        public async Task<IActionResult> GetCupomByCupomCode(string cupomCode)
        {
            var cupom = await _repository.GetCupomByCupomCode(cupomCode);
            if(cupom == null)
            {
                return NotFound();
            }
            return Ok(cupom);
        }   
  
    }
}