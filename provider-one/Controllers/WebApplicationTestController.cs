using Microsoft.AspNetCore.Mvc;
using TestTask;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeachController : ControllerBase
    {

        private readonly ILogger<SeachController> _logger;

        public SeachController(ILogger<SeachController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ProviderOneSearchRequest")]
        public ProviderOneSearchResponse Get([FromQuery]ProviderOneSearchRequest request)
        {
            return new ProviderOneSearchResponse
            {
                Routes = new ProviderOneRoute[]{
                    new ProviderOneRoute
                    {
                        //request in Runtime
                        From= request.From,
                        To= request.To,
                        //nearest to request.DateFrom from inner logic in Runtime 
                        DateFrom = request.DateFrom,
                        //from inner logic in Runtime 
                        DateTo = DateTime.Now.Date.AddDays(1),
                        Price=Random.Shared.Next(0,9),
                        TimeLimit=DateTime.UtcNow.AddDays(1)
                    }
                  }
            };
        }
    }
}