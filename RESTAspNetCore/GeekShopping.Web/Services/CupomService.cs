using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Utils;
using static System.Net.WebRequestMethods;

namespace GeekShopping.Web.Services
{
    public class CupomService : ICupomService
    {
        private readonly HttpClient _http;
        private const string BasePath = "api/Cupom";
        private const string ERROR_API = "Something went wrong calling API";

        public CupomService(HttpClient http)
        {
            _http = http;
        }
        public async Task<CupomViewModel> GetCupom(string code)
        {
            var response = await _http.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new CupomViewModel();
            return await response.ReadContentAs<CupomViewModel>();
        }
    }
}
