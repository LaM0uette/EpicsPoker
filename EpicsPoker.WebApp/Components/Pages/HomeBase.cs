using EpicsPoker.WebApp.Services.HubServices;
using EpicsPoker.WebApp.Utils;
using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class HomeBase : ComponentBase
{
    #region Statements
    
    [Inject] private HubService _hubService { get; init; } = default!;

    protected string? RoomLink;
    protected int PicsParameter { get; private set; }

    #endregion

    #region Events

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