using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetProductSubCategory
{
    public class GetProductSubCategoryQuery : IRequest<IEnumerable<SubCategoryModel>> { }

    public class GetProductSubCategoryHandler : IRequestHandler<GetProductSubCategoryQuery, IEnumerable<SubCategoryModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductSubCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SubCategoryModel>> Handle(GetProductSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var productsubcategory = new List<SubCategoryModel>();
            //var allproductsubcategory =  await _db.Product_subcategory.ToListAsync();
            var allproductsubcategory = await (from sb in _db.Product_subcategory
                                  join ct in _db.Product_category
                                  on sb.Category_Id equals ct.Id
                                  select new
                                  {
                                      sb.Id,
                                      sb.Name,
                                      categoryname=ct.Name,
                                  }).ToListAsync();

            if (allproductsubcategory?.Any() == true)
            {
                foreach (var subcategory in allproductsubcategory)
                {
                    productsubcategory.Add(new SubCategoryModel()
                    {
                        Id = subcategory.Id,
                        Name = subcategory.Name,
                        CategoryName = subcategory.categoryname
                    });
                }
            }
            return productsubcategory;
        }
    }
}


public class SubCategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
}