using MongoDB.Bson;

namespace MVCRep.Models;

public class User
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Todo> UsersTodos { get; set; } = new();
}
