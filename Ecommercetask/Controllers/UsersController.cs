using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    public class UsersController : AppApiController
    {
        public UsersController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        //public IActionResult Add([FromBody] AddAddressCommand command, CancellationToken ct)
        //{
        //    return View();
        //}
    }
}
