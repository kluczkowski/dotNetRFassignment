using dotNetRFassignment.Application.Abstractions;
using dotNetRFassignment.Application.Abstractions.Messaging;
using dotNetRFassignment.Domain.Repositories;
using dotNetRFassignment.Domain.Shared.Validation;

namespace dotNetRFassignment.Application.MockData.GetMockData;

internal sealed class GetMockDataQueryHandler : IQueryHandler<GetMockDataQuery, GetMockDataResponse>
{
    private readonly IMockDataRepository _mockDataRepository;
    private readonly IJsonWebTokenValidator _jsonWebTokenValidator;

    public GetMockDataQueryHandler(IMockDataRepository mockDataRepository, IJsonWebTokenValidator jsonWebTokenValidator)
    {
        _mockDataRepository = mockDataRepository;
        _jsonWebTokenValidator = jsonWebTokenValidator;
    }

    public async Task<Result<GetMockDataResponse>> Handle(GetMockDataQuery request, CancellationToken cancellationToken)
    {
        var token = request.Token;

        if (token == null) 
        {
            return Result.Failure<GetMockDataResponse>(new Error(
                "Token.Invalid",
                "The provided token is invalid"));
        }

        var isTokenValid = _jsonWebTokenValidator.ValidateToken(request.Token);

        if (!isTokenValid) 
        {
            return Result.Failure<GetMockDataResponse>(new Error(
                "Token.Invalid",
                "The provided token is invalid"));
        }

        var s = await _mockDataRepository.GetDataAsync();

        var response = new GetMockDataResponse(Guid.NewGuid(), s);

        return response;
    }
}
