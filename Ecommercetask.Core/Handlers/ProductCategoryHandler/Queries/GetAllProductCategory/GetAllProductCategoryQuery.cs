using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Helper.ProductCategoryHelper.Queries.GetAllProductCategory
{
    public class GetAllProductCategoryQuery : IRequest<IEnumerable<ProductCategoryModel>> {}

    public class GetAllProductCategoryHandler : IRequestHandler<GetAllProductCategoryQuery, IEnumerable<ProductCategoryModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllProductCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductCategoryModel>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productcategory = new List<ProductCategoryModel>();
            var allproductcategory = await _db.Product_category.ToListAsync();
            if (allproductcategory?.Any() == true)
            {
                foreach (var category in allproductcategory)
                {
                    productcategory.Add(new ProductCategoryModel()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Is_Active = category.Is_Active,
                    });
                }
            }
            return productcategory;
        }
    }

    public class ProductCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Is_Active { get; set; } = true;
    }
}