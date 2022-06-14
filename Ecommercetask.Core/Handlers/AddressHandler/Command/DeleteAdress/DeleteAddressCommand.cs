using Ecommercetask.Data.Data;
using MediatR;

namespace Ecommercetask.Core.Handlers.AddressHandler.Command.DeleteAdress
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;

        public DeleteAddressHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _db.Address.FindAsync(request.Id);
            if (address != null)
            {
                _db.Address.Remove(address);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
