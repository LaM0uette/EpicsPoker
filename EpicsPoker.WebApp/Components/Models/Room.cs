namespace EpicsPoker.WebApp.Components.Models;

public class Room(string name)
{
    public string Name { get; init; } = name;
    public int PicsParameter { get; set; }
    public List<User> Users { get; set; } = new();
}