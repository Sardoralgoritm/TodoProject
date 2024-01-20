using MongoDB.Bson;
using MongoDB.Driver;
using MVCRep.Models.Dtos;

namespace MVCRep.Models.Repositories;

public class TodoService(AppDbContext appDbContext) : ITodoService
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task CreateAsync(AddTodoView addTodoView)
    {
        var todo = (Todo)addTodoView;
        await _appDbContext.Todos.InsertOneAsync(todo);
    }

    public async Task DeleteTodoAsync(string id)
    {
        await _appDbContext.Todos.DeleteOneAsync(i => i.Id == ObjectId.Parse(id));
    }

    public async Task<List<TodoDto>> GetAllTodosAsync()
    {
        var todos = await _appDbContext.Todos.Find(_ => true).ToListAsync();
        return todos.Select(i => (TodoDto)i).ToList();
    }

    public async Task<TodoDto> GetByIdAsync(string id)
        => (TodoDto)await _appDbContext.Todos.Find(i => i.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

    public async Task UpdateAsync(string id, string content)
    {
        var todo = (Todo)await GetByIdAsync(id);
        todo.Content = content;
        await _appDbContext.Todos.ReplaceOneAsync(i => i.Id == todo.Id, todo);
    }

    public async Task UpdateCompleteAsync(string id)
    {
        var todo = (Todo)await GetByIdAsync(id);
        todo.IsCompleted = !todo.IsCompleted;
        await _appDbContext.Todos.ReplaceOneAsync(i => i.Id == todo.Id, todo);
    }
}
