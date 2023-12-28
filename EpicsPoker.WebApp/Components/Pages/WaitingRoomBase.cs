using EpicsPoker.WebApp.Services.HubServices;
using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class WaitingRoomBase : ComponentBase
{
    #region Statements
    
    [Inject] private NavigationManager _navigationManager { get; init; } = default!;
    [Inject] private IHubService _hubService { get; init; } = default!;
    
    [Parameter] public string RoomName { get; set; } = "";
    
    #endregion

    #region Events

    protected override void OnInitialized()
    {
        GetAndGotoRoom();
    }

    #endregion

    #region Functions
    
    private void GetAndGotoRoom()
    {
        var roomLink = _hubService.GetBaseUri() + $"Room/{RoomName}";
        _navigationManager.NavigateTo(roomLink);
    }

    #endregion
}