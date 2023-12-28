using EpicsPoker.WebApp.Components.Models;

namespace EpicsPoker.WebApp.Services.HubServices;

public interface IHubService
{
    public Task InitializeConnectionAsync();
    
    public Task CreateRoomAsync(string roomName);
    public Task JoinRoomAsync(string roomName, User user);
    public Task LeaveRoomAsync(string roomName, User user);
    
    public string GetBaseUri();
}