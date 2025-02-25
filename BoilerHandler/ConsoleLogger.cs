namespace BoilerHandler;

public class ConsoleLogger
{
    public void DisplayConsole(string timeStamp, string eventStatus, string eventData)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[Log]  TimeStamp : {timeStamp} ," +
            $" Event : {eventStatus}, Data : {eventData}");
        Console.ResetColor();
        ////Thread.Sleep(10000);
        //Console.ReadLine();
    }
}
