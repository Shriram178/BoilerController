namespace BoilerHandler.Model;

public class LogEntry
{
    public string TimeStamp { get; set; }
    public string EventStatus { get; set; }
    public string EventData { get; set; }

    public override string ToString()
    {
        return $"[Log]  TimeStamp : {TimeStamp} ," +
            $" Event : {EventStatus},  Data : {EventData}";
    }
}

