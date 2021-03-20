using LibraryWebApp.DAL.Entities;
using LibraryWebApp.DAL.Interfaces;
using LibraryWebApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.DAL.Repositories
{
    public class LibUnitOfWork : IUnitOfWork
    {
        private LibContext db;
        private BookRepository phoneRepository;
        private ReaderRepository orderRepository;

        public LibUnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibContext>();

            var options = optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=libwebappdb;Trusted_Connection=True;")
                    .Options;

            db = new LibContext(options);
        }

        public IRepository<Book> Books
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new BookRepository(db);
                return phoneRepository;
            }
        }

        public IRepository<Reader> Readers
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new ReaderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
