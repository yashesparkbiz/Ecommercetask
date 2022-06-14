using Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.AddProductWishlist;
using Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.DeleteProductWishlist;
using Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.UpdateProductWishlist;
using Ecommercetask.Core.Handlers.ProductWishlistHandler.Queries.GetAllProductWishlist;
using Ecommercetask.Core.Handlers.ProductWishlistHandler.Queries.GetProductWishlistById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    public class ProductWishListsController : AppApiController
    {
        public ProductWishListsController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("add-product-wishlist")]
        public async Task<IActionResult> Add([FromBody] AddProductWishlistCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-product-wishlist")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllProductWishlistQuery(), ct));
        }

        [HttpGet("get-product-wishlistbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetProductWishlistByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-product-wishlist/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteProductWishlistCommand { Id = Id }, ct));
        }

        [HttpPut("update-product-wishlist")]
        public async Task<IActionResult> Update(ProductWishlistModel productWishlistModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateProductWishlistCommand { productWishlistModel = productWishlistModel }, ct));
        }
    }
}
