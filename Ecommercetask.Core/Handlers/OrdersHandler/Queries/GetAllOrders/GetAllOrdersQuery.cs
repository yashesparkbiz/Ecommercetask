using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrdersModel>> {}

    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrdersModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllOrdersHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OrdersModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = new List<OrdersModel>();
            var allorders = await _db.Order.ToListAsync();
            if (allorders?.Any() == true)
            {
                foreach (var order in allorders)
                {
                    orders.Add(new OrdersModel()
                    {
                        Id = order.Id,
                        Total_Amount = order.Total_Amount,
                        Total_Discount = order.Total_Discount,
                        User_Id = order.User_Id
                    });
                }
            }
            return orders;
        }
    }
}
