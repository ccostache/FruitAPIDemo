using FruitApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FruitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        [HttpGet]
        [Route("{fruit}")]
        public async Task<IActionResult> Get([FromRoute] string fruit)
        {
            var fruitService = new FruitService();
            return new OkObjectResult(await fruitService.GetFruitAsync(fruit));
        }
    }
}
