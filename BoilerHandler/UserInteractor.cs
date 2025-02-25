using BoilerHandler.Constants;

namespace BoilerHandler;

public class UserInteractor
{
    private BoilerManager boilerManager = new BoilerManager();

    /// <summary>
    /// Asks the user for the operation to perform
    /// </summary>
    public void DisaplyMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            string userChoice = CreateDropDown<string>(StringConstants.MenuOperations, StringConstants.selectMenuOptions, StringConstants.MenuFields);
            switch (userChoice)
            {
                case "Start Sequence":
                    boilerManager.StartSequence();
                    break;
                case "Stop Sequence":
                    boilerManager.StopSequence();
                    break;
                case "Simulate Boiler Error":
                    break;
                case "Toggle InterLock Switch":
                    ToggleSwitch();
                    break;
                case "Reset Lockout":
                    boilerManager.ResetLockOut();
                    break;
                case "View Log":
                    break;
                case "Exit":
                    isRunning = false;
                    break;
            }
        }
    }

    /// <summary>
    /// Gets the switch state from the user
    /// </summary>
    public void ToggleSwitch()
    {
        string userChoice = CreateDropDown<string>(StringConstants.SwitchState, StringConstants.selectMenuOptions, StringConstants.MenuFields);
        if (userChoice != null)
        {
            boilerManager.ToggleRunInteractorSwitch(userChoice);
        }
        return;
    }

    private T? CreateDropDown<T>(IList<T> items, string message, string menuOptions)
    {
        int selectedIndex = 0;
        ConsoleKey key;
        while (true)
        {
            DrawMenu(items, selectedIndex, message, menuOptions);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + items.Count) % items.Count;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1 + items.Count) % items.Count;
            }
            else if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                return items[selectedIndex];
            }
            else if (key == ConsoleKey.B) // Handle back action
            {
                Console.Clear();
                return default;
            }
        }
    }

    private void DrawMenu<T>(IList<T> categories, int selectedIndex, string message, string menuOptions)
    {
        Console.Clear();
        DisplayTitle(message);

        // Get the current cursor position after printing the message
        int startRow = Console.CursorTop + 1; // Move below the message

        // Ensure the menu doesn't exceed the window height
        if (startRow + categories.Count >= Console.WindowHeight)
        {
            startRow = Console.WindowHeight - categories.Count - 1;
        }

        // Set cursor to dynamically available top-left position
        Console.SetCursorPosition(0, startRow);

        for (int i = 0; i < categories.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {categories[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {categories[i]}");
            }
        }
        DisplayTitle(menuOptions);
    }

    private void DisplayTitle(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n{message}\n");
        Console.ResetColor();
    }
}
