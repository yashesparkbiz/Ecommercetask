using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductHandler.Queries.GetProductsByUserId
{
    public class GetProductsByUserIdQuery : IRequest<IEnumerable<ProductModel>>
    {
        public int User_Id { get; set; }
    }

    public class GetProductsByUserIdHandler : IRequestHandler<GetProductsByUserIdQuery, IEnumerable<ProductModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductsByUserIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var products = new List<ProductModel>();
            var allproducts = await _db.Product.Where(d => d.User_Id == request.User_Id).ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
                {
                    products.Add(new ProductModel()
                    {
                        Id = product.Id,
                        Product_Name = product.Product_Name,
                        Description = product.Description,
                        Brand = product.Brand,
                        Price = product.Price,
                        Product_Subcategory_Id = product.Product_Subcategory_Id,
                        Quantity = product.Quantity,
                        Image = product.Image,
                        Is_Active = product.Is_Active,
                        User_Id = product.User_Id,
                    });
                }
            }
            return products;
        }
    }
}