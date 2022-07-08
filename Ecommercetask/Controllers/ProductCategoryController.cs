using Ecommercetask.Core.Handlers.ProductCategoryHandler.Command;
using Ecommercetask.Core.Handlers.ProductCategoryHandler.Command.DeleteProductCategory;
using Ecommercetask.Core.Handlers.ProductCategoryHandler.Command.UpdateProductCategory;
using Ecommercetask.Core.Handlers.ProductCategoryHandler.Queries.GetCategoryIdBySubcategoryId;
using Ecommercetask.Core.Handlers.ProductCategoryHandler.Queries.GetProductCategoryById;
using Ecommercetask.Core.Helper.ProductCategoryHelper.Queries.GetAllProductCategory;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    public class ProductCategoryController : AppApiController
    {
        public ProductCategoryController(ILogger<HomeController> logger, IMediator mediator) : base(logger, mediator) { }
        //[Authorize]
        [HttpGet("get-all-productcategory")]
        public async Task<IActionResult> GetAllProductCategory(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllProductCategoryQuery(), ct));
        }

        [HttpGet("get-id-bysubcategoryid/{Subcategory_Id}")]
        public async Task<IActionResult> GetCategoryIdBySubcategoryId(int Subcategory_Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetCategoryIdBySubcategoryIdQuery { Subcategory_Id = Subcategory_Id }, ct));
        }

        [HttpPost("add-productcategory")]
        public async Task<IActionResult> AddProductCategory([FromBody] AddProductCategoryCommand command, CancellationToken ct)
        {  
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-productcategorybyid/{Id}")]
        public async Task<IActionResult> GetProductCategoryById(int Id ,CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetProductCategoryByIdQuery { Id = Id }, ct));
        }

        [HttpDelete("delete-productcategorybyid/{Id}")]
        public async Task<IActionResult> DeleteProductCategoryById(int Id , CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteProductCategoryCommand { Id = Id }, ct));
        }

        [HttpPut("update-productcategory")]
        public async Task<IActionResult> UpdateProductCategoryById(ProductCategoryModel productCategoryModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateProductCategoryCommand { productCategoryModel = productCategoryModel }, ct));
        }
    }
}