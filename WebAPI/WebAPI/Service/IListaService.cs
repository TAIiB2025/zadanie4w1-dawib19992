public interface IListaService
{
    IEnumerable<Ksiazka> Get();
    Ksiazka GetById(int id);
    void Delete(int id);
    void Put(int id, Ksiazka ksiazka);
    void Post(Ksiazka ksiazka);
}
