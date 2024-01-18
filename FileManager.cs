using System.Diagnostics;

namespace Sniffer;

public static class FileManager
{
    private const string fileName = "sniffer_log.txt";
    private static string path;
    private static FileStream? fs;
    private static StreamWriter? sw;
    
    static FileManager()
    {
        path = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}/{fileName}";
    }

    public static void WriteToFile(string value)
    {
        sw.Write(value);
        sw.Flush();
    }

    public static void WriteLineToFile(string value)
    {
        sw.WriteLine(value);
        sw.Flush();
    }

    public static void WriteProcessesToFile(Process[] processes)
    {
        foreach (Process process in processes)
            WriteLineToFile($"{DateTime.Now.ToString("HH:mm:ss")} [{process.Id}]{process.ProcessName}");
    }
    public static void OpenFile()
    {
        try
        {
            fs = File.Open(path, FileMode.OpenOrCreate);
            sw = new(fs);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static void CloseFile()
    {
        try
        {
            sw.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}