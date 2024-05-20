using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }   

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Libros)
                .WithOne(l => l.Autor)
                .HasForeignKey(l => l.AutorId);
        }
    }
}
