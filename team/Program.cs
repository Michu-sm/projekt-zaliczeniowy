using System;
using static Biblioteka;

namespace Projektstartowy
{
    class Program
    {
        static void Main()
        {
            Biblioteka biblioteka = new Biblioteka();

            while (true)
            {
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Wyświetl wszystkie książki");
                Console.WriteLine("3. Zapisz do pliku");
                Console.WriteLine("4. Odczytaj z pliku");
                Console.WriteLine("5. Wyjście");

                Console.Write("Wybierz opcję: ");
                string opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        Console.Write("Podaj ID książki: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Podaj tytuł: ");
                        string tytul = Console.ReadLine();
                        Console.Write("Podaj autora: ");
                        string autor = Console.ReadLine();
                        Console.Write("Podaj rok wydania: ");
                        int rokWydania = int.Parse(Console.ReadLine());
                        Console.Write("Czy książka jest dostępna jako audiobook? (tak/nie): ");
                        bool czyAudiobook = Console.ReadLine().ToLower() == "tak";
                        Console.Write("Czy książka posiada wersję filmową? (tak/nie): ");
                        bool czyWersjaFilmowa = Console.ReadLine().ToLower() == "tak";
                        biblioteka.DodajKsiazke(new Ksiazka(id, tytul, autor, rokWydania, czyAudiobook, czyWersjaFilmowa));
                        break;
                    case "2":
                        foreach (var ksiazka in biblioteka.Ksiazki)
                        {
                            Console.WriteLine($"ID: {ksiazka.Id}, Tytuł: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok wydania: {ksiazka.RokWydania}, Audiobook: {ksiazka.CzyAudiobook}, Wersja filmowa: {ksiazka.CzyWersjaFilmowa}");
                        }
                        break;
                    case "3":
                        Console.Write("Podaj ścieżkę do pliku: ");
                        string sciezkaZapisu = Console.ReadLine();
                        biblioteka.ZapiszDoPliku(sciezkaZapisu);
                        break;
                    case "4":
                        Console.Write("Podaj ścieżkę do pliku: ");
                        string sciezkaOdczytu = Console.ReadLine();
                        biblioteka.OdczytajZPliku(sciezkaOdczytu);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            }
        }
    }
}
