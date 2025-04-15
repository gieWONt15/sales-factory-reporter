# README.md

## Opis projektu

Projekt jest aplikacją konsolową napisaną w języku C#, która umożliwia zarządzanie danymi sprzedaży. Aplikacja wykorzystuje bazę danych SQLite do przechowywania danych oraz implementuje wzorzec projektowy **Abstract Factory**, aby umożliwić różne sposoby generowania raportów, wyświetlania danych i logowania.

### Funkcjonalności:
1. **Inicjalizacja bazy danych**: Tworzenie tabeli `Sprzedaz` w bazie SQLite oraz wstawianie przykładowych danych, jeśli tabela jest pusta.
2. **Wybór środowiska**:
    - **Desktop**: Wyświetlanie raportu w konsoli.
    - **Web**: Generowanie raportu w formacie HTML.
    - **Export**: Eksportowanie raportu do pliku CSV.
3. **Logowanie zdarzeń**:
    - Logowanie do konsoli.
    - Logowanie do pliku tekstowego.
    - Logowanie symulowane jako logi HTTP.
4. **Obsługa wyjątków**: Obsługa błędów bazy danych, błędów wejścia/wyjścia oraz innych nieoczekiwanych błędów.

---

## Wymagania systemowe

- **.NET SDK**: Wersja 9.0 lub nowsza.
- **System operacyjny**: macOS, Windows lub Linux.
- **Biblioteki NuGet**:
    - `Microsoft.Data.Sqlite.Core` (9.0.4)
    - `System.Data.SQLite.Core` (1.0.119)
    - `SQLitePCLRaw.bundle_e_sqlite3` (2.1.11)

---

## Instalacja

1. **Klonowanie repozytorium**:
   ```bash
   git clone https://github.com/gieWONt15/zadanie_5ver2.git
   cd zadanie_5ver2
   ```

2. **Przygotowanie środowiska**:
   Upewnij się, że masz zainstalowane wymagane biblioteki NuGet:
   ```bash
   dotnet restore
   ```

3. **Budowanie projektu**:
   ```bash
   dotnet build
   ```

4. **Uruchamianie aplikacji**:
   ```bash
   dotnet run
   ```

---

## Struktura projektu

- **`Program.cs`**: Główna klasa aplikacji, obsługująca logikę wyboru środowiska i zarządzania przepływem programu.
- **`Services/DatabaseService.cs`**: Klasa odpowiedzialna za inicjalizację bazy danych SQLite oraz pobieranie danych.
- **`Models/Sprzedaz.cs`**: Model danych reprezentujący rekord sprzedaży.
- **`Interfaces/`**: Zawiera interfejsy definiujące kontrakty dla raportów, widoków i loggerów.
- **`Factories/`**: Implementacje fabryk dla różnych środowisk (Desktop, Web, Export).

---

## Użycie

1. Po uruchomieniu aplikacji użytkownik zostanie poproszony o wybór środowiska:
    - `1`: Środowisko Desktop.
    - `2`: Środowisko Web.
    - `3`: Eksport danych do pliku CSV.

2. W zależności od wyboru, aplikacja:
    - Wygeneruje raport w odpowiednim formacie.
    - Wyświetli dane lub zapisze je do pliku.
    - Zaloguje zdarzenia w wybrany sposób.

---

## Przykłady działania

### 1. Środowisko Desktop
- **Raport**: Wyświetla sumę sprzedaży w konsoli.
- **Widok**: Wyświetla dane w konsoli.
- **Logowanie**: Loguje zdarzenia w konsoli.

### 2. Środowisko Web
- **Raport**: Generuje raport w formacie HTML.
- **Widok**: Symuluje wyświetlanie danych w API.
- **Logowanie**: Loguje zdarzenia jako logi HTTP.

### 3. Eksport danych
- **Raport**: Eksportuje dane do pliku `raport.csv`.
- **Widok**: Nie wyświetla danych.
- **Logowanie**: Loguje zdarzenia do pliku `log.txt`.

---

## Struktura bazy danych

Tabela `Sprzedaz` zawiera następujące kolumny:
- `id` (INTEGER): Klucz główny.
- `produkt` (TEXT): Nazwa produktu.
- `ilosc` (INT): Ilość sprzedanych sztuk.
- `cena` (REAL): Cena jednostkowa.
- `data` (TEXT): Data sprzedaży.

---

## Debugowanie

1. **Brak pliku `sprzedaz.db`**:
    - Upewnij się, że plik `sprzedaz.db` znajduje się w katalogu wyjściowym (`bin/Debug/net9.0`).
    - Jeśli plik nie istnieje, aplikacja automatycznie go utworzy.

2. **Problemy z bibliotekami SQLite**:
    - Upewnij się, że zainstalowane są wszystkie wymagane pakiety NuGet.
    - Na macOS ustaw zmienną środowiskową:
      ```bash
      export DYLD_LIBRARY_PATH=$(pwd)/bin/Debug/net9.0
      ```

3. **Logi błędów**:
    - W przypadku środowiska Export sprawdź plik `log.txt` w katalogu projektu.

---

## Rozszerzenia

Projekt można łatwo rozszerzyć o nowe środowiska, raporty, widoki i loggery, implementując odpowiednie interfejsy:
- **IRaport**: Dla nowych typów raportów.
- **IWidok**: Dla nowych sposobów wyświetlania danych.
- **ILogger**: Dla nowych metod logowania.

---

## Autor

Autorem projektu jest `Paweł Gierlotka`.