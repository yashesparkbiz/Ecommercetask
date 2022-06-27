using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Queries.GetDiscountByProductId
{
    public class GetDiscountByProductIdQuery : IRequest<List<DiscountModel>>
    {
        public int Product_Id { get; set; }
    }

    public class GetDiscountByProductIdHandler : IRequestHandler<GetDiscountByProductIdQuery, List<DiscountModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetDiscountByProductIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<List<DiscountModel>> Handle(GetDiscountByProductIdQuery request, CancellationToken cancellationToken)
        {
            var productdiscount = new List<DiscountModel>();
            var discountbyproductid = await _db.Discount.Where(d => d.Product_Id == request.Product_Id).ToListAsync();
            if(discountbyproductid.Any()==true)
            {
                foreach(var discount in discountbyproductid)
                {
                    productdiscount.Add(new DiscountModel()
                    {
                        Id = discount.Id,
                        Product_Id = discount.Product_Id,
                        Type = discount.Type,
                        Value = discount.Value,
                        Is_Active = discount.Is_Active,
                    });
                }
            }
            return productdiscount;
        }
    }
}