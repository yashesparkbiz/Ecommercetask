using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.AddUsers
{
    public class AddUsersCommand : IRequest<IdentityResult>
    {
        public AddUsersCommand(UserModel @in, UserManager<UserModel> userManager)
        {
            In = @in;
            _userManager = userManager;
        }
        public UserModel In { get; }
        public readonly UserManager<UserModel> _userManager;
    }

    public class AddUsersCommandHandler : IRequestHandler<AddUsersCommand, IdentityResult>
    {
        private readonly EcommerceSiteContext _db = null;

        public AddUsersCommandHandler(EcommerceSiteContext db)
        {
            _db = db;
        }
        public async Task<IdentityResult> Handle(AddUsersCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel()
            {
                Age = request.In.Age,
                Gender = request.In.Gender,
            };

            var result = await request._userManager.CreateAsync(user); 
            await _db.SaveChangesAsync();
            return result  ;
        }
    }
}
