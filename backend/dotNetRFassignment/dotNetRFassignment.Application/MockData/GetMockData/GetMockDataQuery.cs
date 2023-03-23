using dotNetRFassignment.Application.Abstractions.Messaging;

namespace dotNetRFassignment.Application.MockData.GetMockData;

public sealed record GetMockDataQuery(string Token) : IQuery<GetMockDataResponse>;
