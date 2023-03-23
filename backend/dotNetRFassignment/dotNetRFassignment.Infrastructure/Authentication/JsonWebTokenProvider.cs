using dotNetRFassignment.Application.Abstractions;
using dotNetRFassignment.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotNetRFassignment.Infrastructure.Authentication;

public sealed class JsonWebTokenProvider : IJsonWebTokenProvider
{
    private readonly JsonWebTokenOptions _options;

    public JsonWebTokenProvider(IOptions<JsonWebTokenOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(Member member)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, member.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, member.UserName)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
