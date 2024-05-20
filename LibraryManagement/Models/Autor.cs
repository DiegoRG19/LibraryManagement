namespace LibraryManagement.Models
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
