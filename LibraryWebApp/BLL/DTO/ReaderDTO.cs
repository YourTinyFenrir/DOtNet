using System;
using System.Collections.Generic;

namespace LibraryWebApp.BLL.DTO
{
    public class ReaderDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public virtual List<BookDTO> BookList { get; set; } = new List<BookDTO>();
    }
}
