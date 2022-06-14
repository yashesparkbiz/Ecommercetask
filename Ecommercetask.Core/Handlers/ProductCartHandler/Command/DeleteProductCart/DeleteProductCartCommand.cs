

using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Command.DeleteProductCart
{

    public class DeleteProductCartCommand : IRequest<bool>
    {
        public int Id { get; set; }
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
            var productcart = await _db.Product_cart.FindAsync(request.Id);
            if (productcart != null)
            {
                _db.Product_cart.Remove(productcart);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
