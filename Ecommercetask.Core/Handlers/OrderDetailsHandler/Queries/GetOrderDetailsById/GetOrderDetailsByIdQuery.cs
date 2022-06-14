using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById
{
    

    public class GetOrderDetailsByIdQuery : IRequest<OrderDetailsModel>
    {
        public int Id { get; set; }
    }

    public class GetOrderDetailsByIdHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDetailsModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetOrderDetailsByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<OrderDetailsModel> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var orderdetailsbyid = await _db.Order_Details.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var orderdetails = new OrderDetailsModel()
            {
                Id = orderdetailsbyid.Id,
                Product_Id = orderdetailsbyid.Product_Id,
                Quantity = orderdetailsbyid.Quantity,
                Order_Id = orderdetailsbyid.Order_Id,
                Status = orderdetailsbyid.Status,
                Discount_Id = orderdetailsbyid.Discount_Id,
            };
            return orderdetails;
        }
    }
}
