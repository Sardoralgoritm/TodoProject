using MVCRep.Models.Dtos;

namespace TodoProject.Models;

public class ViewModel
{
    public List<TodoDto> AllTodos { get; set; }
    public List<TodoDto> CompletedTodos { get; set; }
    public AddTodoView AddTodoView { get; set; }
}
