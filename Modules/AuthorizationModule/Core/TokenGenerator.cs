using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.DataTransferObject;
using System.Security.Cryptography.X509Certificates;


namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule.Core
{
    public static class TokenGeneratorService
    {

        public static AuthOptions tokenOptions { get; set; } = null!;

        public static string GenerateToken(UserDTO userDTO)
        {

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
