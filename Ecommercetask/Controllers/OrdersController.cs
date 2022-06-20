using Ecommercetask.Core.Handlers.OrdersHandler.Command.AddOrders;
using Ecommercetask.Core.Handlers.OrdersHandler.Command.DeleteOrders;
using Ecommercetask.Core.Handlers.OrdersHandler.Command.UpdateOrders;
using Ecommercetask.Core.Handlers.OrdersHandler.Queries.GetAllOrders;
using Ecommercetask.Core.Handlers.OrdersHandler.Queries.GetOrdersById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class OrdersController : AppApiController
    {
        public OrdersController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) {}

        [HttpPost("add-orders")]
        public async Task<IActionResult> Add([FromBody] AddOrdersCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-orders")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(), ct));
        }

        [HttpGet("get-orderbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-orderbyid/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteOrdersCommand { Id = Id }, ct));
        }

        [HttpPut("update-order")]
        public async Task<IActionResult> Update(OrdersModel ordersModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateOrdersCommand { ordersModel = ordersModel }, ct));
        }
    }
}
