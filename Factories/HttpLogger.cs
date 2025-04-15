// Factories/HttpLogger.cs
    public class HttpLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[HTTP LOG]: {message}");
        }
    }