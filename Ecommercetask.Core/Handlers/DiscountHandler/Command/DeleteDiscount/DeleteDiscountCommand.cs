using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.DiscountHandler.Command.DeleteDiscount
{
    public class DeleteDiscountCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteDiscountHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _db.Discount.FindAsync(request.Id);
            if (discount != null)
            {
                _db.Discount.Remove(discount);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
