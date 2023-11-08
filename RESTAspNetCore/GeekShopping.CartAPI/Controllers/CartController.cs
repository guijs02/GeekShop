using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.RabbitMQSender;
using GeekShopping.CartAPI.Repository.Intrefaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {

        private readonly ICartRepository _cartRepository;
        private readonly ICupomRepository _cupomRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
      
        public CartController(ICartRepository cartRepository, 
                              ICupomRepository cupomRepository, 
                              IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _cartRepository = cartRepository;
            _cupomRepository = cupomRepository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindById(int id)
        {
            var product = await _cartRepository.FindCartByUserId(id);
            if (product is null) return NotFound();
            return Ok(product);
        }
        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart is null) return NotFound();
            return Ok(cart);
        }
        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> Update(CartVO vo)
        {
            if (vo is null) return BadRequest();
            var product = await _cartRepository.SaveOrUpdateCart(vo);
            return Ok(product);
        }
        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpPost("checkout")]
        public async Task<ActionResult<bool>> Checkout(CheckoutHeaderVO vo)
        {
            var cart = await _cartRepository.FindCartByUserId(vo.UserId);
            if (cart is null) return NotFound();
            if (!string.IsNullOrEmpty(vo.CupomCode))
            {
                var cupom = await _cupomRepository.GetCupomByCupomCode(vo.CupomCode);
                //if(vo.DescontoTotal != cupom.Desconto)
                //{
                //    return StatusCode(412);
                //}
            }
            vo.CartDetails = cart.CartDetails;

            //RabbitMQ starts here!!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            await _cartRepository.ClearCart(string.Empty);
            return Ok(vo);
        }

        [HttpPost("apply-cupom")]
        public async Task<IActionResult> GetCupomByCupomCode(CartVO vo)
        {
            var cupom = await _cartRepository.ApplyCoupon(vo.CartHeader.UserId.ToString(), vo.CartHeader.CupomCode);
            if (!cupom)
            {
                return NotFound();
            }
            return Ok(cupom);
        }

        [HttpDelete("remove-cupom/{userId}")]
        public async Task<IActionResult> GetCupomByCupomCode(string userId)
        {
            var status = await _cartRepository.RemoveCupom(userId);
            if (!status)
            {
                return NotFound();
            }
            return Ok(status);
        }

    }
}