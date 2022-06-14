using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;

namespace Ecommercetask.Core.Handlers.AddressHandler.Command.AddAdress
{
    public class AddAddressCommand : IRequest<int>
    {
        public AddAddressCommand(AddressModel @in)
        {
            In = @in;
        }
        public AddressModel In { get; }
    }

    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, int>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddAddressCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {
                House = request.In.House,
                Street = request.In.Street,
                City = request.In.City,
                Country = request.In.Country,
                Pincode = request.In.Pincode,
                Address_Type = request.In.Address_Type,
                User_Id = request.In.User_Id,
                Order_Details_Id = request.In.Order_Details_Id,
            };

            await _db.Address.AddAsync(address);
            await _db.SaveChangesAsync();
            return address.Id;
        }
    }
}