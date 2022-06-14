using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductHandler.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteProductHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Product.FindAsync(request.Id);
            if (product != null)
            {
                _db.Product.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}