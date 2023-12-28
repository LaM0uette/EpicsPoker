using EpicsPoker.WebApp.Services;
using EpicsPoker.WebApp.Services.HubServices;
using EpicsPoker.WebApp.Utils;
using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class HomeBase : ComponentBase
{
    #region Statements
    
    [Inject] private NavigationManager _navigationManager { get; init; } = default!;
    [Inject] private IHubService _hubService { get; init; } = default!;
    [Inject] private JsService _jsService { get; init; } = default!;

    protected string RoomLink { get; private set; } = "";
    protected int PicsParameter { get; private set; }

    #endregion

    #region Events
    
    protected async Task CopyRoomLink()
    {
        await _jsService.CopyToClipboardAsync(RoomLink);
    }
    
    protected async Task GotoWaitingRoom()
    {
        if (string.IsNullOrEmpty(RoomLink))
            return;
        
        await _jsService.CopyToClipboardAsync(RoomLink);
        _navigationManager.NavigateTo(RoomLink);
    }
    
    protected void OnChangePicsParameters(ChangeEventArgs obj)
    {
        PicsParameter = Convert.ToInt32(obj.Value);
    }
    
    protected async void CreateRoom()
    {
        var roomName = CommonMethods.GenerateKeyString();
        RoomLink = _hubService.GetBaseUri() + $"WaitingRoom/{roomName}";

        await _hubService.CreateRoomAsync(roomName);
    }

    #endregion
}