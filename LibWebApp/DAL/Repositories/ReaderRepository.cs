using System;
using System.Collections.Generic;
using System.Linq;
using LibWebApp.DAL.Entities;
using LibWebApp.DAL.Interfaces;
using LibWebApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibWebApp.DAL.Repositories
{
    public class ReaderRepository : IRepository<Reader>
    {
        private LibContext db;

        public ReaderRepository(LibContext context)
        {
            this.db = context;
        }

        public IEnumerable<Reader> GetAll()
        {
            return db.Readers.ToList();
        }

        public Reader Get(int id)
        {
            return db.Readers.Find(id);
        }

        public void Create(Reader reader)
        {
           db.Readers.Add(reader);
        }

        public void Update(Reader reader)
        {
            db.Entry(reader).State = EntityState.Modified;
        }

        public IEnumerable<Reader> Find(Func<Reader, Boolean> predicate)
        {
            return db.Readers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Reader reader = db.Readers.Find(id);
            if (reader != null)
                db.Readers.Remove(reader);
        }
    }
}
