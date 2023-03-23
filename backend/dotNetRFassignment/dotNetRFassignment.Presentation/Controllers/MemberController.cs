using dotNetRFassignment.Application.Members.Login;
using dotNetRFassignment.Domain.Shared.Validation;
using dotNetRFassignment.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRFassignment.Presentation.Controllers;

public class MemberController : ApiController
{
    public MemberController(ISender sender) : base(sender)
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginMember(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.UserName, request.Password);

        Result<string> tokenResult = await Sender.Send(
            command,
            cancellationToken);

        if (tokenResult.IsFailure)
        {
            return HandleFailure(tokenResult);
        }

        return Ok(tokenResult.Value);
    }
}
