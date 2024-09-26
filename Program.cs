using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using PetProjectC_NeuroWeb;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Configuration.AddJsonFile("appsettings.json");

var tokenOptions = new AuthOptions
{
    Issuer = builder.Configuration["Authentication:Issuer"],
    Audience = builder.Configuration["Authentication:Audience"],
    Key = builder.Configuration["Authentication:Key"]
};


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricKey(),
            ValidateIssuerSigningKey = true
        };
    });


var app = builder.Build();



app.Run();


// Lets celebrate and suck some dicks