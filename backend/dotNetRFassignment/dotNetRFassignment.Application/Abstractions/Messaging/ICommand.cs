using dotNetRFassignment.Domain.Shared.Validation;
using MediatR;

namespace dotNetRFassignment.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
