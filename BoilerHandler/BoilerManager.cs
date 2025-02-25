using System.Timers;
using BoilerHandler.Model;

namespace BoilerHandler;

public delegate void LogDataHandler(string timeStamp, string eventStatus, string eventData);

public class BoilerManager
{
    public event LogDataHandler LogData;

    public ConsoleLogger Logger = new ConsoleLogger();

    public System.Timers.Timer timer = new System.Timers.Timer(10000);

    private static Boiler _boiler;
    public BoilerManager()
    {
        Greet();
        LogData += Logger.DisplayConsole;
        _boiler = new Boiler();
    }

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

    public void StartPrePurge()
    {
        _boiler.SystemStatus = "Pre-Purge";
        _boiler.EventData = "Pre-Purge phase completed.";
        //System.Timers.Timer timer = new System.Timers.Timer(10000);
        //timer.Elapsed += TimerElapsed;
        //timer.AutoReset = false;
        //timer.Start();
        CountDown();
    }

    public void StartIgnition()
    {
        _boiler.SystemStatus = "Ignition";
        _boiler.EventData = "Ignition phase completed.";
        //System.Timers.Timer timer = new System.Timers.Timer(10000);
        //timer.AutoReset = false;
        //timer.Start();
        CountDown();
    }

    public void TransitionToOperationalPhase()
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

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        LogData?.Invoke(GetCurrentDateTime(),
                _boiler.SystemStatus,
                _boiler.EventData);
    }

    private string GetCurrentDateTime()
    {
        DateTime now = DateTime.UtcNow;
        string formattedNow = now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        return formattedNow;
    }


    public void StopSequence()
    {
        _boiler = new Boiler();
        _boiler.EventData = "Boiler Stopped!!";
        EventInvoker();

    }
    public void SimulateBoilerError() { }
    public void ToggleRunInteractorSwitch(string switchState)
    {
        _boiler.InterLockSwitch = switchState;
    }
    public void Greet() { }
    public void ResetLockOut()
    {
        _boiler = new Boiler();
        _boiler.EventData = "Boiler Reset!!";
        EventInvoker();

    }
    public void EventInvoker()
    {
        LogData?.Invoke(GetCurrentDateTime(),
                _boiler.SystemStatus,
                _boiler.EventData);
        Console.ReadKey();
    }

    public void ViewEventLog() { }


}
