using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain.Lists
{
    class ReaderList : IMyList<Reader>
    {
        private List<Reader> lst { get; set; }
        private int count = 0;

        public ReaderList()
        {
            lst = new List<Reader>();
            count = 0;
        }

        public void Add(Reader reader)
        {
            reader.Id = count;
            count++;
            lst.Add(reader);
        }

        public void Remove(Reader reader)
        {
            lst.Remove(reader);
        }

        public Reader Find(int Id)
        {
            foreach (Reader r in lst)
            {
                if (r.Id == Id)
                {
                    return r;
                }
            }

            return null;
        }
    }
}
