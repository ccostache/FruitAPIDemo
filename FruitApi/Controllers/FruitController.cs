using FruitApi.Configuration;
using FruitApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FruitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;
        private readonly UrlSettings fruitUrls;

        public FruitController(IFruitService fruitService, IOptions<UrlSettings> options)
        {
            _fruitService = fruitService;
            fruitUrls = options.Value;
        }

        [HttpGet]
        [Route("{fruit}")]
        public async Task<IActionResult> Get([FromRoute] string fruit)
        {
            var fruitService = new FruitService();

            return new OkObjectResult(await fruitService.GetFruitAsync(fruit, fruitUrls));
        }
    }
}
