using dotNetRFassignment.Domain.Repositories;

namespace dotNetRFassignment.Persistence.Repositories;

public class MockDataRepository : IMockDataRepository
{
    public Task<string> GetDataAsync()
    {
        return Task.FromResult("tets");
    }
}
