using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.UsersHandler.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UsersModel>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UsersModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetUserByIdHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<UsersModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = new UsersModel();
            var allusers = await _db.Users.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
            if (allusers != null)
            {
                users = new UsersModel()
                {
                    Id = allusers.Id,
                    UserName = allusers.UserName,
                    Age = allusers.Age,
                    Gender = allusers.Gender,
                    Email = allusers.Email,
                    PhoneNumber = allusers.PhoneNumber,
                    Password = allusers.PasswordHash
                };
            }
            return users;
        }
    }
}
