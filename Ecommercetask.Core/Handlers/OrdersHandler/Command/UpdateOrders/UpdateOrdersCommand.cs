using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Command.UpdateOrders
{
    public class UpdateOrdersCommand : IRequest<bool>
    {
        public OrdersModel ordersModel { get; set; }
    }

    public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrdersCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateOrdersCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateOrdersCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Id = request.ordersModel.Id,
                Total_Amount = request.ordersModel.Total_Amount,
                Total_Discount = request.ordersModel.Total_Discount,
                User_Id = request.ordersModel.User_Id,
            };
            _db.Order.Update(order);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
