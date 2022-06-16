using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductHandler.Command.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public AddProductCommand(ProductModel @in)
        {
            In = @in;
        }
        public ProductModel In { get; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddProductCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Product_Name = request.In.Product_Name,
                Description = request.In.Description,
                Brand = request.In.Brand,
                Price = request.In.Price,
                Product_Subcategory_Id = request.In.Product_Subcategory_Id,
                Quantity = request.In.Quantity,
                Image = request.In.Image,
                Is_Active = request.In.Is_Active,
                User_Id = request.In.User_Id
            };

            await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }
    }
}
