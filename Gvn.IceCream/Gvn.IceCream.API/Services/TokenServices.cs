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
    public string GenerateJwt(Guid userId, string userName)
    {
        var secucityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
        var credentials = new SigningCredentials(secucityKey, SecurityAlgorithms.HmacSha256);
        var issuer = _configuration["Jwt:Issuer"];
        var expires=Convert.ToInt32(_configuration["Jwt:ExpireMinutes"]);
        var secretKey = _configuration["Jwt:SecretKey"];
        var token = new JwtSecurityToken(issuer: issuer,
            audience: "*",
            claims:new Claim[]
            { 
            },
            expires:DateTime.Now.AddMinutes(expires),
            signingCredentials: credentials);
        
        var jwt=new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;

    }

}
