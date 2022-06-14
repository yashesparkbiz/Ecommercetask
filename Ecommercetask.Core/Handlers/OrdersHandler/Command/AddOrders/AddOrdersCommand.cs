using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Command.AddOrders
{
    public class AddOrdersCommand : IRequest<int>
    {
        public AddOrdersCommand(OrdersModel @in)
        {
            In = @in;
        }
        public OrdersModel In { get; }
    }

    public class AddOrdersCommandHandler : IRequestHandler<AddOrdersCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddOrdersCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddOrdersCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Total_Amount = request.In.Total_Amount,
                Total_Discount = request.In.Total_Discount,
                User_Id = request.In.User_Id,
            };

            await _db.Order.AddAsync(order);
            await _db.SaveChangesAsync();
            return order.Id;
        }
    }
}
