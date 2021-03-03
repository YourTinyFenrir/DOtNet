using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Domain.Interfaces
{
    interface IReader
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }
    }
}
