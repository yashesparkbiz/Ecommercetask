using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByOrderId
{
    public class GetOrderDetailsByOrderIdQuery : IRequest<IEnumerable<OrderDetails>>
    {
        public int Order_Id { get; set; }
    }

    public class GetOrderDetailsByOrderIdHandler : IRequestHandler<GetOrderDetailsByOrderIdQuery, IEnumerable<OrderDetails>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetOrderDetailsByOrderIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OrderDetails>> Handle(GetOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orderdetails = new List<OrderDetails>();
            //var orderdetailsbyid = await _db.Order_Details.Where(d => d.Order_Id == request.Order_Id).ToListAsync();

            var orderdetailsbyid = await (from od in _db.Order_Details
                                          join pr in _db.Product
                                          on od.Product_Id equals pr.Id
                                          select new
                                          {
                                              od.Id,
                                              od.Product_Id,
                                              pr.Product_Name,
                                              pr.Image,
                                              od.Quantity,
                                              od.Order_Id,
                                              od.Status,
                                              od.Discount_Id
                                          }).ToListAsync();
            if (orderdetailsbyid?.Any() == true)
            {
                foreach (var orderdetail in orderdetailsbyid)
                {
                    orderdetails.Add(new OrderDetails()
                    {
                        Id = orderdetail.Id,
                        Product_Id = orderdetail.Product_Id,
                        Product_Name = orderdetail.Product_Name,
                        Image = orderdetail.Image,
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

    public class OrderDetails
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Order_Id { get; set; }
        public string Status { get; set; }
        public int Discount_Id { get; set; }
    }
}


