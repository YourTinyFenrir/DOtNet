using System;

namespace LibraryWebApp.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }

        public virtual Reader Owner { get; set; }
    }
}
