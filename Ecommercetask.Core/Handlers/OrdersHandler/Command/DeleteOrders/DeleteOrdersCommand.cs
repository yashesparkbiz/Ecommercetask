

using Ecommercetask.Data.Data;
using MediatR;

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
                _db.Order.Remove(order);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
