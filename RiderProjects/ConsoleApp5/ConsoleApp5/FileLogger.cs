using System;
using System.IO;

public static class FileLogger
{
    private static readonly string filePath = "log.txt";
    private static readonly object _lock = new();

    public static void Log(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}";
        
        lock (_lock)
        {
            File.AppendAllText(filePath, logEntry);
        }
    }
}