using ExemploDDD.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExemploDDD.Infraestructure.Security.Tokens.Access.Generator;
public class JwtTokenGenerator : JwtTokenHandler, IAccessTokenGenerator
{
    private readonly uint _expirationTimesHours;
    private readonly string _signinKey;
    public JwtTokenGenerator(uint expirationTimesHours, string signinKey)
    {
        _expirationTimesHours = expirationTimesHours;
        _signinKey = signinKey;
    }

    public string Generate(string name, string email)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, name),
            new(ClaimTypes.Email, email)
        };

        var signinKey = JwtTokenHandler.SecurityKey(_signinKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
            Expires = DateTime.Now.AddHours(_expirationTimesHours)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}

