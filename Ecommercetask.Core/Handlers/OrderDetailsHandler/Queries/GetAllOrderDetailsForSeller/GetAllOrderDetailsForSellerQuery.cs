using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsForSeller.GetAllOrderDetailsForSellerHandler;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsForSeller
{
    public class GetAllOrderDetailsForSellerQuery : IRequest<IEnumerable<OrderSellerModel>>
    {
        public int user_Id { get; set; }
    }

    public class GetAllOrderDetailsForSellerHandler : IRequestHandler<GetAllOrderDetailsForSellerQuery, IEnumerable<OrderSellerModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllOrderDetailsForSellerHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OrderSellerModel>> Handle(GetAllOrderDetailsForSellerQuery request, CancellationToken cancellationToken)
        {
            var sellerorder = new List<OrderSellerModel>();
            //var allproductsubcategory =  await _db.Product_subcategory.ToListAsync();
            var allsellerorder = await (from od in _db.Order_Details
                                        join pd in _db.Product
                                        on od.Product_Id equals pd.Id
                                        join dc in _db.Discount
                                        on od.Discount_Id equals dc.Id
                                        where pd.User_Id == request.user_Id
                                        select new
                                        {
                                            od.Id,
                                            pd.Product_Name,
                                            od.Quantity,
                                            od.Order_Id,
                                            od.Status,
                                            Price = (od.Quantity * pd.Price) * ((decimal.Parse(dc.Value)) / 100),
                                            pd.Product_Subcategory_Id
                                        }).ToListAsync();

            if (allsellerorder?.Any() == true)
            {
                foreach (var order in allsellerorder)
                {
                    sellerorder.Add(new OrderSellerModel()
                    {
                        Id = order.Id,
                        Product_Name = order.Product_Name,
                        Quantity = order.Quantity,
                        Order_Id = order.Order_Id,
                        Status = order.Status,
                        Price = order.Price,
                        Product_Subcategory_Id = order.Product_Subcategory_Id
                    });
                }
            }
            return sellerorder;
        }
    }

    public class OrderSellerModel
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public int Order_Id { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int Product_Subcategory_Id { get; set; }
    }
}
