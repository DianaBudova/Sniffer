namespace Sniffer
{
    internal static class Settings
    {
        public static ConsoleColor ForegroundColor = ConsoleColor.White;
        public static bool IsConsoleOutputEnabled = false;

        public static void SetFromArray(string[]? arr)
        {
            if (arr is null || arr.Length == 0)
                return;
            foreach (string str in arr)
            {
                //ForegroundColor = Enum.TryParse(str, out ConsoleColor parsedColor)
                //    ? parsedColor : ConsoleColor.White;
                if (str == "-black")
                    ForegroundColor = ConsoleColor.Black;
                else if (str == "-darkblue")
                    ForegroundColor = ConsoleColor.DarkBlue;
                else if (str == "-darkgreen")
                    ForegroundColor = ConsoleColor.DarkGreen;
                else if (str == "-darkcyan")
                    ForegroundColor = ConsoleColor.DarkCyan;
                else if (str == "-darkred")
                    ForegroundColor = ConsoleColor.DarkRed;
                else if (str == "-darkmagenta")
                    ForegroundColor = ConsoleColor.DarkMagenta;
                else if (str == "-darkyellow")
                    ForegroundColor = ConsoleColor.DarkYellow;
                else if (str == "-gray")
                    ForegroundColor = ConsoleColor.Gray;
                else if (str == "-darkgray")
                    ForegroundColor = ConsoleColor.DarkGray;
                else if (str == "-blue")
                    ForegroundColor = ConsoleColor.Blue;
                else if (str == "-green")
                    ForegroundColor = ConsoleColor.Green;
                else if (str == "-cyan")
                    ForegroundColor = ConsoleColor.Cyan;
                else if (str == "-red")
                    ForegroundColor = ConsoleColor.Red;
                else if (str == "-magenta")
                    ForegroundColor = ConsoleColor.Magenta;
                else if (str == "-yellow")
                    ForegroundColor = ConsoleColor.Yellow;
                else if (str == "-white")
                    ForegroundColor = ConsoleColor.White;
                else if (str == "-e")
                    IsConsoleOutputEnabled = true;
                else
                    Console.WriteLine($"Unknown argument: {str}.");
            }
        }
    }
}
