using FruitApi.Configuration;
using FruitApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger Logger;

        private readonly IFruitService _fruitService;
        private readonly UrlSettings _fruitUrls;

        public FruitController(ILogger<FruitController> logger, IFruitService fruitService, IOptions<UrlSettings> options)
        {
            Logger = logger;
            _fruitService = fruitService;
            _fruitUrls = options.Value;
        }

        [HttpGet]
        [Route("{fruit}")]
        public async Task<IActionResult> Get([FromRoute] string fruit)
        {
            if (string.IsNullOrEmpty(fruit))
            {
                Logger.LogWarning($"{nameof(FruitController)} - Invalid model");
                return BadRequest("No model provided");
            }

            return new OkObjectResult(await _fruitService.GetFruitAsync(fruit, _fruitUrls));
        }
    }
}
