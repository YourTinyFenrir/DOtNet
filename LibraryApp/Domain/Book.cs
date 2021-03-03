using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain
{
    class Book : IBook
    {
        public Book(String a, String n, Reader o)
        {
            this.Id = 0;
            this.Author = a;
            this.Name = n;
            this.Owner = o;
        }

        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }

        public Reader Owner { get; set; }

        public void Lock(Reader r)
        {
            this.Owner = r;
        }

        public void Free()
        {
            this.Owner = null;
        }
    }
}
