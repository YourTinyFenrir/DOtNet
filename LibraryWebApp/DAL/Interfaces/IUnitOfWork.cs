using System;
using LibraryWebApp.DAL.Entities;

namespace LibraryWebApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<Reader> Readers { get; }
        void Save();
    }
}
