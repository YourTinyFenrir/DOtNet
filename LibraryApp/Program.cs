using System;
using LibraryApp.Domain;
using LibraryApp.Domain.Lists;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {

            BookList bl = new BookList();
            ReaderList rl = new ReaderList();
            Book a = new Book("AAA", "aaa", null);
            Book b = new Book("BBB", "bbb", null);
            Reader c = new Reader("CCC", "ccc");
            Reader d = new Reader("DDD", "ddd", null);

            bl.Add(a);
            bl.Add(b);
            c.AddBook(b);
            rl.Add(c);
            rl.Add(d);
            c.RemoveBook(b.Id);
            rl.Add(d);

        }
    }
}
