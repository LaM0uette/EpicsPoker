using EpicsPoker.WebApp.Components.Entity;
using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class RoomBase : ComponentBase
{
    #region Temporary

    protected int PicsParameter { get; private set; } = 10;
    protected int CurrentPics { get; private set; }

    #endregion
    
    #region Statements

    [Parameter] public string RoomName { get; set; } = "";
    
    protected GameState CurrentGameState = GameState.WaitingForPlayers;

    #endregion

    #region Events

    protected override void OnInitialized()
    {
        base.OnInitialized();
        CurrentGameState = GameState.ChoosePics;
    }

    protected void OnClickOnCard()
    {
        CurrentPics++;
        
        if (CurrentPics == PicsParameter)
        {
            CurrentGameState = GameState.ChooseCards;
        }
    }

    #endregion
}