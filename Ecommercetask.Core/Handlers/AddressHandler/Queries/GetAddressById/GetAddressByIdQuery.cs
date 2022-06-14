using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.AddressHandler.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<AddressModel>
    {
        public int Id { get; set; }
    }

    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetAddressByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<AddressModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var addressbyid = await _db.Address.Where(d => d.Id == request.Id   ).FirstOrDefaultAsync();
            var address = new AddressModel()
            {
                Id = addressbyid.Id,
                House = addressbyid.House,
                Street = addressbyid.Street,
                City = addressbyid.City,
                Country = addressbyid.Country,
                Pincode = addressbyid.Pincode,
                Address_Type = addressbyid.Address_Type,
                User_Id = addressbyid.User_Id,
                Order_Details_Id = addressbyid.Order_Details_Id,
            };
            return address;
        }
    }
}
