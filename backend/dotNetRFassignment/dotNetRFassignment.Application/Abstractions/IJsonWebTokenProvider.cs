using dotNetRFassignment.Domain.Entities;

namespace dotNetRFassignment.Application.Abstractions;

public interface IJsonWebTokenProvider
{
    string Generate(Member member);
}
