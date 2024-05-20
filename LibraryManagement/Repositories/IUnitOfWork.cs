using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Libro> Libros { get; }
        IRepository<Autor> Autores { get; }
        Task SaveChanges();
    }
}
