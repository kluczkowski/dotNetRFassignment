namespace dotNetRFassignment.Infrastructure.Authentication;

public class JsonWebTokenOptions
{
    public string Issuer { get; init; }

    public string Audience { get; init; }

    public string SecretKey { get; init; }
}
