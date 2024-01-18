namespace Sniffer;

static class Program
{
    private static readonly LogManager lm;

    static Program()
    {
        lm = new();
        Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPressedHandler);
    }

    static void Main(string[] args)
    {
        if (args is null || args.Length == 0)
        {
            Console.WriteLine("No arguments was set, please use suitable arguments:");
            DisplayHelp();
            return;
        }
        string mainArg = args[0].ToLower();
        string[]? settings = args[1..^0]; //Array slicing //^0 index from end
        Settings.SetFromArray(settings);
        Console.ForegroundColor = Settings.foregroundColor;
        if (mainArg == Commands.Run) // true
        {
            try
            {
                Console.WriteLine("Press Ctrl+C key to stop the app...");
                lm.StartLogging();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else if (mainArg == Commands.Help)
        {
            DisplayHelp();   
        }
        else
        {
            Console.WriteLine("Invalid argument, please use suitable arguments:");
            DisplayHelp();
        }
    }
    private static void DisplayHelp()
    {
        try
        {
            Array.ForEach(Commands.GetAllCommands(), Console.WriteLine);
            Console.CursorTop -= 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    private static void CancelKeyPressedHandler(object? sender, ConsoleCancelEventArgs args)
    {
        lm.ends = true;
        FileManager.CloseFile();
        Console.ForegroundColor = ConsoleColor.White;
    }
}