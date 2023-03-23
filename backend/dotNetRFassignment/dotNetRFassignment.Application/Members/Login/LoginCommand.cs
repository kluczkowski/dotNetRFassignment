using dotNetRFassignment.Application.Abstractions.Messaging;

namespace dotNetRFassignment.Application.Members.Login;

public record LoginCommand(string UserName, string Password) : ICommand<string>;