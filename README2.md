# 📊 **Sprawozdanie z projektu - Aplikacja do zarządzania sprzedażą**

## 📝 **Opis projektu**

Projekt to aplikacja konsolowa napisana w języku **C#**, która umożliwia zarządzanie danymi sprzedaży. Wykorzystuje bazę danych **SQLite** do przechowywania danych oraz implementuje wzorzec projektowy **Abstract Factory**, co pozwala na łatwe rozszerzanie funkcjonalności aplikacji o różne środowiska.

---

## 🚀 **Funkcjonalności**

1. **Inicjalizacja bazy danych**:
    - Tworzenie tabeli `Sprzedaz` w bazie SQLite.
    - Wstawianie przykładowych danych, jeśli tabela jest pusta.

2. **Wybór środowiska**:
    - **Desktop**: Wyświetlanie raportu w konsoli.
    - **Web**: Generowanie raportu w formacie HTML.
    - **Export**: Eksportowanie raportu do pliku CSV.

3. **Logowanie zdarzeń**:
    - Logowanie do konsoli.
    - Logowanie do pliku tekstowego.
    - Logowanie symulowane jako logi HTTP.

4. **Obsługa wyjątków**:
    - Obsługa błędów bazy danych, błędów wejścia/wyjścia oraz innych nieoczekiwanych błędów.

---

## 🛠️ **Wymagania systemowe**

- **.NET SDK**: Wersja 9.0 lub nowsza.
- **System operacyjny**: macOS, Windows lub Linux.
- **Biblioteki NuGet**:
    - `Microsoft.Data.Sqlite.Core` (9.0.4)
    - `System.Data.SQLite.Core` (1.0.119)
    - `SQLitePCLRaw.bundle_e_sqlite3` (2.1.11)

---

## 📂 **Struktura projektu**

- **`Program.cs`**: Główna klasa aplikacji, obsługująca logikę wyboru środowiska i zarządzania przepływem programu.
- **`Services/DatabaseService.cs`**: Klasa odpowiedzialna za inicjalizację bazy danych SQLite oraz pobieranie danych.
- **`Models/Sprzedaz.cs`**: Model danych reprezentujący rekord sprzedaży.
- **`Interfaces/`**: Zawiera interfejsy definiujące kontrakty dla raportów, widoków i loggerów.
- **`Factories/`**: Implementacje fabryk dla różnych środowisk (Desktop, Web, Export).

---

## 🖥️ **Działanie aplikacji**

### 1️⃣ **Inicjalizacja bazy danych**
Przy pierwszym uruchomieniu aplikacja tworzy tabelę `Sprzedaz` i wstawia przykładowe dane, jeśli tabela jest pusta.

```csharp
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
}
```
<hr>

## 2️⃣ **Wybór środowiska**
Użytkownik wybiera środowisko, w którym aplikacja ma działać:
1: Desktop (konsola).
2: Web (HTML).
3: Export (CSV).

```csharp
var wybor = Console.ReadLine();
IUIFactory factory = wybor switch
{
    "1" => new DesktopUIFactory(),
    "2" => new WebUIFactory(),
    "3" => new ExportUIFactory(),
    _ => throw new InvalidOperationException("Nieprawidłowy wybór środowiska.")
};
```

<hr>

## 3️⃣ **Generowanie raportu**
Każde środowisko generuje raport w odpowiednim formacie:


Desktop: Wyświetla sumę sprzedaży w konsoli.
Web: Generuje raport w formacie HTML.
Export: Eksportuje dane do pliku raport.csv.
Przykład raportu CSV:

```csv
Id,Produkt,Ilosc,Cena,Data
1,Produkt A,10,15.5,2023-01-01
2,Produkt B,5,25.0,2023-01-02
```

<hr>

## 4️⃣ **Logowanie zdarzeń**
Każde środowisko loguje zdarzenia w inny sposób:


Desktop: Logowanie do konsoli.
Web: Logowanie symulowane jako logi HTTP.
Export: Logowanie do pliku log.txt.
Przykład logu:
```txt
[2023-10-01 12:00:00] Operacja zakończona.
```

## 🗃️ **Struktura bazy danych**
**Tabela Sprzedaz zawiera następujące kolumny:**

```sql
id (INTEGER): Klucz główny.
produkt (TEXT): Nazwa produktu.
ilosc (INT): Ilość sprzedanych sztuk.
cena (REAL): Cena jednostkowa.
data (TEXT): Data sprzedaży.
```
<hr>

## 🐛 **Debugowanie**
**Brak pliku sprzedaz.db:**


Upewnij się, że plik sprzedaz.db znajduje się w katalogu wyjściowym (bin/Debug/net9.0).
Jeśli plik nie istnieje, aplikacja automatycznie go utworzy.
Problemy z bibliotekami SQLite:


Upewnij się, że zainstalowane są wszystkie wymagane pakiety NuGet.
Na macOS ustaw zmienną środowiskową:
export DYLD_LIBRARY_PATH=$(pwd)/bin/Debug/net9.0
Logi błędów:


W przypadku środowiska Export sprawdź plik log.txt w katalogu projektu.
<hr>

## 🔧 **Rozszerzenia**
Projekt można łatwo rozszerzyć o nowe środowiska, raporty, widoki i loggery, implementując odpowiednie interfejsy:


IRaport: Dla nowych typów raportów.
IWidok: Dla nowych sposobów wyświetlania danych.
ILogger: Dla nowych metod logowania.
<hr>

## 👨‍💻 Autor
Projekt został stworzony przez **Paweł Gierlotka**.

📅 Data utworzenia: 2025-04-15
📧 Kontakt: gieWONt15 na GitHub