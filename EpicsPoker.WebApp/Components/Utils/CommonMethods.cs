namespace EpicsPoker.WebApp.Components.Utils;

public static class CommonMethods
{
    public static string GenerateKeyString()
    {
        return Guid.NewGuid().ToString("N");
    }
}