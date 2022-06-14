using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommercetask.Core.Handlers.UsersHandler.Queries.LogOutUser
{
    public class LogOutUserQuery : IRequest<bool> {}

    public class LogOutUserHandler : IRequestHandler<LogOutUserQuery, bool>
    {
        private readonly SignInManager<UserModel> _signInManager;

        public LogOutUserHandler(SignInManager<UserModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(LogOutUserQuery request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return true;
        }

    }
}
