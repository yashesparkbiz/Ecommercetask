using Ecommercetask.Core.Helper.ProductCategoryHelper.Queries.GetAllProductCategory;
using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductCategoryHandler.Queries.GetProductCategoryById
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryModel> 
    {
          public int Id { get; set; }   
    }

    public class GetProductCategoryByIdHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryModel> 
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductCategoryByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<ProductCategoryModel> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            
            var productcategorybyid = await _db.Product_category.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var productcategory = new ProductCategoryModel()
            {
                Id =  productcategorybyid.Id,
                Name = productcategorybyid.Name,
                Is_Active = productcategorybyid.Is_Active,
            };
            return productcategory;
        }
    }
}
