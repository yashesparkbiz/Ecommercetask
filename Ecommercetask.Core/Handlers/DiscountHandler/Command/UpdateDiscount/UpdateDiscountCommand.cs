using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Command.UpdateDiscount
{
    public class UpdateDiscountCommand : IRequest<bool>
    {
        public DiscountModel discountModel { get; set; }
    }

    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateDiscountCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = new Discount()
            {
                Id = request.discountModel.Id,
                Product_Id = request.discountModel.Product_Id,
                Type = request.discountModel.Type,
                Value = request.discountModel.Value,
                Is_Active = request.discountModel.Is_Active,
            };
            _db.Discount.Update(discount);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
