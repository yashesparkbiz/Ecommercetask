

using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Command.DeleteProductCart
{

    public class DeleteProductCartCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int product_Id { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCartCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteProductHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteProductCartCommand request, CancellationToken cancellationToken)
        { 
            var productcart = await _db.Product_cart.Where(x => x.Id == request.Id).Where(x => x.Product_Id == request.product_Id).ToListAsync();
            if (productcart != null && productcart.Any()==true)
            {
                foreach(var product in productcart)
                {
                    _db.Product_cart.Remove(product);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }
    }
}
