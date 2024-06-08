public class KsiazkaSpecjalna : Ksiazka
{
    public string DodatkoweInfo { get; set; }

    public KsiazkaSpecjalna(int id, string tytul, string autor, int rokWydania, bool czyAudiobook, bool czyWersjaFilmowa, string dodatkoweInfo)
        : base(id, tytul, autor, rokWydania, czyAudiobook, czyWersjaFilmowa)
    {
        DodatkoweInfo = dodatkoweInfo;
    }
}
