using Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.AddOrderDetails;
using Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.DeleteOrderDetails;
using Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.UpdateOrderDetails;
using Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetails;
using Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class OrderDetailsController : AppApiController
    {
        public OrderDetailsController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("add-order-details")]
        public async Task<IActionResult> Add([FromBody] AddOrderDetailsCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-orderdetails")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsQuery(), ct));
        }

        [HttpGet("get-orderdetailsbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetOrderDetailsByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-orderdetailsbyid/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteOrderDetailsCommand { Id = Id }, ct));
        }

        [HttpPut("update-orderdetails")]
        public async Task<IActionResult> Update(OrderDetailsModel orderDetailsModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateOrderDetailsCommand { orderDetailsModel = orderDetailsModel }, ct));
        }
    }
}
