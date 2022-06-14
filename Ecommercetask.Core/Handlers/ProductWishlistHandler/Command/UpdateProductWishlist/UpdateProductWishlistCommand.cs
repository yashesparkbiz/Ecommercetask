using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.UpdateProductWishlist
{

    public class UpdateProductWishlistCommand : IRequest<bool>
    {
        public ProductWishlistModel productWishlistModel { get; set; }
    }

    public class UpdateProductWishlistCommandHandler : IRequestHandler<UpdateProductWishlistCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateProductWishlistCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProductWishlistCommand request, CancellationToken cancellationToken)
        {
            var productwishlist = new Product_wishlist()
            {
                Product_Id = request.productWishlistModel.Product_Id,
                User_Id = request.productWishlistModel.User_Id,
            };
            _db.Product_wishlist.Update(productwishlist);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
