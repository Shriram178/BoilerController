using BoilerHandler.Model;
namespace BoilerHandler;

/// <summary>
/// Handles logging and retrieving logs
/// from a file
/// </summary>
public class FileLogger
{
    private static string filePath = Path.Combine(
        Directory.GetCurrentDirectory(),
        "Boiler Log.csv");

    /// <summary>
    /// Writes the log data to a CSV
    /// file
    /// </summary>
    /// <param name="timeStamp">Current Time as string</param>
    /// <param name="eventStatus">The Status of the boiler</param>
    /// <param name="eventData">Description about the system state</param>
    public void WriteLogToFile(
        string timeStamp,
        string eventStatus,
        string eventData)
    {
        string csvLine = $"{timeStamp},{eventStatus},{eventData}";

        bool fileExists = File.Exists(filePath);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (!fileExists)
            {
                writer.WriteLine("TimeStamp,EventStatus,EventData");
            }
            writer.WriteLine(csvLine);
        }
    }

    /// <summary>
    /// Retrieves the data from the CSV and 
    /// returns the data
    /// </summary>
    /// <returns><see cref="List{LogEntry}"/></returns>
    public List<LogEntry> RetrieveLogData()
    {
        var logEntries = new List<LogEntry>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    var values = line.Split(',');

                    if (values.Length == 3)
                    {
                        logEntries.Add(new LogEntry
                        {
                            TimeStamp = values[0],
                            EventStatus = values[1],
                            EventData = values[2]
                        });
                    }
                }
            }
        }

        return logEntries;
    }

}

