using Ecommercetask.Core.Handlers.ProductCartHandler.Command.AddProductCart;
using Ecommercetask.Core.Handlers.ProductCartHandler.Command.DeleteProductCart;
using Ecommercetask.Core.Handlers.ProductCartHandler.Command.UpdateProductCart;
using Ecommercetask.Core.Handlers.ProductCartHandler.Queries.GetProductCartByUserId;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class ProductCartController : AppApiController
    {
        public ProductCartController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) {}
        [HttpPost("add-product-cart")]
        public async Task<IActionResult> Add([FromBody] AddProductCartCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-product-cartbyuserid/{user_id}")]
        public async Task<IActionResult> GetByUserId(int User_Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetProductCartByUserIdQuery { User_Id = User_Id }, ct));
        }

        [HttpDelete("delete-product-cart/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteProductCartCommand { Id = Id }, ct));
        }

        [HttpPut("update-product-cart")]
        public async Task<IActionResult> Update(ProductCartModel productCartModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateProductCartCommand { productCartModel = productCartModel }, ct));
        }
    }
}
