using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.AddressHandler.Command.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<bool>
    {
        public AddressModel addressModel { get; set; }
    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public UpdateAddressCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {
                Id = request.addressModel.Id,
                House = request.addressModel.House,
                Street = request.addressModel.Street,
                City = request.addressModel.City,
                Country = request.addressModel.Country,
                Pincode = request.addressModel.Pincode,
                Address_Type = request.addressModel.Address_Type,
                User_Id = request.addressModel.User_Id,
                Order_Details_Id = request.addressModel.Order_Details_Id,
            };
            _db.Address.Update(address);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
