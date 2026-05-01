using LibreriaDigitalApi.Models;

namespace LibreriaDigitalApi.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id); // Para buscar antes de editar
    Task AddAsync(Book book);
    Task UpdateAsync(Book book); // Requisito: Editar
    Task DeleteAsync(int id);    // Requisito: Eliminar
}