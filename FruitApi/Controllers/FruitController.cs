using FruitApi.Configuration;
using FruitApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FruitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    // TODO: this endpoint should be secured by a Policy, e.g: [Autorize(Policy = Policies.AuthorizationPolicyNames.AllowedClients)]
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
            if (string.IsNullOrEmpty(fruit))
            {
                return BadRequest("No model (fruit name) provided");
            }

            var fruitService = new FruitService();

            return new OkObjectResult(await fruitService.GetFruitAsync(fruit, fruitUrls));
        }
    }
}
