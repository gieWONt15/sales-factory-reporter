// Factories/WebRaport.cs
public class WebRaport : IRaport
{
    public void GenerujRaport(IEnumerable<Sprzedaz> dane)
    {
        var suma = dane.Sum(d => d.Ilosc * d.Cena);
        Console.WriteLine($"<html><body><h1>Suma sprzedaży: {suma:C}</h1></body></html>");
    }
}