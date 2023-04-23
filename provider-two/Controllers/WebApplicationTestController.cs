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

        [HttpGet(Name = "ProviderTwoSearchRequest")]
        public ProviderTwoSearchResponse Get([FromQuery] ProviderTwoSearchRequest request)
        {
            return new ProviderTwoSearchResponse
            {
                Routes = new ProviderTwoRoute[]{
                    new ProviderTwoRoute
                    {
                        //request in Runtime Во входных данных нет время прибытия, посчитал что это DepartureDate
                        Arrival = new ProviderTwoPoint{ Date=request.DepartureDate , Point = request.Arrival} ,
                        //nearest to request.DepartureDate from inner logic in Runtime 
                        Departure =new ProviderTwoPoint{ Date=request.DepartureDate, Point = request.Departure} ,
                        //from inner logic in Runtime 
                        Price = 0,
                        TimeLimit=DateTime.UtcNow.AddDays(1)
                    }
                  }
            };
        }
    }
}