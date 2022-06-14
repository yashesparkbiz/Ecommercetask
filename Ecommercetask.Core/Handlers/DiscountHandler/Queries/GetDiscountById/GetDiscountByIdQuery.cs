using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Queries.GetDiscountById
{
    public class GetDiscountByIdQuery : IRequest<DiscountModel>
    {
        public int Id { get; set; }
    }

    public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, DiscountModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetDiscountByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<DiscountModel> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {

            var discountbyid = await _db.Discount.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            var discount = new DiscountModel()
            {
                Id = discountbyid.Id,
                Product_Id = discountbyid.Product_Id,
                Type = discountbyid.Type,
                Value = discountbyid.Value,
                Is_Active = discountbyid.Is_Active,
            };
            return discount;
        }
    }
}
