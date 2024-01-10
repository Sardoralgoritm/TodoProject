using MongoDB.Driver;

namespace MVCRep.Models;

public class AppDbContext
{
    private readonly IMongoDatabase _database;
    public AppDbContext(string connectionString)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("TodoDB");
    }

    public IMongoCollection<Todo> Todos
        => _database.GetCollection<Todo>("Todos");

    public IMongoCollection<User> Users
        => _database.GetCollection<User>("Users");
}
