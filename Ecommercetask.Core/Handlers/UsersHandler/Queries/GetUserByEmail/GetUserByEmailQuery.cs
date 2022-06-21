using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.UsersHandler.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<UsersModel>
    {
        public string Email { get; set; }
    }

    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UsersModel>
    {
        private readonly EcommerceSiteContext _db = null;

        public GetUserByEmailHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<UsersModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var users = new UsersModel();
            var allusers = await _db.Users.Where(d => d.Email == request.Email).FirstOrDefaultAsync();
            if (allusers != null)
            {
                users = new UsersModel()
                {
                    Id = allusers.Id,
                    UserName = allusers.UserName,
                    Age = allusers.Age,
                    Gender = allusers.Gender,
                    Email = allusers.Email,
                    PhoneNumber = allusers.PhoneNumber
                };
            }
            return users;
        }
    }
}
