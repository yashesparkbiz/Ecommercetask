using Ecommercetask.Core.Helper.ProductCategoryHelper.Queries.GetAllProductCategory;
using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductCategoryHandler.Command.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<bool>
    {
        public ProductCategoryModel productCategoryModel { get; set; }
    }
    
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateProductCategoryCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if(request.productCategoryModel.Id > 0)
            {
                var productcategory = new Product_category()
                {
                    Id = request.productCategoryModel.Id,
                    Name = request.productCategoryModel.Name,
                    Is_Active = request.productCategoryModel.Is_Active,
                };
                _db.Product_category.Update(productcategory);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}