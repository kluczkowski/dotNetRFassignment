namespace dotNetRFassignment.Domain.Shared.Validation;

public static class ResultExtension
{
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error)
    {
        if (result.IsFailure) { return result; }

        return predicate(result.Value) ? result : Result.Failure<T>(error);
    }

    public static Result<TOutput> Map<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> mapping)
    {
        return result.IsSuccess ? Result.Success(mapping(result.Value)) : Result.Failure<TOutput>(result.Error);
    }
}
