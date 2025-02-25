namespace BoilerHandler;

/// <summary>
/// Runs the main application
/// </summary>
public class Program
{
    /// <summary>
    /// Acts as the entry point of the
    /// program
    /// </summary>
    static void Main()
    {
        UserInteractor user = new UserInteractor();
        user.DisplayMenu();
    }
}
