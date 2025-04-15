// Factories/ExportUIFactory.cs
    public class ExportUIFactory : IUIFactory
    {
        public IRaport StworzRaport() => new CsvRaport();
        public IWidok StworzWidok() => new SilentWidok();
        public ILogger StworzLogger() => new FileLogger();
    }