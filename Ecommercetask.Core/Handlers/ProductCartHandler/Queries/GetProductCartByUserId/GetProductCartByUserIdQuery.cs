

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Queries.GetProductCartByUserId
{

    public class GetProductCartByUserIdQuery : IRequest<ProductCartModel>
    {
        public int User_Id { get; set; }
    }

    public class GetProductCartByUserIdHandler : IRequestHandler<GetProductCartByUserIdQuery, ProductCartModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductCartByUserIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<ProductCartModel> Handle(GetProductCartByUserIdQuery request, CancellationToken cancellationToken)
        {

            var productcartbyuserid = await _db.Product_cart.Where(d => d.User_Id == request.User_Id).FirstOrDefaultAsync();
            var product = new ProductCartModel()
            {
                Id = productcartbyuserid.Id,
                Product_Id = productcartbyuserid.Product_Id,
                Quantity = productcartbyuserid.Quantity,
                Price = productcartbyuserid.Price,
                User_Id =productcartbyuserid.User_Id,
                Is_Active = productcartbyuserid.Is_Active
            };
            return product;
        }
    }
}
