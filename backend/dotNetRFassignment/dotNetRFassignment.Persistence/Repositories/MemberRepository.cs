using dotNetRFassignment.Domain.Entities;
using dotNetRFassignment.Domain.Repositories;

namespace dotNetRFassignment.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private ICollection<Member> _members = new List<Member> { new Member { Id = Guid.NewGuid(), UserName = "Administrator", Password = "Password" } };

    public MemberRepository()
    {
    }

    public Task<Member?> GetMemberAsync(string userName, string password)
    {
        var member = _members.FirstOrDefault(x => x.UserName == userName && x.Password == password);

        return Task.FromResult(member);
    }
}
