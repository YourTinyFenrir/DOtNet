using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain.Lists
{
    class BookList: IMyList<Book>
    {
        private List<Book> lst { get; set; }
        private int count;

        public BookList()
        {
            lst = new List<Book>();
            count = 0;
        }

        public void Add(Book book)
        {
            book.Id = count;
            count++;
            lst.Add(book);
        }

        public void Remove(Book book)
        {
            lst.Remove(book);
        }

        public Book Find(int Id)
        {
            foreach (Book b in lst)
            {
                if (b.Id == Id)
                {
                    return b;
                }
            }

            return null;
        }
    }
}
