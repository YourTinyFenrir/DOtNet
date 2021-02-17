using System;
using System.Runtime.CompilerServices;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*LinkedList lst = new LinkedList();
                Console.Write("Количество элементов списка: ");
                String str = Console.ReadLine();
                int num = Int32.Parse(str);*/

                // Ввод рандомных значений
                // lst.randFilling(num);

                // Вывод изначального списка
                //lst.show();

                // Добавление элемента за границы списка
                /*Random rand = new Random();
                Element newEl = new Element(rand.Next() % 20);
                lst.add(newEl, 6);
                */

                // Удаление первого и последнего элементов
                /*lst.del(num-1);
                lst.del(0);*/

                // Удаление элемента за границами списка
                //lst.del(6);

                // "Разворот" списка
                /*LinkedList rvsLst = lst.reverse();
                rvsLst.show();*/

                // Вывод измененного списка
                //lst.show();



                /*BinaryTree tr = new BinaryTree();
                Console.Write("Количество элементов дерева: ");
                String str = Console.ReadLine();
                int num = Int32.Parse(str);*/

                // Ввод рандомных значений
                // tr.randFilling(num);

                // Вывод изначального дерева
                //tr.show();

                // Поиск чисел 6 и 13
                /*Console.WriteLine(tr.search(6));
                Console.WriteLine(tr.search(13));*/

                // Однократное удаление чисел 5 и 17
                /*Console.WriteLine(tr.del(5));
                Console.WriteLine(tr.del(17));*/

                // Вывод бинарного дерева
                // tr.show();


                NumArray na = new NumArray();
                Console.Write("Количество элементов массива: ");
                String str = Console.ReadLine();
                int num = Int32.Parse(str);

                // Ввод рандомных значений
                na.randFilling(num);

                // Вывод изначального массива
                na.show();

                // Сортировка вставками
                na.insertionSort();

                // Вывод отсортированного массива
                na.show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

