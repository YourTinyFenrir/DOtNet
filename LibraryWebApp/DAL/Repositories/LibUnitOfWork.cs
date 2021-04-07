using LibraryWebApp.DAL.Entities;
using LibraryWebApp.DAL.Interfaces;
using LibraryWebApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.DAL.Repositories
{
    public class LibUnitOfWork : IUnitOfWork
    {
        private LibContext db;
        private BookRepository bookRepository;
        private ReaderRepository readerRepository;

        public LibUnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibContext>();

            var options = optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=libwebappdb;Trusted_Connection=True;")
                    .Options;

            db = new LibContext(options);
        }

        public LibUnitOfWork(BookRepository repo)
        {
            bookRepository = repo;
        }

        public LibUnitOfWork(ReaderRepository repo)
        {
            readerRepository = repo;
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public IRepository<Reader> Readers
        {
            get
            {
                if (readerRepository == null)
                    readerRepository = new ReaderRepository(db);
                return readerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
