

using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQuery : IRequest<IEnumerable<OrderDetailsModel>> { }

    public class GetAllOrderDetailsHandler : IRequestHandler<GetAllOrderDetailsQuery, IEnumerable<OrderDetailsModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllOrderDetailsHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OrderDetailsModel>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderdetails = new List<OrderDetailsModel>();
            var allorderdetails = await _db.Order_Details.ToListAsync();
            if (allorderdetails?.Any() == true)
            {
                foreach (var orderdetail in allorderdetails)
                {
                    orderdetails.Add(new OrderDetailsModel()
                    {
                        Id = orderdetail.Id,
                        Product_Id = orderdetail.Product_Id,
                        Quantity = orderdetail.Quantity,
                        Order_Id = orderdetail.Order_Id,
                        Status = orderdetail.Status,
                        Discount_Id = orderdetail.Discount_Id,
                    });
                }
            }
            return orderdetails;
        }
    }
}
