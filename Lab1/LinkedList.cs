using System;

namespace Lab1
{
    class LinkedList
    {
        private Element firstElem;

        public LinkedList()
        {
            firstElem = null;
        }

        public Element getFirstElem()
        {
            return this.firstElem;
        }

        public void setFirstElem(Element el)
        {
            this.firstElem = el;
        }

        public void randFilling(int size)
        {
            for (int i = 0; i < size; ++i)
            {
                Random rand = new Random();
                Element newEl = new Element(rand.Next() % 20);
                this.add(newEl, i);
            }
        }

        public void add(Element el, int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();
            Element curEl = this.firstElem;
            if (curEl != null)
            {
                if (index == 0)
                {
                    this.firstElem = el;
                    el.setNext(curEl);
                }
                else
                {
                    for (int i = 0; i < index - 1; ++i) // index-1, чтобы найти элемент перед добавляемым
                    {
                        if (curEl == null)
                            throw new IndexOutOfRangeException();
                        else
                            curEl = curEl.getNext();
                    }

                    el.setNext(curEl.getNext());
                    curEl.setNext(el);
                }
            }
            else {
                if (index == 0)
                    this.firstElem = el;
                else
                    throw new IndexOutOfRangeException();
            }

        }

        public void del(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();
            Element curEl = this.firstElem;
            Element delEl = null;
            if (curEl == null)
                throw new IndexOutOfRangeException();
            else
            {
                if (index == 0)
                {
                    if (curEl.getNext() == null)
                        this.firstElem = null;
                    else
                        this.firstElem = curEl.getNext();
                }
                else
                {
                    if (curEl.getNext() == null)
                        throw new IndexOutOfRangeException();
                    else
                        delEl = curEl.getNext();

                    for (int i = 1; i < index; ++i) // Изначально curEl - 0ой элемент списка, delEl - 1ый
                    {
                        curEl = delEl;
                        delEl = delEl.getNext();
                        if (delEl == null)
                            throw new IndexOutOfRangeException();
                    }

                    curEl.setNext(delEl.getNext());
                }
            }

        }

        public LinkedList reverse()
        {
            LinkedList res = new LinkedList();
            Element el = this.getFirstElem();
            while (el != null)
            {
                Element newEl = new Element(el.getValue());
                res.add(newEl, 0);
                el = el.getNext();
            }

            return res;
        }

        public void show()
        {
            Element el = this.firstElem;
            while (el != null)
            {
                Console.Write(el.getValue());
                Console.Write(" ");
                el = el.getNext();
            }
            Console.WriteLine(" ");
        }
    }
}
