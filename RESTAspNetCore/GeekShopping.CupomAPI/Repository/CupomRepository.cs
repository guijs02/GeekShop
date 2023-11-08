using AutoMapper;
using GeekShopping.CupomAPI.Data.ValueObjects;
using GeekShopping.CupomAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CupomAPI.Repository
{
    public class CupomRepository : ICupomRepository
    {
        private readonly SQLServerContext _db;
        private IMapper _mapper;
        public CupomRepository(SQLServerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CupomVO> GetCupomByCupomCode(string cupomCode)
        {
            var cupom = await _db.Cupom.FirstOrDefaultAsync(c => c.CupomCode == cupomCode);
            return _mapper.Map<CupomVO>(cupom);
        }
    }
}
