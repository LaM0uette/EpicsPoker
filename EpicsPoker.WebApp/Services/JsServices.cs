using Microsoft.JSInterop;

namespace EpicsPoker.WebApp.Services;

public class JsServices(IJSRuntime JSRuntime)
{
    public async Task CopyToClipboardAsync(string text)
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}