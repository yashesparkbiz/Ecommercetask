using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.AddProductSubCategory;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.DeleteProductSubCategory;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.UpdateProductSubCategory;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubcategoriesByProductCategoryId;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategory;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetProductSubCategory;
using Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetProductSubCategoryById;
using Ecommercetask.Data.Model;
using Ecommercetask.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercetask.Controllers
{
    
    public class ProductSubCategoryController : AppApiController
    {
        public ProductSubCategoryController(ILogger<AppApiController> logger, IMediator mediator) : base(logger, mediator) {}

        [HttpPost("add-product-subcategory")]
        public async Task<IActionResult> Add([FromBody] AddProductSubCategoryCommand command, CancellationToken ct)
        {
            return Ok(await _mediator.Send(command, ct));
        }

        [HttpGet("get-all-product-subcategory")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            //throw new System.Exception("An error occurred");
            return Ok(await _mediator.Send(new GetAllProductSubCategoryQuery(), ct));
        }

        [HttpGet("get-all-product-subcategory-withcategoryname")]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            //throw new System.Exception("An error occurred");
            return Ok(await _mediator.Send(new GetProductSubCategoryQuery(), ct));
        }

        [HttpGet("get-product-subcategorybyid/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetProductSubCategoryByIdQuery { Id = Id }, ct));
        }

        [HttpGet("get-product-subcategorybycategoryid/{Category_Id}")]
        public async Task<IActionResult> GetByCategoryId(int Category_Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetAllProductSubcategoriesByProductCategoryIdQuery { Category_Id = Category_Id }, ct));
        }

        [HttpDelete("delete-product-subcategorybyid/{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new DeleteProductSubCategoryCommand { Id = Id }, ct));
        }

        [HttpPut("update-product-subcategory")]
        public async Task<IActionResult> Update(ProductSubCategoryModel productSubCategoryModel, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new UpdateProductSubCategoryCommand { productSubCategoryModel = productSubCategoryModel }, ct));
        }
    }
}