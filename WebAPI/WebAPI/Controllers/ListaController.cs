using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/ksiazki")]
public class ListaController : ControllerBase
{
    private readonly IListaService _listaService;

    public ListaController(IListaService listaService)
    {
        _listaService = listaService;
    }

    // Pobranie wszystkich ksi��ek
    [HttpGet]
    public ActionResult<IEnumerable<Ksiazka>> Get()
    {
        return Ok(_listaService.Get());
    }

    // Pobranie jednej ksi��ki po ID
    [HttpGet("{id}")]
    public ActionResult<Ksiazka> GetById(int id)
    {
        try
        {
            return Ok(_listaService.GetById(id));
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // Dodanie nowej ksi��ki
    [HttpPost]
    public IActionResult Post([FromBody] Ksiazka ksiazka)
    {
        if (ksiazka == null)
        {
            return BadRequest(new { message = "Niepoprawne dane ksi��ki." });
        }

        _listaService.Post(ksiazka);
        return CreatedAtAction(nameof(GetById), new { id = ksiazka.Id }, ksiazka);
    }

    // Aktualizacja ksi��ki po ID
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Ksiazka ksiazka)
    {
        try
        {
            _listaService.Put(id, ksiazka);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // Usuni�cie ksi��ki po ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _listaService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}