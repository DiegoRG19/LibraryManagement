using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
    public class LibraryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Libro>> GetAllLibros() => await _unitOfWork.Libros.GetAll();

        public async Task<Libro> GetLibroById(int id) => await _unitOfWork.Libros.GetById(id);

        public async Task CreateLibro(Libro libro)
        {
            if (await _unitOfWork.Autores.GetById(libro.AutorId) == null)
            {
                throw new Exception("El autor no existe.");
            }

            await _unitOfWork.Libros.Add(libro);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateLibro(Libro libro)
        {
            await _unitOfWork.Libros.Update(libro);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteLibro(int id)
        {
            await _unitOfWork.Libros.Delete(id);
            await _unitOfWork.SaveChanges();
        }
        public async Task<IEnumerable<Autor>> GetAllAutores() => await _unitOfWork.Autores.GetAll();

        public async Task<Autor> GetAutorById(int id) => await _unitOfWork.Autores.GetById(id);

        public async Task CreateAutor(Autor autor)
        {
            if ((await _unitOfWork.Autores.GetAll()).Any(a => a.NombreAutor == autor.NombreAutor))
            {
                throw new Exception("El autor ya existe.");
            }

            await _unitOfWork.Autores.Add(autor);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateAutor(Autor autor)
        {
            await _unitOfWork.Autores.Update(autor);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteAutor(int id)
        {
            await _unitOfWork.Autores.Delete(id);
            await _unitOfWork.SaveChanges();
        }
    }
}
