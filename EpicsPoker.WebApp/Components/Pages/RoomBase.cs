﻿using Microsoft.AspNetCore.Components;

namespace EpicsPoker.WebApp.Components.Pages;

public class RoomBase : ComponentBase
{
    #region Statements

    [Parameter] public string RoomName { get; set; } = "";

    #endregion
}