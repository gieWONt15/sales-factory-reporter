using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class DatabaseService
{
    private const string ConnectionString = "Data Source=sprzedaz.db";

    public void InicjalizujBaze()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Sprzedaz (
                id INTEGER PRIMARY KEY,
                produkt TEXT,
                ilosc INT,
                cena REAL,
                data TEXT
            );
        ";
        command.ExecuteNonQuery();

        command.CommandText = "SELECT COUNT(*) FROM Sprzedaz";
        var result = command.ExecuteScalar();
        var count = result != null ? Convert.ToInt32(result) : 0;

        if (count == 0)
        {
            command.CommandText = @"
                INSERT INTO Sprzedaz (produkt, ilosc, cena, data) VALUES
                ('Produkt A', 10, 15.5, '2023-01-01'),
                ('Produkt B', 5, 25.0, '2023-01-02');
            ";
            command.ExecuteNonQuery();
        }
    }

    public IEnumerable<Sprzedaz> PobierzDane()
    {
        var dane = new List<Sprzedaz>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Sprzedaz";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            dane.Add(new Sprzedaz
            {
                Id = reader.GetInt32(0),
                Produkt = reader.GetString(1),
                Ilosc = reader.GetInt32(2),
                Cena = Convert.ToDecimal(reader.GetDouble(3)),
                Data = DateTime.Parse(reader.GetString(4))
            });
        }
        return dane;
    }
}