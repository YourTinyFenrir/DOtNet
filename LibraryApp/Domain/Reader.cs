using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.Domain.Lists;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain
{
    class Reader : IReader
    {
        public Reader()
        {
            this.BookList = new BookList();
        }

        public Reader(String n, String s)
        {
            this.Id = 0;
            this.Name = n;
            this.Surname = s;
            this.BookList = new BookList();
        }

        public Reader(String n, String s, BookList b)
        {
            this.Id = 0;
            this.Name = n;
            this.Surname = s;
            this.BookList = b;
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public BookList BookList { get; set; }

        public void AddBook(Book b)
        {
            this.BookList.Add(b);
            b.Lock(this);
        }
        public void RemoveBook(int Id)
        {
            Book b = this.BookList.Find(Id);
            if (b != null)
            {
                this.BookList.Remove(b);
                b.Free();
            }
        }
    }
}
