namespace BoilerHandler.Constants;

/// <summary>
/// Class to store string constants
/// </summary>
public static class StringConstants
{

    public static readonly IList<string> SwitchState = new List<string> { "Open", "Closed" };

    public static readonly IList<string> SystemStatus = new List<string> { "LockOut", "Ready", "Pre-Purge", "Ignition", "Operational" };

    public static readonly IList<string> MenuOperations = new List<string> { "Start Sequence", "Stop Sequence",
        "Simulate Boiler Error", "Toggle InterLock Switch",
        "Reset Lockout", "View Log", "Exit" };

    public static readonly string selectMenuOptions = "Select the operation you want to perform using [↑/↓]   :";

    public static readonly string MenuFields = "\n[B] - Back   [Enter] - Select   [↑/↓] - Navigate";

}
