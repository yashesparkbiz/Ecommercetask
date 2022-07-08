using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategory
{
    public class GetAllProductSubCategoryQuery : IRequest<IEnumerable<ProductSubCategoryModel>> { }

    public class GetAllProductSubCategoryHandler : IRequestHandler<GetAllProductSubCategoryQuery, IEnumerable<ProductSubCategoryModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllProductSubCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductSubCategoryModel>> Handle(GetAllProductSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var productsubcategory = new List<ProductSubCategoryModel>();
            var allproductsubcategory = await _db.Product_subcategory.ToListAsync();
            if (allproductsubcategory?.Any() == true)
            {
                foreach (var subcategory in allproductsubcategory)
                {
                    productsubcategory.Add(new ProductSubCategoryModel()
                    {
                       Id = subcategory.Id,
                       Name = subcategory.Name,
                       Categoryid = subcategory.Category_Id
                    });
                }
            }
            return productsubcategory;
        }
    }
}
