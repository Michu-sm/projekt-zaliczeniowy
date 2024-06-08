using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Biblioteka
{
    public List<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();

    public void DodajKsiazke(Ksiazka ksiazka)
    {
        Ksiazki.Add(ksiazka);
    }

    public Ksiazka? PobierzSzczegolyKsiazki(int id)
    {
        return Ksiazki.FirstOrDefault(k => k.Id == id);
    }

    public void ZapiszDoPliku(string sciezka)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(sciezka + ".txt"))
            {
                foreach (var ksiazka in Ksiazki)
                {
                    writer.WriteLine($"{ksiazka.Id};{ksiazka.Tytul};{ksiazka.Autor};{ksiazka.RokWydania};{ksiazka.CzyAudiobook};{ksiazka.CzyWersjaFilmowa}");

                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas zapisu do pliku: " + ex.Message);
        }
    }

    public void OdczytajZPliku(string sciezka)
    {
        try
        {
            using (StreamReader reader = new StreamReader(sciezka + ".txt"))
            {
                string line;
                Ksiazki.Clear();
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    int id = int.Parse(parts[0]);
                    string tytul = parts[1];
                    string autor = parts[2];
                    int rokWydania = int.Parse(parts[3]);
                    bool czyAudiobook = bool.Parse(parts[4]);
                    bool czyWersjaFilmowa = bool.Parse(parts[5]);
                    Ksiazki.Add(new Ksiazka(id, tytul, autor, rokWydania, czyAudiobook, czyWersjaFilmowa));

                    Console.WriteLine($"ID: {id}, Tytuł: {tytul}, Autor: {autor}, Rok wydania: {rokWydania}, Audiobook: {czyAudiobook}, Wersja filmowa: {czyWersjaFilmowa}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas odczytu z pliku: " + ex.Message);
        }
    }

    public void AktualizujKsiazke(Ksiazka zaktualizowanaKsiazka)
    {
        var ksiazka = PobierzSzczegolyKsiazki(zaktualizowanaKsiazka.Id);
        if (ksiazka != null)
        {
            ksiazka.Tytul = zaktualizowanaKsiazka.Tytul;
            ksiazka.Autor = zaktualizowanaKsiazka.Autor;
            ksiazka.RokWydania = zaktualizowanaKsiazka.RokWydania;
            ksiazka.CzyAudiobook = zaktualizowanaKsiazka.CzyAudiobook;
            ksiazka.CzyWersjaFilmowa = zaktualizowanaKsiazka.CzyWersjaFilmowa;
        }
    }
}
