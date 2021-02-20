using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentsAccounting.DTOs;
using StudentsAccounting.Entities;

namespace StudentsAccounting.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IMailServices mailServices;

        public UserServices(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, IMailServices mailServices)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
            this.mailServices = mailServices;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegistrerRequest user)
        {
            var newUser = mapper.Map<RegistrerRequest, User>(user);
            var result = await userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                var confirmEmailToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{configuration["AppUrl"]}/api/auth/confirmemail?userId={newUser.Id}&token={validEmailToken}";

                await mailServices.SendMailAsync(newUser.Email, "Confirm your email", "<h1>Welcome to Students Courses!</h1>" + $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");

                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not created!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(AuthRequest creds)
        {
            var user = await userManager.FindByEmailAsync(creds.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false
                };
            }

            var result = await userManager.CheckPasswordAsync(user, creds.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid password!",
                    IsSuccess = false
                };
            }

            var claims = new[]
            {
                new Claim("Email", creds.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: configuration["AuthSettings:Issuer"],
                audience: configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedEmailToken = WebEncoders.Base64UrlDecode(token);
            var normalEmailToken = Encoding.UTF8.GetString(decodedEmailToken);

            var result = await userManager.ConfirmEmailAsync(user, normalEmailToken);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = "Email confirmed succesfully",
                };
            }

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
