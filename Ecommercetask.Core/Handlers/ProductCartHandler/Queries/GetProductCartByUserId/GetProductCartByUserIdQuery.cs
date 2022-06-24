using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Queries.GetProductCartByUserId
{

    public class GetProductCartByUserIdQuery : IRequest<List<ProductCart_Model>>
    {
        public int User_Id { get; set; }
    }

    public class GetProductCartByUserIdHandler : IRequestHandler<GetProductCartByUserIdQuery, List<ProductCart_Model>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductCartByUserIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<List<ProductCart_Model>> Handle(GetProductCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var product = new List<ProductCart_Model>() { };
            var productcartbyuserid = await _db.Product_cart.Where(d => d.User_Id == request.User_Id).ToListAsync();
            if (productcartbyuserid?.Any() == true)
            {
                foreach (var cart in productcartbyuserid)
                {
                    product.Add(new ProductCart_Model()
                    {
                        Id = cart.Id,
                        Product_Id = cart.Product_Id,
                        Quantity = cart.Quantity,
                        Price = cart.Price,
                        User_Id = cart.User_Id,
                        Is_Active = cart.Is_Active,
                        Image = await _db.Product.Where(d => d.Id == cart.Product_Id).Select(d => d.Image).FirstOrDefaultAsync(),
                        ProductName = await _db.Product.Where(d => d.Id == cart.Product_Id).Select(d => d.Product_Name).FirstOrDefaultAsync()
                    }) ;
                }
            }
            return product;
        }
    }

    public class ProductCart_Model
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int User_Id { get; set; }
        public bool Is_Active { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
    }
}