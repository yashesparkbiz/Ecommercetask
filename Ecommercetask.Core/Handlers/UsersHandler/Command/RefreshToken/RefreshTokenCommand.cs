using Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser;
using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenModel>
    {
        public TokenModel tokenModel { get; set; }
    }

    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, TokenModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly UserManager<UserModel> _userManager;
        private readonly JwtHandler _jwtHandler;

        public RefreshTokenHandler(IConfiguration configuration, UserManager<UserModel> userManager, JwtHandler jwtHandler)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<TokenModel> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            if (command.tokenModel is null)
            {
                return new TokenModel()
                {
                    AccessToken = "",
                    RefreshToken = "Invalid client request"
                };
            }

            string? accessToken = command.tokenModel.AccessToken;
            string? refreshToken = command.tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return new TokenModel()
                {
                    AccessToken = "",
                    RefreshToken = "Invalid access token or refresh token"
                };
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return new TokenModel()
                {
                    AccessToken = "",
                    RefreshToken = "Invalid access token or refresh token"
                };
            }

            var role = await _userManager.GetRolesAsync(user);
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user, role);
            var newAccessToken = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            //var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = _jwtHandler.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new TokenModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}