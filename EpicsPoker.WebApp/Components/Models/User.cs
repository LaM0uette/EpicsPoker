namespace EpicsPoker.WebApp.Components.Models;

public class User(string guid, string name)
{
    public string Guid { get; } = guid;
    public string Name { get; } = name;
}