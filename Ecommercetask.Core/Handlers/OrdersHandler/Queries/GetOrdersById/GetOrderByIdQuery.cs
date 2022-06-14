

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Queries.GetOrdersById
{
    public class GetOrderByIdQuery : IRequest<OrdersModel> 
    {
        public int Id { get; set; }
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrdersModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetOrderByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<OrdersModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orderbyid = await _db.Order.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var order = new OrdersModel()
            {
                Id = orderbyid.Id,
                Total_Amount = orderbyid.Total_Amount,
                Total_Discount = orderbyid.Total_Discount,
                User_Id = orderbyid.User_Id,
            };
            return order;
        }
    }
}
