using LibraryWebApp.DAL.Entities;
using System;

namespace LibraryWebApp.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }

        public virtual Reader Owner { get; set; }
    }
}
