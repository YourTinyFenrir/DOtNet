using Microsoft.EntityFrameworkCore;
using LibraryWebApp.DAL.Entities;

namespace LibraryWebApp.DAL.Context
{
    public class LibContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public LibContext(DbContextOptions<LibContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
