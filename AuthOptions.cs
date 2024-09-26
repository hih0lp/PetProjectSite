using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetProjectC_NeuroWeb
{
    public record class AuthOptions
    {
        public string? Issuer;
        public string? Audience;
        public string? Key;

        public SymmetricSecurityKey GetSymmetricKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key!));
        }
    }
}
