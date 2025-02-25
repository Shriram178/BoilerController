using BoilerHandler.Constants;

namespace BoilerHandler.Model;

public class Boiler
{
    public string InterLockSwitch { get; set; }

    public string SystemStatus { get; set; }

    public string? EventData { get; set; }

    public Boiler()
    {
        InterLockSwitch = StringConstants.SwitchState[0];
        SystemStatus = StringConstants.SystemStatus[0];
        EventData = "Should be Closed to Start sequence";
    }
}
