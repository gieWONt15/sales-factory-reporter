using System;
using System.Data.SQLite;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var dbService = new DatabaseService();
            dbService.InicjalizujBaze();

            Console.WriteLine("Wybierz środowisko: 1-Desktop, 2-Web, 3-Export");
            var wybor = Console.ReadLine();

            IUIFactory factory = wybor switch
            {
                "1" => new DesktopUIFactory(),
                "2" => new WebUIFactory(),
                "3" => new ExportUIFactory(),
                _ => throw new InvalidOperationException("Nieprawidłowy wybór środowiska.")
            };

            var dane = dbService.PobierzDane();
            var raport = factory.StworzRaport();
            var widok = factory.StworzWidok();
            var logger = factory.StworzLogger();

            raport.GenerujRaport(dane);
            widok.Wyswietl();
            logger.Log("Operacja zakończona.");
        }
        catch (SQLiteException ex)
        {
            Console.WriteLine($"Błąd bazy danych: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Błąd wejścia/wyjścia: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
        }
    }
}