using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Supplychain_Core.Helper;
using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Supplychain_Core.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTSettings _jwtSettings;

        public AuthService(UserManager<IdentityUser> userManager , IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthModelResponse> RegisterAsync(AuthModelRequest request)
        {
            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail != null)
                return new AuthModelResponse(false, "Email is already registered");

            var existUserName = await _userManager.FindByNameAsync(request.UserName);
            if (existUserName != null)
                return new AuthModelResponse(false, "UserName is already registered");

            var newUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(newUser,password:request.Password);
            if (!result.Succeeded)
                return new AuthModelResponse(false, "Fail to create user");


            // add while generating new User in Users table adding a specific role in the database in UserRole table  
            await _userManager.AddToRoleAsync(newUser,"Customer");

            // create token 
            var accessToken = CreateToken(request);
            return new AuthModelResponse
                (true,request.UserName,request.Email,accessToken,DateTime.Now.AddMinutes(_jwtSettings.Duration)); 

        }

        private string CreateToken(AuthModelRequest request) 
        {
            // token Handler , token Descreptor

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescreptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.UserName),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role , "Customer")
                })
            };
            var securityToken =  tokenHandler.CreateToken(tokenDescreptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
    }
}
