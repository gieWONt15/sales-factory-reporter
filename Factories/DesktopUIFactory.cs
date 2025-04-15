// Factories/DesktopUIFactory.cs
public class DesktopUIFactory : IUIFactory
{
    public IRaport StworzRaport() => new DesktopRaport();
    public IWidok StworzWidok() => new DesktopWidok();
    public ILogger StworzLogger() => new ConsoleLogger();
}

// Factories/DesktopRaport.cs
public class DesktopRaport : IRaport
{
    public void GenerujRaport(IEnumerable<Sprzedaz> dane)
    {
        var suma = dane.Sum(d => d.Ilosc * d.Cena);
        Console.WriteLine($"Suma sprzedaży: {suma:C}");
    }
}

// Factories/DesktopWidok.cs
public class DesktopWidok : IWidok
{
    public void Wyswietl()
    {
        Console.WriteLine("Wyświetlanie danych w konsoli...");
    }
}

// Factories/ConsoleLogger.cs
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}