namespace MVCRep.Models.Dtos;

public class UpdateTodoView
{
    public string Id { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}