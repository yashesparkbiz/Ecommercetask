using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Queries.GetAllDiscount
{
    public class GetAllDiscountQuery : IRequest<IEnumerable<DiscountModel>> {}

    public class GetAllDiscountHandler : IRequestHandler<GetAllDiscountQuery, IEnumerable<DiscountModel>>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAllDiscountHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DiscountModel>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            var discount = new List<DiscountModel>();
            var alldiscount = await _db.Discount.ToListAsync();
            if (alldiscount?.Any() == true)
            {
                foreach (var d in alldiscount)
                {
                    discount.Add(new DiscountModel()
                    {
                        Id = d.Id,
                        Product_Id = d.Product_Id,
                        Type = d.Type,
                        Value = d.Value,
                        Is_Active = d.Is_Active,
                    });
                }
            }
            return discount;
        }
    }
}
