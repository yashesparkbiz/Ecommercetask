using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.AddOrderDetails
{
    public class AddOrderDetailsCommand : IRequest<int>
    {
        public AddOrderDetailsCommand(OrderDetailsModel @in)
        {
            In = @in;
        }
        public OrderDetailsModel In { get; }
    }

    public class AddOrderDetailsCommandHandler : IRequestHandler<AddOrderDetailsCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddOrderDetailsCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderdetails = new Order_Details()
            {
                Product_Id = request.In.Product_Id,
                Quantity = request.In.Quantity,
                Order_Id = request.In.Order_Id,
                Status = request.In.Status,
                Discount_Id = request.In.Discount_Id,
            };

            await _db.Order_Details.AddAsync(orderdetails);
            await _db.SaveChangesAsync();
            return orderdetails.Id;
        }
    }
}
