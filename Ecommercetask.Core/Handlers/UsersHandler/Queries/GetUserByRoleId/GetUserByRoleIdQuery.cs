
using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommercetask.Core.Handlers.ProductSubCategoryHandler.Queries.GetUserByRoleId
{
    public class GetUserByRoleIdQuery : IRequest<IEnumerable<UsersModel>>
    {
        public string RoleName { get; set; }
    }

    public class GetUserByRoleIdHandler : IRequestHandler<GetUserByRoleIdQuery, IEnumerable<UsersModel>>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly EcommerceSiteContext _db = null;

        public GetUserByRoleIdHandler(EcommerceSiteContext db, UserManager<UserModel> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IEnumerable<UsersModel>> Handle(GetUserByRoleIdQuery request, CancellationToken cancellationToken)
        {
            var users = new List<UsersModel>();
            var allusers = await _userManager.GetUsersInRoleAsync(request.RoleName);
            if (allusers != null)
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
                        PhoneNumber = user.PhoneNumber,
                        Password = user.PasswordHash
                    });
                }
            }
            return users;
        }
    }
}
