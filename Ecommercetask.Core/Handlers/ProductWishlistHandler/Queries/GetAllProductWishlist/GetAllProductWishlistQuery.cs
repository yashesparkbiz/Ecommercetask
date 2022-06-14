

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductWishlistHandler.Queries.GetAllProductWishlist
{

    public class GetAllProductWishlistQuery : IRequest<IEnumerable<ProductWishlistModel>> { }

    public class GetAllProductWishlistHandler : IRequestHandler<GetAllProductWishlistQuery, IEnumerable<ProductWishlistModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllProductWishlistHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductWishlistModel>> Handle(GetAllProductWishlistQuery request, CancellationToken cancellationToken)
        {
            var productwishlists = new List<ProductWishlistModel>();
            var allproductwishlists = await _db.Product_wishlist.ToListAsync();
            if (allproductwishlists?.Any() == true)
            {
                foreach (var productwishlist in allproductwishlists)
                {
                    productwishlists.Add(new ProductWishlistModel()
                    {
                        Id = productwishlist.Id,
                        Product_Id = productwishlist.Product_Id,
                        User_Id = productwishlist.User_Id,
                    });
                }
            }
            return productwishlists;
        }
    }
}
