using dotNetRFassignment.Domain.Entities;

namespace dotNetRFassignment.Domain.Repositories;

public interface IMemberRepository
{
    Task<Member?> GetMemberAsync(string userName, string password);
}
