using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductCategoryHandler.Queries.GetCategoryIdBySubcategoryId
{
    public class GetCategoryIdBySubcategoryIdQuery : IRequest<int>
    {
        public int Subcategory_Id { get; set; }
    }

    public class GetProductCategoryByIdHandler : IRequestHandler<GetCategoryIdBySubcategoryIdQuery, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductCategoryByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(GetCategoryIdBySubcategoryIdQuery request, CancellationToken cancellationToken)
        {
            var productsubcategorybyid = await _db.Product_subcategory.Where(d => d.Id == request.Subcategory_Id).FirstOrDefaultAsync();
            int Category_Id = productsubcategorybyid.Category_Id > 0 ? productsubcategorybyid.Category_Id : 0;
            return Category_Id;
        }
    }
}