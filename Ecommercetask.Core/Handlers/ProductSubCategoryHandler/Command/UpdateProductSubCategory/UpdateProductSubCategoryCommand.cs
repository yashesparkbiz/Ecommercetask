using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.UpdateProductSubCategory
{
    public class UpdateProductSubCategoryCommand : IRequest<bool>
    {
        public ProductSubCategoryModel productSubCategoryModel { get; set; }
    }

    public class UpdateProductSubCategoryCommandHandler : IRequestHandler<UpdateProductSubCategoryCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateProductSubCategoryCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProductSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var productsubcategory = new Product_subcategory()
            {
                Id = request.productSubCategoryModel.Id,
                Name = request.productSubCategoryModel.Name,
                Category_Id = request.productSubCategoryModel.Categoryid,
            };
            _db.Product_subcategory.Update(productsubcategory);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
