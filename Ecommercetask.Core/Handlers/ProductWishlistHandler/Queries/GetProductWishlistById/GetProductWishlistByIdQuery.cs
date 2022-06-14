using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.ProductWishlistHandler.Queries.GetProductWishlistById
{

    public class GetProductWishlistByIdQuery : IRequest<ProductWishlistModel>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductWishlistByIdQuery, ProductWishlistModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetProductByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<ProductWishlistModel> Handle(GetProductWishlistByIdQuery request, CancellationToken cancellationToken)
        {

            var productwishlistbyid = await _db.Product_wishlist.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var productwishlist = new ProductWishlistModel()
            {
                Id = productwishlistbyid.Id,
                Product_Id = productwishlistbyid.Product_Id,
                User_Id = productwishlistbyid.User_Id,
            };
            return productwishlist;
        }
    }
}
