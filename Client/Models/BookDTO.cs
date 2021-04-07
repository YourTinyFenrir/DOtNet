using System;

namespace Client.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public String Author { get; set; }
        public String Name { get; set; }
        public virtual ReaderDTO Owner { get; set; }
    }
}
