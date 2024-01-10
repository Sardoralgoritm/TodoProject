using MongoDB.Bson;
using System.Runtime.CompilerServices;

namespace MVCRep.Models.Dtos;

public class TodoDto
{
    public string Id { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public static explicit operator TodoDto(Todo todo)
        => new()
        {
            Id = todo.Id.ToString(),
            Content = todo.Content,
            IsCompleted = todo.IsCompleted
        };


    public static implicit operator Todo(TodoDto todoDto)
        => new()
        {
            Id = ObjectId.Parse(todoDto.Id),
            Content = todoDto.Content,
            IsCompleted = todoDto.IsCompleted
        };
}
