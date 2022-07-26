using Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.ExternalLogin
{
    public class ExternalLoginCommand : IRequest<AuthResponseDto>
    {
        public ExternalLoginCommand(ExternalAuthDto @in)
        {
            In = @in;
        }
        public ExternalAuthDto In { get; set; }
    }

    public class ExternalLoginHandler : IRequestHandler<ExternalLoginCommand, AuthResponseDto>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly JwtHandler _jwtHandler;
        private readonly IConfiguration _configuration;
        public ExternalLoginHandler(JwtHandler jwtHandler, UserManager<UserModel> userManager, IConfiguration configuration)
        {
            _jwtHandler = jwtHandler;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Handle(ExternalLoginCommand request, CancellationToken cancellationToken)
        {
            var payload = await _jwtHandler.VerifyGoogleToken(request.In);
            if (payload == null)
                return new AuthResponseDto { ErrorMessage = "Invalid External Authentication." };
            var info = new UserLoginInfo(request.In.Provider, payload.Subject, request.In.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    return (new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }
            if (user == null)
                return new AuthResponseDto { ErrorMessage = "Invalid External Authentication." };
            //check for the Locked out account
            var role = await _userManager.GetRolesAsync(user);
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user, role);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var refreshToken = _jwtHandler.GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            await _userManager.UpdateAsync(user);
            return new AuthResponseDto { IsAuthSuccessful = true, Token = token, Role = role, RefreshToken = refreshToken };
        }
    }
}