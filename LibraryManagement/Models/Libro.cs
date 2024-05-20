namespace LibraryManagement.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public bool Disponible { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
