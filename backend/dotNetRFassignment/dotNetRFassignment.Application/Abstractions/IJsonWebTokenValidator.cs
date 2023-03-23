namespace dotNetRFassignment.Application.Abstractions;

public interface IJsonWebTokenValidator
{
    bool ValidateToken(string token);
}
