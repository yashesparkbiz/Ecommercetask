using Ecommercetask.Core.Handlers.DiscountHandler.Command.AddDiscount;
using Ecommercetask.Core.Handlers.DiscountHandler.Command.DeleteDiscount;
using Ecommercetask.Core.Handlers.DiscountHandler.Command.UpdateDiscount;
using Ecommercetask.Core.Handlers.DiscountHandler.Queries.GetAllDiscount;
using Ecommercetask.Core.Handlers.DiscountHandler.Queries.GetDiscountById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class DiscountController : AppApiController
    {
        public DiscountController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("add-discount")]
        public async Task<IActionResult> Add([FromBody] AddDiscountCommand command, CancellationToken ct)
        {
            return Ok( await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-discount")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllDiscountQuery(), ct));
        }

        [HttpGet("get-discountbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetDiscountByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-discount/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteDiscountCommand { Id = Id }, ct));
        }

        [HttpPut("update-discount")]
        public async Task<IActionResult> Update(DiscountModel discountModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateDiscountCommand { discountModel = discountModel }, ct));
        }
    }
}
