using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetProductSubCategoryById
{
    public class GetProductSubCategoryByIdQuery : IRequest<ProductSubCategoryModel>
    {
        public int Id { get; set; }
    }

    public class GetProductSubCategoryByIdHandler : IRequestHandler<GetProductSubCategoryByIdQuery, ProductSubCategoryModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductSubCategoryByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<ProductSubCategoryModel> Handle(GetProductSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var productsubcategorybyid = await _db.Product_subcategory.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var productsubcategory = new ProductSubCategoryModel()
            {
                Id = productsubcategorybyid.Id,
                Name = productsubcategorybyid.Name,
                Categoryid = productsubcategorybyid.Category_Id,
            };
            return productsubcategory;
        }
    }
}
