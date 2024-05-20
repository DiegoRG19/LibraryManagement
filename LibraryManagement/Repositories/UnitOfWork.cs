using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private IRepository<Libro> _libros;
        private IRepository<Autor> _autores;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        public IRepository<Libro> Libros => _libros??= new Repository<Libro>(_context);
        public IRepository<Autor> Autores => _autores ??= new Repository<Autor>(_context);

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}
