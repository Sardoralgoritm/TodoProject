using MVCRep.Models.Dtos;

namespace MVCRep.Models.Repositories;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllTodosAsync();
    Task<TodoDto> GetByIdAsync(string id);
    Task CreateAsync(AddTodoView addTodoView);
    Task UpdateAsync(string id, string content);
    Task UpdateCompleteAsync(string id);
    Task DeleteTodoAsync(string id);
}
