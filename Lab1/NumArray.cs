using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class NumArray
    {
        private int[] arr;
        private int size;

        public NumArray()
        {
            size = 0;
        }

        public void randFilling(int size)
        {
            this.arr = new int[size];
            this.size = size;
            for (int i = 0; i < size; ++i)
            {
                Random rand = new Random();
                this.arr[i] = rand.Next() % 20;
            }
        }

        public void insertionSort()
        {
            for (int i = 1; i < this.size; ++i)
            {
                bool isFound = false;
                int temp = 0;
                for (int j = 0; j <= i; ++j)
                {
                    if (!isFound)
                    {
                        if (this.arr[i] < this.arr[j])
                        {
                            isFound = true;
                            temp = this.arr[j];
                            this.arr[j] = this.arr[i];
                        }
                    }
                    else
                    {
                        int temp2 = this.arr[j];
                        this.arr[j] = temp;
                        temp = temp2;
                    }
                }
            }
        }

        public void show()
        {
            for (int i = 0; i < size; ++i)
            {
                Console.Write(this.arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine(" ");
        }
    }
}
