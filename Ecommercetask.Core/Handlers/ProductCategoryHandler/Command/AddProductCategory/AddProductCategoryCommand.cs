

using Ecommercetask.Core.Helper.ProductCategoryHelper.Queries.GetAllProductCategory;
using Ecommercetask.Data.Data;
using MediatR;


namespace Ecommercetask.Core.Handlers.ProductCategoryHandler.Command
{
    public class AddProductCategoryCommand : IRequest<int>
    {
        public AddProductCategoryCommand(ProductCategoryModel @in)
        {
            In = @in;
        }
        public ProductCategoryModel In { get;  }
    }

    public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddProductCategoryCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productcategory = new Product_category()
            {
                Name = request.In.Name,
                Is_Active = request.In.Is_Active,
            };
            
            await _db.Product_category.AddAsync(productcategory);
            await _db.SaveChangesAsync();
            return productcategory.Id;
        }
    }
}
