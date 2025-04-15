// Interfaces/IRaport.cs
public interface IRaport
{
    void GenerujRaport(IEnumerable<Sprzedaz> dane);
}

// Interfaces/IWidok.cs
public interface IWidok
{
    void Wyswietl();
}

// Interfaces/ILogger.cs
public interface ILogger
{
    void Log(string message);
}

// Interfaces/IUIFactory.cs
public interface IUIFactory
{
    IRaport StworzRaport();
    IWidok StworzWidok();
    ILogger StworzLogger();
}