using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Node
    {
        private int value;
        private Node left;
        private Node right;

        public Node()
        {
            value = 0;
            left = null;
            right = null;
        }

        public Node(int val)
        {
            value = val;
            left = null;
            right = null;
        }

        public Node(Node nd)
        {
            this.value = nd.value;
            this.left = nd.left;
            this.right = nd.right;
        }

        public int getValue()
        {
            return this.value;
        }

        public Node getLeft()
        {
            return this.left;
        }

        public void setLeft(Node nd)
        {
            this.left = nd;
        }

        public Node getRight()
        {
            return this.right;
        }

        public void setRight(Node nd)
        {
            this.right = nd;
        }
    }
}
