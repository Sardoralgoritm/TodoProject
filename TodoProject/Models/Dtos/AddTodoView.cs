namespace MVCRep.Models.Dtos;

public class AddTodoView
{
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }


    public static implicit operator Todo(AddTodoView addTodoView)
        => new()
        {
            Content = addTodoView.Content,
            IsCompleted = addTodoView.IsCompleted
        };
}
