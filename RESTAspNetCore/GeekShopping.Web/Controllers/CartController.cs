using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICupomService _cupomService;
        public CartController(ILogger<HomeController> logger, IProductService productService, ICartService cartService, ICupomService cupomService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
            _cupomService = cupomService;
        }

        public async Task<IActionResult> CartIndex()
        {

            return View(await FindUserCart());

        }
        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CartViewModel model)
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            //var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.ApplyCoupon(model);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            //var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveCupom(userId);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {

            return View(await FindUserCart());

        }
        [HttpGet]
        public IActionResult Confirmation()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CartViewModel cart)
        {

            var response = await _cartService.Checkout(cart.CartHeader);
            if (response is not null && response.GetType() == typeof(string))
            {
                TempData["Error"] = response;
                return RedirectToAction(nameof(Checkout));
            }
            else if (response != null)
            {
                return RedirectToAction(nameof(Confirmation));
            }
            return View(cart);

        }
        public async Task<CartViewModel> FindUserCart()
        {
            var response = await _cartService.FindCartByUserId();
            if (response.CartHeader != null)
            {
                if (!string.IsNullOrEmpty(response.CartHeader.CupomCode))
                {
                    var cupom = await _cupomService.GetCupom(response.CartHeader.CupomCode);
                    if (cupom.CupomCode is not null)
                    {
                        response.CartHeader.DescontoTotal = cupom.Desconto;
                    }
                }
                foreach (var item in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += (item.Product.Preco * item.Count);
                }
                response.CartHeader.PurchaseAmount -= response.CartHeader.DescontoTotal;
            }
            return response;

        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _cartService.RemoveFromCart(id);

            if (response)
                return RedirectToAction(nameof(CartIndex));

            return View();
        }



        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.FindProductById(id);
            return View(product);
        }
        [HttpPost]
        [ActionName("Details")]
        public async Task<IActionResult> DetailsPost(ProductViewModel model)
        {
            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel()
                {
                    UserId = 1,

                },
            };
            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                Count = model.Count,
                ProductId = model.Id,
                Product = await _productService.FindProductById(model.Id),
                CartHeader = cart.CartHeader

            };
            List<CartDetailViewModel> cartDetails = new()
            {
                cartDetail
            };
            cart.CartDetails = cartDetails;

            var response = await _cartService.AddItemToCart(cart);

            if (response is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
    }
}
