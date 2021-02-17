using System;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;

namespace Lab1
{
    class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void randFilling(int size)
        {
            for (int i = 0; i < size; ++i)
            {
                Random rand = new Random();
                Node newEl = new Node(rand.Next() % 20);
                this.add(newEl);
            }
        }

        public void add(Node nd)
        {
            if (root == null)
                root = nd;
            else
            {
                Node temp = root;
                bool isEnd = false;
                while (!isEnd)
                {
                    if (nd.getValue() <= temp.getValue())
                    {
                        if (temp.getLeft() == null)
                        {
                            temp.setLeft(nd);
                            isEnd = true;
                        }
                        else temp = temp.getLeft();
                    }
                    else
                    {
                        if (temp.getRight() == null)
                        {
                            temp.setRight(nd);
                            isEnd = true;
                        }
                        else temp = temp.getRight();
                    }
                }
            }
        }

        public bool search(int val)
        {
            Node nd = root;
            bool res = false;
            while (nd != null && !res)
            {
                if (val < nd.getValue())
                    nd = nd.getLeft();
                else if (val > nd.getValue())
                    nd = nd.getRight();
                else
                    res = true;
            }

            return res;
        }

        public bool del(int val)
        {
            Node nd = root;
            Node parent = null;
            bool dir = false; // false - left, true - right
            bool isEnd = false;
            while (nd != null && !isEnd)
            {
                if (val < nd.getValue())
                {
                    parent = nd;
                    nd = nd.getLeft();
                    dir = false;
                }
                else if (val > nd.getValue())
                {
                    parent = nd;
                    nd = nd.getRight();
                    dir = true;
                }
                else
                {
                    isEnd = true;
                    if (nd.getLeft() == null && nd.getRight() == null)
                    {
                        if (parent == null)
                            this.root = null;
                        else
                        {
                            if (dir == false)
                                parent.setLeft(null);
                            else
                                parent.setRight(null);
                        }
                    }
                    else if ((nd.getLeft() != null && nd.getRight() != null))
                    {
                        Node temp = nd;
                        while (temp.getLeft() != null)
                        {
                            Node tempParent = temp;
                            temp = temp.getLeft();
                            if (temp.getLeft() == null)
                                tempParent.setLeft(null);
                        }
                        Node copyNd = new Node(temp);
                        if (parent == null)
                            this.root = copyNd;
                        else if (dir == false)
                            parent.setLeft(copyNd);
                        else
                            parent.setRight(copyNd);
                        copyNd.setLeft(nd.getLeft());
                        copyNd.setRight(nd.getRight());
                    }
                    else
                    {
                        Node temp;
                        if (nd.getLeft() != null)
                            temp = nd.getLeft();
                        else
                            temp = nd.getRight();

                        if (parent == null)
                            this.root = temp;
                        else if (dir == false)
                            parent.setLeft(temp);
                        else
                            parent.setRight(temp);
                    }
                }
            }

            return isEnd;
        }

        public void step(Node nd)
        {
            Console.Write(nd.getValue());
            Console.Write(" ");

            if (nd.getLeft() != null)
                step(nd.getLeft());
            if (nd.getRight() != null)
                step(nd.getRight());

        }

        public void show()
        {
            if (root == null)
                Console.WriteLine("Tree is empty");
            else
                step(this.root);
            Console.WriteLine(" ");
        }

    }
}
