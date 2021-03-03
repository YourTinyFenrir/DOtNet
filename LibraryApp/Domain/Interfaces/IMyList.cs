using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Domain.Interfaces
{
    interface IMyList<T>
    {
        public void Add(T t);

        public void Remove(T t);

        public T Find(int i);
     
    }
}
