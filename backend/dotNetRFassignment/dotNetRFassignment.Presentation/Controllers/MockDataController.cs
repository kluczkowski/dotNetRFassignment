using dotNetRFassignment.Application.MockData.GetMockData;
using dotNetRFassignment.Domain.Shared.Validation;
using dotNetRFassignment.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRFassignment.Presentation.Controllers;

[Route("api/mocdata")]
public sealed class MockDataController : ApiController
{
    public MockDataController(ISender sender) : base(sender)
    {
    }

    [HttpGet("getData")]
    public async Task<IActionResult> GetMockData(string token, CancellationToken cancellationToken)
    {
        var query = new GetMockDataQuery(token);

        Result<GetMockDataResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }
}
