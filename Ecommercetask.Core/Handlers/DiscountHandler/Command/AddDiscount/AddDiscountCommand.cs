using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Command.AddDiscount
{
    public class AddDiscountCommand : IRequest<int>
    {
        public AddDiscountCommand(DiscountModel @in)
        {
            In = @in;
        }
        public DiscountModel In { get; }
    }

    public class AddDiscountCommandHandler : IRequestHandler<AddDiscountCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddDiscountCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = new Discount()
            {
                Product_Id = request.In.Product_Id  ,
                Type = request.In.Type,
                Value = request.In.Value,
                Is_Active = request.In.Is_Active,
            };

            await _db.Discount.AddAsync(discount);
            await _db.SaveChangesAsync();
            return discount.Id;
        }
    }
}
