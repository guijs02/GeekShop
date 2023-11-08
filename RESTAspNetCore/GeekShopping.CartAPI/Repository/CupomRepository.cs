using AutoMapper;
using GeekShopping.CartAPI.Repository.Intrefaces;
using GeekShopping.CupomAPI.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GeekShopping.CartAPI.Repository
{
    public class CupomRepository : ICupomRepository
    {
        private readonly HttpClient _client;
        private const string BasePath = "api/Cupom";

        public CupomRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CupomVO> GetCupomByCupomCode(string cupomCode)
        {

            var response = await _client.GetAsync($"{BasePath}/{cupomCode}");
            var content = await response.Content.ReadAsStringAsync();
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
                return new CupomVO();

            return JsonSerializer.Deserialize<CupomVO>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
