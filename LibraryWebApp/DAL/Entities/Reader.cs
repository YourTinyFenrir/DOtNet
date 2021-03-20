using System;
using System.Collections.Generic;

namespace LibraryWebApp.DAL.Entities
{
    public class Reader
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public virtual List<Book> BookList { get; set; } = new List<Book>();
    }
}
