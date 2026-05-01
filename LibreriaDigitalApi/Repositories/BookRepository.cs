using LibreriaDigitalApi.Data;
using LibreriaDigitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDigitalApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    // Método para buscar un libro por su ID (necesario para editar o eliminar)
    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    // Método para Editar (Requisito Funcional 2.b)
    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    // Método para Eliminar (Requisito Funcional 2.b)
    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}