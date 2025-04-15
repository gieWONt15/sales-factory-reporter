// Factories/FileLogger.cs
    using System.IO;
    
    public class FileLogger : ILogger
    {
        private const string LogFilePath = "log.txt";
    
        public void Log(string message)
        {
            using var writer = new StreamWriter(LogFilePath, append: true);
            writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
    }