﻿using EpicsPoker.WebApp.Services;
using EpicsPoker.WebApp.Services.HubServices;
using EpicsPoker.WebApp.Utils;
using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class HomeBase : ComponentBase
{
    #region Statements
    
    [Inject] public NavigationManager NavigationManager { get; init; } = default!;
    [Inject] private IHubService _hubService { get; init; } = default!;
    [Inject] private JsServices _jsServices { get; init; } = default!;

    protected string RoomLink { get; private set; } = "";
    protected int PicsParameter { get; private set; }

    #endregion

    #region Events
    
    protected async Task CopyRoomLink()
    {
        await _jsServices.CopyToClipboardAsync(RoomLink);
    }
    
    protected async Task GotoRoomLink()
    {
        if (string.IsNullOrEmpty(RoomLink))
            return;
        
        await _jsServices.CopyToClipboardAsync(RoomLink);
        NavigationManager.NavigateTo(RoomLink);
    }
    
    protected void OnChangePicsParameters(ChangeEventArgs obj)
    {
        PicsParameter = Convert.ToInt32(obj.Value);
    }
    
    protected async void CreateRoom()
    {
        var roomName = CommonMethods.GenerateKeyString();
        RoomLink = _hubService.GetBaseUri() + $"room/{roomName}";

        await _hubService.CreateRoomAsync(roomName);
    }

    #endregion
}