using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.DeleteOrderDetails
{
    public class DeleteOrderDetailsCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteOrderDetailsHandler : IRequestHandler<DeleteOrderDetailsCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteOrderDetailsHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderdetail = await _db.Order_Details.FindAsync(request.Id);
            if (orderdetail != null)
            {
                _db.Order_Details.Remove(orderdetail);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
