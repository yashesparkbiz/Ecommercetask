using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.ProductCartHandler.Command.AddProductCart
{
    public class AddProductCartCommand : IRequest<int>
    {
        public AddProductCartCommand(ProductCartModel @in)
        {
            In = @in;
        }
        public ProductCartModel In { get; }
    }

    public class AddProductCartCommandHandler : IRequestHandler<AddProductCartCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddProductCartCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductCartCommand request, CancellationToken cancellationToken)
        {
            var productcart = new Product_cart()
            {
                Product_Id = request.In.Product_Id,
                Quantity = request.In.Quantity,
                Price = Convert.ToDecimal(request.In.Price),
                User_Id = request.In.User_Id,
                Is_Active = request.In.Is_Active
            };
            await _db.Product_cart.AddAsync(productcart);
            await _db.SaveChangesAsync();
            return productcart.Id;
        }
    }
}