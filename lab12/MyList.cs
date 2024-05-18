using System;
using lab10;
using lab9;
using lab121;
using ClassLibrary1;

namespace lab12_1
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T> beg = null;
        public Point<T> end = null;

        int count = 0;

        public int Count => count;

        public void AddToBegin(T item)//добавление в начало
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)//добавление в конец
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList<T> DeepClone()// Клонирование
        {
            MyList<T> clonedList = new MyList<T>();

            Point<T>? current = beg;
            while (current != null)
            {
                clonedList.AddToEnd(current.Data);
                current = current.Next;
            }
            return clonedList;
        }


        public MyList() { }// конструктор без параметров

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = Point<T>.MakeRandomData();
            end = beg;
            count = 1;
            for (int i = 1; i < size; i++)
            {
                T newItem = Point<T>.MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public MyList(T[] collection)//конструктор с параметрами
        {
            if (collection == null)
                throw new Exception("empty collection: null");
            if (collection.Length == 0)
                throw new Exception("empty collection");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            count = 1;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
            {
                Console.WriteLine("Лист пуст");
                return;
            }

            Point<T>? current = beg;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        /*public Point<T>? FindItem(T item)//поиск
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    Console.WriteLine("Список пуст");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }*/

        public bool IsEmpty()
        {
            return beg == null;
        }

        public void RemoveFirst(int index)//удаление
        {
            if (beg == null)
                return;

            if (index == 0)
            {
                beg = beg.Next;
                if (beg == null)
                    end = null;
                else
                    beg.Pred = null;
                return;
            }

            Point<T> current = beg;
            for (int i = 0; current != null && i < index - 1; i++)
            {
                current = current.Next;
            }

            if (current == null || current.Next == null)
                return;

            current.Next = current.Next.Next;
            if (current.Next == null)
                end = current;
            else
                current.Next.Pred = current;
        }


        public void AddToOddPositions(T element)//добавление по 1,3,5 и тд.
        {
            if (beg == null)
            {
                Point<T> newNode = new Point<T>(element);
                beg = newNode;
                end = newNode;
                count++;
                return;
            }

            Point<T> current = beg;

            T clonedElement = element is ICloneable ? (T)((ICloneable)element).Clone() : element;

            Point<T> newNodeFirst = new Point<T>(clonedElement);
            newNodeFirst.Next = current;
            current.Pred = newNodeFirst;
            beg = newNodeFirst;
            count++;

            while (current != null && current.Next != null)
            {
                T clonedElementInLoop = element is ICloneable ? (T)((ICloneable)element).Clone() : element;
                Point<T> newNode = new Point<T>(clonedElementInLoop);
                newNode.Next = current.Next;
                newNode.Pred = current;
                if (current.Next != null)
                {
                    current.Next.Pred = newNode;
                }
                current.Next = newNode;
                count++;

                if (current.Next != null)
                {
                    current = current.Next.Next;
                }
                
            }

            if (current != null && current.Next == null)
            {
                T clonedElementLast = element is ICloneable ? (T)((ICloneable)element).Clone() : element;
                Point<T> newNodeLast = new Point<T>(clonedElementLast);
                current.Next = newNodeLast;
                newNodeLast.Pred = current;
                end = newNodeLast;
                count++;
            }
        }

        public void Clear()//удаление списка из памяти
        {
            beg = null;
            end = null;
            count = 0;
        }
    }
}
