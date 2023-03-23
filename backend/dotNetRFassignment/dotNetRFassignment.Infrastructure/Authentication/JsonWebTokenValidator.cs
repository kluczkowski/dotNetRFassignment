using dotNetRFassignment.Application.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace dotNetRFassignment.Infrastructure.Authentication;

public sealed class JsonWebTokenValidator : IJsonWebTokenValidator
{
    private readonly JsonWebTokenOptions _options;

    public JsonWebTokenValidator(IOptions<JsonWebTokenOptions> options)
    {
        _options = options.Value;
    }

    public bool ValidateToken(string token)
    {
        var key = Encoding.UTF8.GetBytes(_options.SecretKey);

        new JwtSecurityTokenHandler().ValidateToken(
            token,
            new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            },
            out var securityToken);

        return securityToken != null;
    }
}
