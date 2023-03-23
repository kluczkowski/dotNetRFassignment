namespace dotNetRFassignment.Domain.Shared.Validation;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("Validation.Error", "Validation problem occurred!");

    Error[] Errors { get; }
}
