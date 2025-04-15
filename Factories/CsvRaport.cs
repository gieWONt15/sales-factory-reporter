// Factories/CsvRaport.cs
    using System.IO;
    
    public class CsvRaport : IRaport
    {
        public void GenerujRaport(IEnumerable<Sprzedaz> dane)
        {
            var filePath = "raport.csv";
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Id,Produkt,Ilosc,Cena,Data");
            foreach (var sprzedaz in dane)
            {
                writer.WriteLine($"{sprzedaz.Id},{sprzedaz.Produkt},{sprzedaz.Ilosc},{sprzedaz.Cena},{sprzedaz.Data:yyyy-MM-dd}");
            }
            Console.WriteLine($"Raport zapisano do pliku: {filePath}");
        }
    }