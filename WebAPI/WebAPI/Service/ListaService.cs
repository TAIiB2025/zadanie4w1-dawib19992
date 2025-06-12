public class ListaService : IListaService
{
    private static int idGen = 1;
    private readonly List<Ksiazka> _lista = new List<Ksiazka>
    {
        new Ksiazka { Id = idGen++, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieœæ psychologiczna", Rok = 1866 },
        new Ksiazka { Id = idGen++, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
        new Ksiazka { Id = idGen++, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 },
        new Ksiazka { Id = idGen++, Tytul = "WiedŸmin: Ostatnie ¿yczenie", Autor = "Andrzej Sapkowski", Gatunek = "Fantasy", Rok = 1993 },
        new Ksiazka { Id = idGen++, Tytul = "Duma i uprzedzenie", Autor = "Jane Austen", Gatunek = "Romans", Rok = 1813 }
    };

    public IEnumerable<Ksiazka> Get() => _lista;

    public Ksiazka GetById(int id) => _lista.FirstOrDefault(k => k.Id == id) ?? throw new Exception("Nie znaleziono wskazanej ksi¹¿ki");

    public void Delete(int id) => _lista.RemoveAll(k => k.Id == id);

    public void Put(int id, Ksiazka ksiazka)
    {
        var existing = _lista.FirstOrDefault(k => k.Id == id);
        if (existing == null) throw new Exception("Nie znaleziono wskazanej ksi¹¿ki");

        existing.Tytul = ksiazka.Tytul;
        existing.Autor = ksiazka.Autor;
        existing.Gatunek = ksiazka.Gatunek;
        existing.Rok = ksiazka.Rok;
    }

    public void Post(Ksiazka ksiazka)
    {
        ksiazka.Id = idGen++;
        _lista.Add(ksiazka);
    }
}