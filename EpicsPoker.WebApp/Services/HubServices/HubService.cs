using EpicsPoker.WebApp.Components.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace EpicsPoker.WebApp.Services.HubServices;

public class HubService(NavigationManager navigationManager) : IHubService, IAsyncDisposable
{
    #region Statements

    private HubConnection? _hubConnection;

    #endregion

    #region InterfaceFunctions

    public Task InitializeConnectionAsync()
    {
        if (_hubConnection != null) 
            return Task.CompletedTask;
        
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/room-hub"))
            .Build();
        
        return _hubConnection.StartAsync();
    }
    
    public Task CreateRoomAsync(string roomName)
    {
        if (_hubConnection?.State != HubConnectionState.Connected)
            return Task.CompletedTask;
        
        return _hubConnection.SendAsync("CreateRoom", roomName);
    }

    public Task JoinRoomAsync(string roomName, User user)
    {
        if (_hubConnection?.State != HubConnectionState.Connected)
            return Task.CompletedTask;
        
        return _hubConnection.SendAsync("JoinRoom", roomName, user);
    }

    public Task LeaveRoomAsync(string roomName, User user)
    {
        if (_hubConnection?.State != HubConnectionState.Connected)
            return Task.CompletedTask;
        
        return _hubConnection.SendAsync("LeaveRoom", roomName, user);
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_hubConnection != null)
        {
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
        }

        GC.SuppressFinalize(this);
    }

    #endregion
    
    #region Functions

    public string GetBaseUri()
    {
        return navigationManager.BaseUri;
    }

    #endregion
}