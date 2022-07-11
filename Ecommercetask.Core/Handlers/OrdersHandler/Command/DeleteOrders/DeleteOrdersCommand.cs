

using Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByOrderId;
using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.OrdersHandler.Command.DeleteOrders
{
    public class DeleteOrdersCommand : IRequest<bool> {
        public int Id { get; set; }
    }

    public class DeleteOrdersHandler : IRequestHandler<DeleteOrdersCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteOrdersHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteOrdersCommand request, CancellationToken cancellationToken)
        {
            var order = await _db.Order.FindAsync(request.Id);
            if (order != null)
            {
                var orderdetails = new List<OrderDetailsModel>();
                var orderdetailsbyid = await _db.Order_Details.Where(d => d.Order_Id == request.Id).ToListAsync();
                if (orderdetailsbyid?.Any() == true)
                {
                    foreach (var orderdetail in orderdetailsbyid)
                    {
                        _db.Order_Details.Remove(orderdetail);
                        await _db.SaveChangesAsync();
                    }
                }


                var addressdetails = new List<AddressModel>();
                var addressdetailsbyorderid = await _db.Address.Where(d => d.Order_Id == request.Id).ToListAsync();
                if(addressdetailsbyorderid?.Any() == true)
                {
                    foreach(var addressdetail in addressdetailsbyorderid)
                    {
                        _db.Address.Remove(addressdetail);
                        await _db.SaveChangesAsync();
                    }
                }

                _db.Order.Remove(order);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
