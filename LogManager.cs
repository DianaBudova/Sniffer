using System.Diagnostics;

namespace Sniffer;

public class LogManager
{
    public bool ends = false;
    public void StartLogging(bool consoleOutput = false)
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
                if (consoleOutput)
                    foreach (Process process in currentProcesses)
                        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} [{process.Id}]{process.ProcessName}");
                isFirstIteration = false;
                continue;
            }
            FileManager.WriteLineToFile("\n---------------NEW---------------");
            if (consoleOutput)
                Console.WriteLine("\n---------------NEW---------------");
            var tempProcesses = currentProcesses.Where(p => oldProcesses!.All(op => p.Id != op.Id)).ToArray();
            FileManager.WriteProcessesToFile(tempProcesses);
            if (consoleOutput)
                foreach (Process process in tempProcesses)
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} [{process.Id}]{process.ProcessName}");
            FileManager.WriteLineToFile("-------------REMOVED-------------");
            if (consoleOutput)
                Console.WriteLine("-------------REMOVED-------------");
            tempProcesses = oldProcesses!.Where(p => currentProcesses!.All(op => p.Id != op.Id)).ToArray();
            FileManager.WriteProcessesToFile(tempProcesses);
            if (consoleOutput)
                foreach (Process process in tempProcesses)
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} [{process.Id}]{process.ProcessName}");
        }
    }
}