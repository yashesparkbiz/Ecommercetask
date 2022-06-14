using Ecommercetask.Core.Handlers.CarsHandler.Command;
using Ecommercetask.Core.Helper.CarsHelper.Queries.GetAllCars;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : AppApiController
    {
        public HomeController(ILogger<HomeController> logger, IMediator mediator) : base(logger, mediator) { }
       
        [HttpGet("GetAllCar")]
        public Task<IEnumerable<Car>> GetAllCar(CancellationToken ct)
        {
            return _mediator.Send(new GetAllCarsQuery(), ct);
        }

        //[HttpPost]
        //public Task<string> AddCar([FromBody] CreateCarCommand command, CancellationToken ct)
        //{
        //    return _mediator.Send(command, ct);
        //}
    }
}
