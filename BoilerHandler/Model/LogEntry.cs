namespace BoilerHandler.Model;

/// <summary>
/// Model to store retrieved 
/// log data
/// </summary>
public class LogEntry
{
    /// <summary>
    /// Time the log was created at.
    /// </summary>
    public string TimeStamp { get; set; }

    /// <summary>
    /// Status of the <see cref="Boiler"/>
    /// during log message
    /// </summary>
    public string EventStatus { get; set; }

    /// <summary>
    /// Description of the log event that 
    /// occurred in the boiler
    /// </summary>
    public string EventData { get; set; }
}

