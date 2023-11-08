

using GeekShopping.CupomAPI.Data.ValueObjects;

namespace GeekShopping.CartAPI.Repository.Intrefaces
{
    public interface ICupomRepository
    {
        Task<CupomVO> GetCupomByCupomCode(string cupomCode);
    }
}
