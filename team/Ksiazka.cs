public class Ksiazka
{
    public int Id { get; set; }
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public int RokWydania { get; set; }
    public bool CzyAudiobook { get; set; }
    public bool CzyWersjaFilmowa { get; set; }

    public Ksiazka(int id, string tytul, string autor, int rokWydania, bool czyAudiobook, bool czyWersjaFilmowa)
    {
        Id = id;
        Tytul = tytul;
        Autor = autor;
        RokWydania = rokWydania;
        CzyAudiobook = czyAudiobook;
        CzyWersjaFilmowa = czyWersjaFilmowa;
    }
}
