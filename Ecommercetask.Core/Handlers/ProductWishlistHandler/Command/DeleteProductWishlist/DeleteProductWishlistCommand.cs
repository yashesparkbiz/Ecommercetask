using Ecommercetask.Data.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.ProductWishlistHandler.Command.DeleteProductWishlist
{
  

    public class DeleteProductWishlistCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductWishlistHandler : IRequestHandler<DeleteProductWishlistCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteProductWishlistHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteProductWishlistCommand request, CancellationToken cancellationToken)
        {
            var productwishlist = await _db.Product_wishlist.FindAsync(request.Id);
            if (productwishlist != null)
            {
                _db.Product_wishlist.Remove(productwishlist);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
