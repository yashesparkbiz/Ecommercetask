using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Command.UpdateProductCart
{

    public class UpdateProductCartCommand : IRequest<bool>
    {
        public ProductCartModel productCartModel { get; set; }
    }

    public class UpdateProductCartCommandHandler : IRequestHandler<UpdateProductCartCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateProductCartCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateProductCartCommand request, CancellationToken cancellationToken)
        {
            var productcart = new Product_cart()
            {
                Id = request.productCartModel.Id,
                Product_Id = request.productCartModel.Product_Id,
                Quantity = request.productCartModel.Quantity,
                Price = request.productCartModel.Price,
                User_Id = request.productCartModel.User_Id,
                Is_Active = request.productCartModel.Is_Active
            };
            _db.Product_cart.Update(productcart);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
