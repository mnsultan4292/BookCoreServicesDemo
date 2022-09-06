﻿using BookCoreServicesDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookCoreServicesDemo.Helper
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration _config;
        public JwtHelper(IConfiguration configuration)
        {
            _config = configuration;
        }

        // To generate token
        public string GenerateToken(UserRegistration user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Username),
                    new Claim(ClaimTypes.Role,user.Role)
                };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
