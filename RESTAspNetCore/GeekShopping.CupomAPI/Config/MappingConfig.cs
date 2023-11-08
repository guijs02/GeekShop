using AutoMapper;
using GeekShopping.CupomAPI.Data.ValueObjects;
using GeekShopping.CupomAPI.Model;

namespace GeekShopping.CupomAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CupomVO, Cupom>().ReverseMap();
          
            });
            return mappingConfig;
        }
    }
}
