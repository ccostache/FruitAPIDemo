using FruitApi.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FruitApi.Services
{
    public class FruitService : IFruitService
    {
        /// <inheritdoc/>
        public async Task<object> GetFruitAsync(string fruit, UrlSettings fruitUrls)
        {
            var c = new HttpClient();

            var apiInfoData = await(await c.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{fruitUrls.FruitInfoUrl}?name={fruit}")
                }))
                .Content.ReadAsStringAsync();

            var data = JObject.Parse(apiInfoData);

            var apiNutritionData = await(await c.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{fruitUrls.FruitNutritionsUrl}?type={fruit}")
                }))
                .Content.ReadAsStringAsync();

            return new
            {
                name = data.SelectToken("name").ToString(),
                categorisation = new
                {
                    genus = data.SelectToken("genus").ToString(),
                    family = data.SelectToken("family").ToString()
                },
                nutritions = apiNutritionData
            };
        }

        /// <inheritdoc/>
        public Task<object> PostFruitAsync(string fruit, UrlSettings fruitUrls)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
