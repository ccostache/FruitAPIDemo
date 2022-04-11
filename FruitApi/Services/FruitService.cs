using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FruitApi.Services
{
    public class FruitService
    {
        private const string FruitInfoUrl = "https://fruitinfo.azurewebsites.net/api/Info";
        private const string FruitNutritionsUrl = "http://fruitnutritions.azurewebsites.net/api/nutritions";

        public async Task<object> GetFruitAsync(string fruit)
        {
            var c = new HttpClient();

            var apiInfoData = await(await c.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{FruitInfoUrl}?name={fruit}")
                }))
                .Content.ReadAsStringAsync();

            var data = JObject.Parse(apiInfoData);

            var apiNutritionData = await(await c.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{FruitNutritionsUrl}?type={fruit}")
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
    }
}
