using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;


namespace Ecommercetask.Core.Handlers.OrderDetailsHandler.Command.UpdateOrderDetails
{
    public class UpdateOrderDetailsCommand : IRequest<bool>
    {
        public OrderDetailsModel orderDetailsModel { get; set; }
    }

    public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateOrdersCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderdetail = new Order_Details()
            {
                Id = request.orderDetailsModel.Id,
                Product_Id = request.orderDetailsModel.Product_Id,
                Quantity = request.orderDetailsModel.Quantity,
                Order_Id = request.orderDetailsModel.Order_Id,
                Status = request.orderDetailsModel.Status,
                Discount_Id = request.orderDetailsModel.Discount_Id
            };
            _db.Order_Details.Update(orderdetail);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
