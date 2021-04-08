using System;

namespace LibWebApp.Domain.Interfaces
{
    interface IBook
    {
        public int Id { get; set; }

        public String Author { get; set; }

        public String Name { get; set; }
    }
}
