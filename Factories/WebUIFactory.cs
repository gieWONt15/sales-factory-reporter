// Factories/WebUIFactory.cs
public class WebUIFactory : IUIFactory
{
    public IRaport StworzRaport() => new WebRaport();
    public IWidok StworzWidok() => new WebWidok();
    public ILogger StworzLogger() => new HttpLogger();
}