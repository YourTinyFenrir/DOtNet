using System;
using LibraryWebApp.Domain.Interfaces;

namespace LibraryWebApp.Domain.Models
{
    public class Book : IBook
    {
        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }

        public Reader Owner { get; set; }
    }
}
