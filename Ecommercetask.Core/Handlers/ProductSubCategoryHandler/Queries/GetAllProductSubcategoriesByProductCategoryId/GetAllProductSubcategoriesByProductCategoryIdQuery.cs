

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubcategoriesByProductCategoryId
{

    public class GetAllProductSubcategoriesByProductCategoryIdQuery : IRequest<IEnumerable<ProductSubCategoryModel>>
    {
        public int Category_Id { get; set; }
    }

    public class GetAllProductSubcategoriesByProductCategoryIdHandler : IRequestHandler<GetAllProductSubcategoriesByProductCategoryIdQuery, IEnumerable<ProductSubCategoryModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllProductSubcategoriesByProductCategoryIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductSubCategoryModel>> Handle(GetAllProductSubcategoriesByProductCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var productsubcategory = new List<ProductSubCategoryModel>();
            var allproductsubcategory = await _db.Product_subcategory.Where(d => d.Category_Id == request.Category_Id).ToListAsync();
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
