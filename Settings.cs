namespace Sniffer
{
    internal static class Settings
    {
        public static ConsoleColor foregroundColor = ConsoleColor.White;
        public static bool isConsoleOutputEnabled = false;

        public static void SetFromArray(string[]? arr)
        {
            if (arr is null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                arr[i] = arr[i].Replace("-", string.Empty);
            isConsoleOutputEnabled = arr.Contains("e");
            foreach (string str in arr)
            {
                foregroundColor = Enum.TryParse(str, out ConsoleColor parsedColor)
                    ? parsedColor : ConsoleColor.White;
            }
        }
    }
}
