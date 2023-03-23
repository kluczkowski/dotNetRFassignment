using dotNetRFassignment.Domain.Shared.Validation;
using MediatR;

namespace dotNetRFassignment.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}