using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using RecipeApi.Auth.Entities;
using RecipeApi.Auth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecipeApi.Auth
{

    public class AuthService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Entities.ApplicationUser> userManager;
        public AuthService(UserManager<Entities.ApplicationUser> userManager, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task<LogedInUserInfo> Login(string username,string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT: SecretKey"]));
                var token = new JwtSecurityToken(
                issuer: configuration["JWT: ValidIssuer"],
                audience: configuration["JWT: ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var loginResponse = new LogedInUserInfo() { expiration = token.ValidTo, token = new JwtSecurityTokenHandler().WriteToken(token) };
                return loginResponse;
            }
            throw new UnauthorizedAccessException();
        }

        public async Task<LogedInUserInfo> Register(string email,string username, string password)
        {
            var newUser = new ApplicationUser();
            newUser.UserName = username;
            newUser.Email = email;
            var resu = await userManager.CreateAsync(newUser,password);
            if (resu.Succeeded)
            {
               return await this.Login(username, password);
            }
            throw new Exception(resu.Errors.First().Description);
        }
    }
}
