using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Core.Handlers.UsersHandler.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UsersModel>> { }

    public class GetAllProductSubCategoryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UsersModel>>
    {

        private readonly EcommerceSiteContext _db = null;

        public GetAllProductSubCategoryHandler(EcommerceSiteContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UsersModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = new List<UsersModel>();
            var allusers = await _db.Users.ToListAsync();

            if (allusers?.Any() == true)
            {
                foreach (var user in allusers)
                {
                    users.Add(new UsersModel()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Age = user.Age,
                        Gender = user.Gender,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    });
                }
            }
            return users;
        }
    }
}