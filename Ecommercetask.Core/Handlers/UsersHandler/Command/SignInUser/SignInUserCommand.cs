﻿using Ecommercetask.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public SignInUserCommandHandler(UserManager<UserModel> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            //_mapper = mapper;
            _jwtHandler = jwtHandler;
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
                return new AuthResponseDto { IsAuthSuccessful = true, Token = token, Role = role };
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
    }

    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(UserModel user, IList<string> role)
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
    }
}