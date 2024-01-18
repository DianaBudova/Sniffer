namespace Sniffer;

public class Commands
{
    public static string Run => "run";
    public static string Help => "help";

    public static string[] GetAllCommands()
    {//TODO clean code
        return new[] { Run, Help };
    }
}