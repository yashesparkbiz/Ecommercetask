

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductHandler.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public ProductModel productModel { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateProductCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = request.productModel.Id,
                Product_Name = request.productModel.Product_Name,
                Description = request.productModel.Description,
                Brand = request.productModel.Brand,
                Price = request.productModel.Price,
                Product_Subcategory_Id = request.productModel.Product_Subcategory_Id,
                Quantity = request.productModel.Quantity,
                Image = request.productModel.Image,
                Is_Active = request.productModel.Is_Active,
            };
            _db.Product.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
