using Ecommercetask.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.DeleteUsers
{
    public class DeleteUserByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand, bool>
    {
        private readonly EcommerceSiteContext _db = null;
        public DeleteUserByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.Where(d=>d.Id==request.Id).FirstOrDefaultAsync();
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}