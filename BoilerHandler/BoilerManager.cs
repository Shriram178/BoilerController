using System.Globalization;
using BoilerHandler.Model;

namespace BoilerHandler;

/// <summary>
/// Delegate to handle Log messages.
/// </summary>
/// <param name="timeStamp">Current Time as string</param>
/// <param name="eventStatus">The Status of the boiler</param>
/// <param name="eventData">Description about the system state</param>
public delegate void LogDataHandler(string timeStamp, string eventStatus, string eventData);

/// <summary>
/// Performs operation on the <see cref="Boiler"/>
/// </summary>
public class BoilerManager
{
    /// <summary>
    /// Event to handle log operations
    /// </summary>
    public event LogDataHandler LogData;

    /// <summary>
    /// Singleton instance of <see cref="ConsoleLogger"/>
    /// </summary>
    public ConsoleLogger Logger = new ConsoleLogger();

    public FileLogger FileLogger = new FileLogger();

    private static Boiler _boiler;
    public BoilerManager()
    {
        Greet();
        LogData += Logger.DisplayConsole;
        LogData += FileLogger.WriteLogToFile;
        _boiler = new Boiler();
    }

    /// <summary>
    /// Simulates the state change from
    /// PrePurge phase to ignition then finally to
    /// Operational
    /// </summary>
    public void StartSequence()
    {
        if (_boiler.InterLockSwitch == "Closed")
        {
            StartPrePurge();
            StartIgnition();
            TransitionToOperationalPhase();
        }
        else
        {
            Console.WriteLine("Switch must be Closed to start !!");
            EventInvoker();
        }
    }

    /// <summary>
    /// Stops the sequence and 
    /// restarts the boiler.
    /// </summary>
    public void StopSequence()
    {
        _boiler = new Boiler();
        _boiler.EventData = "Boiler Stopped!!";
        EventInvoker();
    }

    /// <summary>
    /// Simulates a error in the
    /// <see cref="Boiler"/> during 
    /// Operational status
    /// </summary>
    public void SimulateBoilerError()
    {
        if (_boiler.SystemStatus == "Operational")
        {
            _boiler.EventData = "Boiler Error in Operational Mode";
            EventInvoker();
            ResetLockOut();
            throw new BoilerError("Simulated Boiler error in operational mode");
        }
        Console.WriteLine("Boiler is not in operational mode , Nothing to simulate !!");
        Console.ReadKey();
    }

    /// <summary>
    /// Changes the state of the
    /// <see cref="Boiler.InterLockSwitch"/>
    /// </summary>
    /// <param name="switchState">Closed/Open</param>
    public void ToggleRunInteractorSwitch(string switchState)
    {
        _boiler.InterLockSwitch = switchState;
    }
    public void Greet()
    {
        Console.WriteLine("\n Welcome Boiler Initialized !! ");
        Console.ReadKey();
    }

    /// <summary>
    /// Restarts the <see cref="Boiler"/>
    /// to its initial state
    /// </summary>
    public void ResetLockOut()
    {
        if (_boiler.InterLockSwitch == "Closed")
        {
            _boiler.SystemStatus = "Ready";
            _boiler.EventData = "Boiler Reset!!";
        }
        else
        {
            _boiler.EventData = "Cannot Reset ,Boiler switch is open!!";
        }

        EventInvoker();
    }

    /// <summary>
    /// Returns the log data fetched from
    /// a CSV
    /// </summary>
    /// <returns><see cref="List{LogEntry}"/></returns>
    public List<LogEntry> GetEventLog()
    {
        List<LogEntry> logEntries = FileLogger.RetrieveLogData();
        return logEntries;
    }

    private void StartPrePurge()
    {
        _boiler.SystemStatus = "Pre-Purge";
        _boiler.EventData = "Pre-Purge phase completed.";
        CountDown();
    }

    private void StartIgnition()
    {
        _boiler.SystemStatus = "Ignition";
        _boiler.EventData = "Ignition phase completed.";
        CountDown();
    }

    private void TransitionToOperationalPhase()
    {
        _boiler.SystemStatus = "Operational";
        _boiler.EventData = "Boiler now operational";
        EventInvoker();
    }

    private void CountDown()
    {
        Console.Write(_boiler.SystemStatus);
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($" {i}");
            Thread.Sleep(1000);
        }
        LogData?.Invoke(GetCurrentDateTime(),
                _boiler.SystemStatus,
                _boiler.EventData);
    }

    private string GetCurrentDateTime()
    {
        DateTime now = DateTime.Now;
        string formattedNow = now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        return formattedNow;
    }

    private void EventInvoker()
    {
        LogData?.Invoke(GetCurrentDateTime(),
                _boiler.SystemStatus,
                _boiler.EventData);

        Console.ReadKey();
    }

}
