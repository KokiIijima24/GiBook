using System.Text;
using GiBook.API.Models;
using GiBook.API.Services;
using GiBook.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GiBook.API.Extensions
{
  public static class IdentityServiceExtensions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddIdentityCore<AppUser>(opt =>
      {
        opt.Password.RequireNonAlphanumeric = false;
      })
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddSignInManager<SignInManager<AppUser>>();

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(opt =>
      {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = key,
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
      services.AddScoped<TokenService>();

      return services;
    }
  }
}