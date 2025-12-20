using Api.Models;

namespace Api.Services;

public interface IElasticServices
{
    // create index
    Task CreateIndexIfNotExistsAsync(string indexName);
    // add or update a user
    Task<bool> AddOrUpdate(User user);
    // add or update user bulk
    Task<bool> AddOrUpdateBulk(IEnumerable<User> users,string indexName);
    // Get user
    Task<User> Get(string key);
    // Get all users
    Task<List<User>?> GetAll();
    // Remove
    Task<bool> Remove(string key);
    // Remove all
    Task<long?> RemoveAll();
}