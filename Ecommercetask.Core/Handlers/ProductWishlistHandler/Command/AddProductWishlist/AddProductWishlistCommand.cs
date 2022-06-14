using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.AddProductWishlist
{

    public class AddProductWishlistCommand : IRequest<int>
    {
        public AddProductWishlistCommand(ProductWishlistModel @in)
        {
            In = @in;
        }
        public ProductWishlistModel In { get; }
    }

    public class AddProductWishlistCommandHandler : IRequestHandler<AddProductWishlistCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddProductWishlistCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductWishlistCommand request, CancellationToken cancellationToken)
        {
            var product = new Product_wishlist()
            {
                Product_Id = request.In.Product_Id,
                User_Id = request.In.User_Id,
            };

            await _db.Product_wishlist.AddAsync(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }
    }
}
