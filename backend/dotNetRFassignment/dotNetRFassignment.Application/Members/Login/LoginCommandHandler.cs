using dotNetRFassignment.Application.Abstractions;
using dotNetRFassignment.Application.Abstractions.Messaging;
using dotNetRFassignment.Domain.Entities;
using dotNetRFassignment.Domain.Repositories;
using dotNetRFassignment.Domain.Shared.Validation;

namespace dotNetRFassignment.Application.Members.Login;
internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJsonWebTokenProvider _jsonWebTokenProvider;

    public LoginCommandHandler(IMemberRepository memberRepository, IJsonWebTokenProvider jsonWebTokenProvider)
    {
        _memberRepository = memberRepository;
        _jsonWebTokenProvider = jsonWebTokenProvider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Member? member = await _memberRepository.GetMemberAsync(request.UserName, request.Password);
        
        if (member == null) 
        {
            return Result.Failure<string>(new Error(
                "Member.InvalidCredentials",
                "The provided credentials are invalid"));
        }

        string token = _jsonWebTokenProvider.Generate(member);

        return token;
    }
}
