using FruitApi.Configuration;
using FruitApi.DTO.Endpoints;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FruitApi.Services
{
    public class FruitService : IFruitService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FruitService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // TODO: Change GetFruitAsync to use the AutoMapper and improve method with more logging and exception handling
        public async Task<FruitModel> GetFruitAsync(string fruit, UrlSettings fruitUrls)
        {
            var client = _clientFactory.CreateClient();

            // Instance of the FruitRequestModel
            _ = new FruitModel();

            var apiInfoData = await (await client.SendAsync(new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"{fruitUrls.FruitInfoUrl}?name={fruit}")

            })).Content.ReadAsStringAsync();

            var infoData = JObject.Parse(apiInfoData);

            var apiNutritionData = await (await client.SendAsync(new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"{fruitUrls.FruitNutritionsUrl}?type={fruit}")

            })).Content.ReadAsStringAsync();

            var nutritionData = JObject.Parse(apiNutritionData);

            FruitModel fruitData = new FruitModel(
                Name: infoData.SelectToken("name").ToString(),
                categorisation: new CategorisationModel(
                    Genus: infoData.SelectToken("genus").ToString(),
                    Family: infoData.SelectToken("family").ToString()
                ),
                nutrition: new NutritionModel(
                    Name: nutritionData.SelectToken("name").ToString(),
                    Per: nutritionData.SelectToken("per").ToString(),
                    Cals: nutritionData.SelectToken("cals").ToString(),
                    Protein: nutritionData.SelectToken("protein").ToString(),
                    Fat: nutritionData.SelectToken("fat").ToString(),
                    Sugar: nutritionData.SelectToken("sugar").ToString(),
                    Carbs: nutritionData.SelectToken("carbs").ToString()
            ));

            return fruitData;
        }

        /// <inheritdoc/>
        public Task<FruitModel> PostFruitAsync(string fruit, UrlSettings fruitUrls)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
