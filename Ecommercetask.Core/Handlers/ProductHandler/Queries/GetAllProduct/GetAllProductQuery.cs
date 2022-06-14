

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductHandler.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductModel>> { }

    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllProductHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var product = new List<ProductModel>();
            var allproduct = await _db.Product.ToListAsync();
            if (allproduct?.Any() == true)
            {
                foreach (var p in allproduct)
                {
                    product.Add(new ProductModel()
                    {
                        Id = p.Id,
                        Product_Name = p.Product_Name,
                        Description = p.Description,
                        Brand = p.Brand,
                        Price = p.Price,
                        Product_Subcategory_Id = p.Product_Subcategory_Id,
                        Quantity = p.Quantity,
                        Image = p.Image,
                        Is_Active = p.Is_Active,
                    });
                }
            }
            return product;
        }
    }
}
