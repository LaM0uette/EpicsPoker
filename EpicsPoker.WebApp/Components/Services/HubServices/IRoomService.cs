﻿using EpicsPoker.WebApp.Components.Models;

namespace EpicsPoker.WebApp.Components.Services.HubServices;

public interface IRoomService
{
    Task CreateRoomAsync(string roomName);
    Task JoinRoomAsync(string roomName, User user);
    Task LeaveRoomAsync(string roomName, User user);
}