using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Shared
{
    
    [ApiController]
    [Route("[controller]")]
    public class AppApiController : ControllerBase
    {
        public readonly ILogger<AppApiController> _logger;
        public readonly IMediator _mediator;

        public AppApiController(ILogger<AppApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}
