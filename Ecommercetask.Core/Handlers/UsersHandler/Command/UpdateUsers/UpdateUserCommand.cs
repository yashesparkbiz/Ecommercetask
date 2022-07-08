using Ecommercetask.Data.Data;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.UpdateUsers
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UsersModel usersModel { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly UserManager<UserModel> _userManager;

        public UpdateUserCommandHandler(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.usersModel.Id.ToString());
            user.UserName = request.usersModel.UserName;
            user.Age = request.usersModel.Age;
            user.Gender = request.usersModel.Gender;
            user.Email = request.usersModel.Email;
            user.PhoneNumber = request.usersModel.PhoneNumber;
            user.PasswordHash = request.usersModel.Password;
            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
