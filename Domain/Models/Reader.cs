using System;
using System.Collections.Generic;
using LibWebApp.Domain.Interfaces;

namespace LibWebApp.Domain.Models
{
    public class Reader : IReader
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public List<Book> BookList { get; set; }
    }
}
