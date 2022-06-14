using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser
{
    public class SignInUserCommand : IRequest<SignInResult>
    {
        public SignInUserCommand(SignInModel @in)
        {
            In = @in;
        }
        public SignInModel In { get; }
    }

    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, SignInResult>
    {
        private readonly SignInManager<UserModel> _signInManager;

        public SignInUserCommandHandler(SignInManager<UserModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.In.Email, request.In.Password, request.In.RememberMe, false);
            return result;
        }
    }

    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}