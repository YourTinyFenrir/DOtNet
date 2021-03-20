using System;

namespace LibraryWebApp.Domain.Interfaces
{
    interface IReader
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }
    }
}
