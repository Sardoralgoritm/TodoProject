using MongoDB.Bson;

namespace MVCRep.Models.Dtos;

public class UserDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<TodoDto> UsersTodos { get; set; } = new();

    public static implicit operator UserDto(User user)
        => new()
        {
            Id = user.Id.ToString(),
            Name = user.Name,
            UsersTodos = user.UsersTodos.Select(i => (TodoDto)i).ToList()
        };

    public static implicit operator User(UserDto userDto)
        => new()
        {
            Id = ObjectId.Parse(userDto.Id),
            Name = userDto.Name
        };
}
