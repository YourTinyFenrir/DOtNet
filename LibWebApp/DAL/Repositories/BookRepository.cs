using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibWebApp.DAL.Entities;
using LibWebApp.DAL.Interfaces;
using LibWebApp.DAL.Context;
using System.Threading.Tasks;

namespace LibWebApp.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private LibContext db;

        public BookRepository(LibContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Book> Find(Func<Book, Boolean> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }
}
