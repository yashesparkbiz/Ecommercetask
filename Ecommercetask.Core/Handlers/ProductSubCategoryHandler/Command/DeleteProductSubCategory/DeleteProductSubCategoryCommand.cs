

using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.DeleteProductSubCategory
{
    public class DeleteProductSubCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductSubCategoryHandler : IRequestHandler<DeleteProductSubCategoryCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteProductSubCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteProductSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var productsubcategory = await _db.Product_subcategory.FindAsync(request.Id);
            if (productsubcategory != null)
            {
                _db.Product_subcategory.Remove(productsubcategory);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
