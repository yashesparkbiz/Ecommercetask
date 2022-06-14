using Ecommercetask.Core.Handlers.ProductHandler.Command.AddProduct;
using Ecommercetask.Core.Handlers.ProductHandler.Command.DeleteProduct;
using Ecommercetask.Core.Handlers.ProductHandler.Command.UpdateProduct;
using Ecommercetask.Core.Handlers.ProductHandler.Queries.GetAllProduct;
using Ecommercetask.Core.Handlers.ProductHandler.Queries.GetProductById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    public class ProductController : AppApiController
    {
        public ProductController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) {}

        [HttpPost("add-product")]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllProductQuery(), ct));
        }

        [HttpGet("get-productbyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-product/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = Id }, ct));
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update(ProductModel productModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand { productModel = productModel }, ct));
        }
    }
}
