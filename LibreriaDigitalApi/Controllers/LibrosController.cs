using Microsoft.AspNetCore.Mvc;
using LibreriaDigitalApi.Repositories;
using LibreriaDigitalApi.Models;

namespace LibreriaDigitalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly IBookRepository _repository;

    // Inyectamos el repositorio para cumplir con el Requisito Técnico #3
    public LibrosController(IBookRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Libros (Listar libros - Requisito Funcional 2.b)
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var libros = await _repository.GetAllAsync();
        return Ok(libros);
    }

    // POST: api/Libros (Añadir libro - Requisito Funcional 2.a)
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book libro)
    {
        await _repository.AddAsync(libro);
        return Ok(new { mensaje = "Libro añadido con éxito" });
    }

    // DELETE: api/Libros/{id} (Eliminar libro - Requisito Funcional 2.b)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok(new { mensaje = "Libro eliminado correctamente" });
    }
}