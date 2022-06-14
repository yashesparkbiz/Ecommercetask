using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductCategoryHandler.Command.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteProductCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productcategory = await _db.Product_category.FindAsync(request.Id);
            if (productcategory != null)
            {
                _db.Product_category.Remove(productcategory);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}