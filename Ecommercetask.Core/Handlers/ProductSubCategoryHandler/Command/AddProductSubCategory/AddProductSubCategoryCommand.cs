

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Command.AddProductSubCategory
{
    public class AddProductSubCategoryCommand : IRequest<int>
    {
        public AddProductSubCategoryCommand(ProductSubCategoryModel @in)
        {
            In = @in;
        }
        public ProductSubCategoryModel In { get; }
    }

    public class AddProductCategoryCommandHandler : IRequestHandler<AddProductSubCategoryCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddProductCategoryCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var productsubcategory = new Product_subcategory()
            {
                Name = request.In.Name,
                Category_Id = request.In.Categoryid,
            };

            await _db.Product_subcategory.AddAsync(productsubcategory);
            await _db.SaveChangesAsync();
            return productsubcategory.Id;
        }
    }
}