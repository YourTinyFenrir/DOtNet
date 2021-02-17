using System;

namespace Lab1
{
    class Element
    {
        private int value;
        private Element next;

        public Element()
        {
            value = 0;
            next = null;
        }

        public Element(int val)
        {
            value = val;
            next = null;
        }

        public int getValue()
        {
            return this.value;
        }

        public void setValue(int val)
        {
            this.value = val;
        }

        public Element getNext()
        {
            return this.next;
        }

        public void setNext(Element el)
        {
            this.next = el;
        }
    }
}
