using Gvn.IceCream.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gvn.IceCream.API.Services;

public class TokenServices
{
    private readonly IConfiguration _configuration;

    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = "*",
            IssuerSigningKey = GetSecurityKey(configuration)
        };
    }
    public string GenerateJwt(LoggedInUserDto user)
    {
        var secucityKey = GetSecurityKey(_configuration);
        var credentials = new SigningCredentials(secucityKey, SecurityAlgorithms.HmacSha256);
        var issuer = _configuration["Jwt:Issuer"];
        var expires = Convert.ToInt32(_configuration["Jwt:ExpireMinutes"]);
        var secretKey = _configuration["Jwt:SecretKey"];
        Claim[] claims = new[]
        {
           new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
           new Claim(ClaimTypes.Name,user.Name),
           new Claim(ClaimTypes.Email,user.Email),
           new Claim(ClaimTypes.StreetAddress,user.Address)
        };
        var token = new JwtSecurityToken(issuer: issuer,
            audience: "*",
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;

    }
    private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
    {
        var secretKey = configuration["Jwt:SecretKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        return securityKey;
    }

}
