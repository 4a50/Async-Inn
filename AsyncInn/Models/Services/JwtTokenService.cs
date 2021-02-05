using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
  public class JwtTokenService
  {
    private IConfiguration configuration;
    private SignInManager<ApplicationUser> signInManager;
    public JwtTokenService(IConfiguration config, SignInManager<ApplicationUser> manager)
    {
      configuration = config;
      signInManager = manager;
    }

    /// <summary>
    /// Revieve
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
    {
      return new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = GetSecurityKey(configuration),
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    }
    /// <summary>
    /// Retrieves the JWT Security Key, return an exception if none are found.
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static SecurityKey GetSecurityKey(IConfiguration configuration)
    {
      var secret = configuration["JWT:Secret"];
      if (secret == null) { throw new InvalidOperationException("No JWT Secret Found"); }
      var secretBytes = Encoding.UTF8.GetBytes(secret);
      return new SymmetricSecurityKey(secretBytes);
    }
  }
}
