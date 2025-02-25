namespace BoilerHandler;

/// <summary>
/// Logs the information to the console
/// </summary>
public class ConsoleLogger
{
    /// <summary>
    /// Displays the data about the
    /// <see cref="Boiler"/> as a log
    /// </summary>
    /// <param name="timeStamp">Current Time as string</param>
    /// <param name="eventStatus">The Status of the boiler</param>
    /// <param name="eventData">Description about the system state</param>
    public void DisplayConsole(
        string timeStamp,
        string eventStatus,
        string eventData)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[Log]  TimeStamp : {timeStamp} ," +
            $" Event : {eventStatus}, Data : {eventData}");
        Console.ResetColor();
    }
}
