using System;
using LibWebApp.DAL.Entities;

namespace LibWebApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<Reader> Readers { get; }
        void Save();
    }
}
