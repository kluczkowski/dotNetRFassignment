using dotNetRFassignment.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace dotNetRFassignment.OptionsSetup;

public class JsonWebTokenBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
{
    private readonly JsonWebTokenOptions _jwtOptions;

    public JsonWebTokenBearerOptionsSetup(IOptions<JsonWebTokenOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
        options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
        options.TokenValidationParameters.IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
    }
}
