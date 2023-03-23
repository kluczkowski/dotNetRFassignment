using dotNetRFassignment.Domain.Shared.Validation;
using MediatR;

namespace dotNetRFassignment.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}