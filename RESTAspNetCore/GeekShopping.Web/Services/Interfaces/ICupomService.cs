using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface ICupomService
    {
        Task<CupomViewModel> GetCupom(string code);
    }
}
