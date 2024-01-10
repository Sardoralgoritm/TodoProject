using MongoDB.Bson;

namespace MVCRep.Models;

public class Todo
{
    public ObjectId Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
