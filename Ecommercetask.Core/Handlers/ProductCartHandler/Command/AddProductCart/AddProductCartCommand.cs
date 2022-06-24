using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var availability = await SearchInCart(productcart.Product_Id, productcart.User_Id);
            if (availability.Count() == 0)
            {
                await _db.Product_cart.AddAsync(productcart);
                await _db.SaveChangesAsync();
                return productcart.Id;
            }
            else
            {
                return 0;
            }
        }

        private async Task<List<Product_cart>> SearchInCart(int Product_Id, int User_Id)
        {
            var product = new List<Product_cart>() ;
           product =await _db.Product_cart.Where(d=>d.Product_Id== Product_Id && d.User_Id == User_Id).ToListAsync();
            return product;
        }
    }
}