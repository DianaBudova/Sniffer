using System.Diagnostics;

namespace Sniffer;

public class LogManager
{
    public bool ends = false;
    public void StartLogging()
    {
        FileManager.OpenFile();
        Process[]? currentProcesses = null;
        Process[]? oldProcesses = null;
        bool isFirstIteration = true;
        while (!ends)
        {
            Thread.Sleep(1000);
            oldProcesses = currentProcesses;
            currentProcesses = Process.GetProcesses();
            if (isFirstIteration)
            {
                FileManager.WriteProcessesToFile(currentProcesses);
                isFirstIteration = false;
                continue;
            }
            FileManager.WriteLineToFile("---------------NEW---------------");
            FileManager.WriteProcessesToFile(currentProcesses.Where(p => oldProcesses!.All(op => p.Id != op.Id)).ToArray());            
            FileManager.WriteLineToFile("-------------REMOVED-------------");
            FileManager.WriteProcessesToFile(oldProcesses!.Where(p => currentProcesses!.All(op => p.Id != op.Id)).ToArray());
        }
    }
}