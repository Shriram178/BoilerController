using BoilerHandler.Constants;

namespace BoilerHandler.Model;

/// <summary>
/// Boiler that has a
/// switch to perform operations
/// </summary>
public class Boiler
{
    /// <summary>
    /// Switch has Open/Closed values
    /// </summary>
    public string InterLockSwitch { get; set; }

    /// <summary>
    /// Mentions the Status of the system
    /// </summary>
    public string SystemStatus { get; set; }

    /// <summary>
    /// Description the state the boiler is in.
    /// </summary>
    public string? EventData { get; set; }

    /// <summary>
    /// Constructor to initialize <see cref="Boiler"/>
    /// in LockOut state
    /// </summary>
    public Boiler()
    {
        InterLockSwitch = StringConstants.SwitchState[0];
        SystemStatus = StringConstants.SystemStatus[0];
        EventData = "Should be Closed to Start sequence";
    }
}
