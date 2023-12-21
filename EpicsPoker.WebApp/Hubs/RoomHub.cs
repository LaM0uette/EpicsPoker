using EpicsPoker.WebApp.Components.Models;
using Microsoft.AspNetCore.SignalR;

namespace EpicsPoker.WebApp.Hubs;

public class RoomHub : Hub
{
    #region Statements

    private static readonly Dictionary<string, Room> Rooms = new();

    #endregion
    
    #region RoomCreation

    public void CreateRoom(string roomName)
    {
        var room = new Room(roomName);
        Rooms.Add(roomName, room);
    }

    #endregion
}