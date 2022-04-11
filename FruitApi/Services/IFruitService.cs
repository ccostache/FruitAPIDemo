using FruitApi.Configuration;
using System.Threading.Tasks;

namespace FruitApi.Services
{
    public interface IFruitService
    {
        /// <summary>
        /// Method to GET the properties of the fruit from the services
        /// </summary>
        /// <param name="fruit">Fruit, e.g apple</param>
        /// <param name="fruitUrls">Represents the urlinfo and urlnutrition from the appsettings</param>
        /// <returns></returns>
        public Task<object> GetFruitAsync(string fruit, UrlSettings fruitUrls);

        /// <summary>
        /// Method to POST a fruit information to the services
        /// </summary>
        /// <param name="fruit">Fruit e.g apple</param>
        /// <param name="fruitUrls">Represents the urlinfo and urlnutrition from the appsettings</param>
        /// <returns></returns>
        public Task<object> PostFruitAsync(string fruit, UrlSettings fruitUrls);
    }
}
