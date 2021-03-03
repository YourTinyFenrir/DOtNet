using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Domain.Interfaces
{
    interface IBook
    {
        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }
    }
}
