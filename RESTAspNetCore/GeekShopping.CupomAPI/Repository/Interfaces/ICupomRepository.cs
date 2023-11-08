using GeekShopping.CupomAPI.Data.ValueObjects;

namespace GeekShopping.CupomAPI.Repository.Interfaces
{
    public interface ICupomRepository
    {
        Task<CupomVO> GetCupomByCupomCode(string cupomCode);
    }
}
