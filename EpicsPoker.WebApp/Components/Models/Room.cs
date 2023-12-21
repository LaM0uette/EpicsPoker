namespace EpicsPoker.WebApp.Components.Models;

public class Room(string name)
{
    public string Name { get; init; } = name;
    public List<User> Users { get; set; } = new();
}