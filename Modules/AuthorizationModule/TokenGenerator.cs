using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;
using PetProjectC_NeuroWeb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.DataTransferObject;


namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule
{
    public static class TokenGenerator
    {

        public static string GenerateToken(this WebApplicationBuilder builder, UserDTO userDTO)
        {
            var tokenOptions = new AuthOptions
            {
                Issuer = builder.Configuration["Authentication:Issuer"],
                Audience = builder.Configuration["Authentication:Audience"],
                Key = builder.Configuration["Authentication:Key"]
            };

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userDTO.login!) };

            var JWT = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(tokenOptions.GetSymmetricKey(), SecurityAlgorithms.HmacSha512)
                );

            return new JwtSecurityTokenHandler().WriteToken(JWT);
        }
    }
}
