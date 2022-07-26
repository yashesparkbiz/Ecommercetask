using Ecommercetask.Data.Model;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecommercetask.Core.Handlers.UsersHandler.Command.SignInUser
{
    public class SignInUserCommand : IRequest<AuthResponseDto>
    {
        public SignInUserCommand(SignInModel @in)
        {
            In = @in;
        }
        public SignInModel In { get; }
    }

    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, AuthResponseDto>
    {
        private readonly UserManager<UserModel> _userManager;
        //private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly IConfiguration _configuration;

        public SignInUserCommandHandler(UserManager<UserModel> userManager, JwtHandler jwtHandler, IConfiguration configuration)
        {   
            _userManager = userManager;
            //_mapper = mapper;
            _jwtHandler = jwtHandler;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.In.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.In.Password))
                return (new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            else
            {
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

    //UserForAuthenticationDto
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

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public IList<string>? Role { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class ExternalAuthDto
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }

    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfigurationSection _goolgeSettings;

        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public  List<Claim> GetClaims(UserModel user, IList<string> role)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
            };
            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                //expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }
    }
}