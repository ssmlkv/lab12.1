using lab10;
using System.Threading.Channels;
using System;
using ClassLibrary1;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using lab9;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lab121
{
    public class Point<T> where T : new()
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Pred = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }

        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();
        }

        /*public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }*/

        // Метод для создания случайных данных для элемента списка
        public static Point<T> MakeRandomData()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).RandomInit();
            }
            else
            {
                throw new InvalidOperationException("Тип T не реализует интерфейс IIit");
            }
            return new Point<T>(data);
        }

        // Метод для создания случайного элемента списка
        public static T MakeRandomItem()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).RandomInit();
            }
            else
            {
                throw new InvalidOperationException("Тип T не реализует интерфейс IIit");
            }
            return data;
        }
    }
}
