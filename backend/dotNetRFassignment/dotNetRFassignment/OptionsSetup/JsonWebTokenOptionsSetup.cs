using dotNetRFassignment.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace dotNetRFassignment.OptionsSetup;

public class JsonWebTokenOptionsSetup : IConfigureOptions<JsonWebTokenOptions>
{
    private const string SectionName = "JsonWebToken";
    private readonly IConfiguration _configuration;

    public JsonWebTokenOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JsonWebTokenOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
