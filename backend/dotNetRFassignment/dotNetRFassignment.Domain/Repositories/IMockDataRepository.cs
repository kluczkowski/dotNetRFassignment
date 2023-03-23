namespace dotNetRFassignment.Domain.Repositories;

public interface IMockDataRepository
{
    Task<string> GetDataAsync();
}
