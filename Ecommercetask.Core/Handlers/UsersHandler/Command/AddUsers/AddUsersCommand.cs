using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.AddUsers
{
    public class AddUsersCommand : IRequest<IdentityResult>
    {
        public AddUsersCommand(UsersModel @in)
        {
            In = @in;
        }
        public UsersModel In { get; }
        
    }

    public class AddUsersCommandHandler : IRequestHandler<AddUsersCommand, IdentityResult>
    {
        private readonly UserManager<UserModel> _userManager;

        public AddUsersCommandHandler(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(AddUsersCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel()
            {
                UserName = request.In.UserName,
                Age = request.In.Age,
                Gender = request.In.Gender,
                Email = request.In.Email,
                PhoneNumber = request.In.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.In.Password); 
            //await _db.SaveChangesAsync();
            return result  ;
        }
    }
}
